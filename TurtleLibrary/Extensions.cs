using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TurtleLibrary
{
    public static class Extensions
    {
        public static async Task<byte[]> ReadAllBytes(this IFormFile file)
        {
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }

        public static string ToImageSrc(this byte[] bytes)
        {
            return "data:image/png;base64," + Convert.ToBase64String(bytes);
        }
    }
}