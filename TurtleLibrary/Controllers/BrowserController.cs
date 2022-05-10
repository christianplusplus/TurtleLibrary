using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Threading.Tasks;
using TurtleLibrary.Data;
using TurtleLibrary.Models;

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
            return await BrowseOrdered(true, typeof(Turtle).GetProperties()[0].Name);
        }

        public async Task<IActionResult> BrowseOrdered(bool isAscending, string orderByProperty)
        {
            ViewData["isAscending"] = isAscending;
            ViewData["orderByProperty"] = orderByProperty;
            var turtles = await _context.Turtles.OrderBy($"{orderByProperty} {(isAscending ? "ASC" : "DESC")}").ToListAsync();
            return View(turtles);
        }
    }
}
