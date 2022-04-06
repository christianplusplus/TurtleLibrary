using System;
using System.IO;
namespace Testing
{
    public class Tester
    {
        public void Test()
        {
            foreach (var file in Directory.GetFiles(@"C:\Users\christian.wendlandt\source\repos\TurtleLibrary\TurtleLibrary\Data\SeedContent\"))
            {
                Console.WriteLine(Path.GetFileNameWithoutExtension(file));
            }

            foreach (var file in Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "SeedContent")));
        }
    }
}