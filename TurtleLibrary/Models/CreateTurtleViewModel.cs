using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TurtleLibrary.Models
{
    public class CreateTurtleViewModel
    {
        public string Name { get; set; }
        public IFormFile Image { get; set; }
    }
}
