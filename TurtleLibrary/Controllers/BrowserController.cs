using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurtleLibrary.Data;

namespace TurtleLibrary.Controllers
{
    public class BrowserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BrowserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Browse()
        {
            return View(await _context.Turtle.ToListAsync());
        }
    }
}
