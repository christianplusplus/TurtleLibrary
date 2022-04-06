using System;
using System.Collections.Generic;
using System.IO;
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
            return View(await _context.Turtles.ToListAsync());
        }

        // GET: Turtles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turtle = await _context.Turtles
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
        public async Task<IActionResult> Create(CreateTurtleViewModel turtleVM)
        {
            using var memoryStream = new MemoryStream();
            await turtleVM.Image.CopyToAsync(memoryStream);
            byte[] image = memoryStream.ToArray();
            Image OriginalPortrait = new() { Data = image };
            Turtle turtle = new()
            {
                Name = turtleVM.Name,
                OriginalPortrait = OriginalPortrait,
                Portrait = OriginalPortrait
            };
            if (ModelState.IsValid)
            {
                _context.Add(OriginalPortrait);
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

            var turtle = await _context.Turtles.FindAsync(id);
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

            var turtle = await _context.Turtles
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
            var turtle = await _context.Turtles.FindAsync(id);
            _context.Turtles.Remove(turtle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurtleExists(int id)
        {
            return _context.Turtles.Any(e => e.Id == id);
        }

        public void Seed()
        {
            foreach (var file in Directory.GetFiles(Path.Combine("Data", "SeedContent")))
            {
                Image portrait = new()
                {
                    Data = System.IO.File.ReadAllBytes(file)
                };
                Turtle turtle = new()
                {
                    Name = Path.GetFileNameWithoutExtension(file),
                    OriginalPortrait = portrait,
                    Portrait = portrait
                };
                _context.Add(portrait);
                _context.Add(turtle);
            }
            _context.SaveChanges();
        }
    }
}
