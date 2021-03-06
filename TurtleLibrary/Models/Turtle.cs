using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TurtleLibrary.Models
{
    public class Turtle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayName("Original Portrait")]
        public virtual Image OriginalPortrait { get; set; }
        [DisplayName("Portrait")]
        public virtual Image Portrait { get; set; }
        [DisplayName("Checked Out By")]
        public virtual IdentityUser CheckedOutBy { get; set; }
    }
}
