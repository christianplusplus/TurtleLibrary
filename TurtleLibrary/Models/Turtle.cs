using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TurtleLibrary.Models
{
    public class Turtle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] OriginalImage { get; set; }
        public byte[] CurrentImage { get; set; }
        public virtual IdentityUser CheckedOutTo { get; set; }
    }
}
