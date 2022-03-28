using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TurtleLibrary.Data;
using TurtleLibrary.Models;

namespace TurtleLibrary.Controllers
{
    [Authorize]
    public class TurtlesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TurtlesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Turtles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Turtle.ToListAsync());
        }

        // GET: Turtles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turtle = await _context.Turtle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turtle == null)
            {
                return NotFound();
            }

            return View(turtle);
        }

        // GET: Turtles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Turtles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,OriginalImage,CurrentImage")] Turtle turtle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(turtle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(turtle);
        }

        // GET: Turtles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turtle = await _context.Turtle.FindAsync(id);
            if (turtle == null)
            {
                return NotFound();
            }
            return View(turtle);
        }

        // POST: Turtles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,OriginalImage,CurrentImage")] Turtle turtle)
        {
            if (id != turtle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turtle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurtleExists(turtle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(turtle);
        }

        // GET: Turtles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turtle = await _context.Turtle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turtle == null)
            {
                return NotFound();
            }

            return View(turtle);
        }

        // POST: Turtles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turtle = await _context.Turtle.FindAsync(id);
            _context.Turtle.Remove(turtle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurtleExists(int id)
        {
            return _context.Turtle.Any(e => e.Id == id);
        }
    }
}
