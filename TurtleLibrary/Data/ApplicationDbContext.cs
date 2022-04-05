using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TurtleLibrary.Models;

namespace TurtleLibrary.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext() : base()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TurtleLibrary.Models.Turtle> Turtles { get; set; }
        public DbSet<TurtleLibrary.Models.Image> Images { get; set; }
    }
}
