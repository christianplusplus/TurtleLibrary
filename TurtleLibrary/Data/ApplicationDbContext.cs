using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TurtleLibrary.Models;

namespace TurtleLibrary.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        /*
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            int imageId = 0;
            int turtleId = 0;
            foreach (var file in Directory.GetFiles(Path.Combine("Data", "SeedContent")))
            {
                Image image = new()
                {
                    Id = ++imageId,
                    Data = File.ReadAllBytes(file)
                };
                builder.Entity<Image>().HasData(image);
                builder.Entity<Turtle>()
                    .HasData(
                        new
                        {
                            Id = ++turtleId,
                            Name = Path.GetFileNameWithoutExtension(file),
                            OriginalPortraitId = imageId,
                            PortraitId = imageId
                        }
                    );
            }
        }
        */
        public DbSet<TurtleLibrary.Models.Turtle> Turtles { get; set; }
        public DbSet<TurtleLibrary.Models.Image> Images { get; set; }
    }
}
