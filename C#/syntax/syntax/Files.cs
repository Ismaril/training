using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // Include the System.IO namespace for working with files.


namespace syntax
{
    internal static class Files
    {
        internal static void Main__()
        {
            Utilities utility = new Utilities();
            utility.Title("FILES");

            string writeText = "This is just some text.";
            // todo: Does relative path work in C#?
            string nameOfFile1 = "C:\\Users\\lazni\\PycharmProjects\\Training\\C#\\syntax\\syntax\\Nová složka\\txtFile1.txt";

            // Write a text to file.
            File.WriteAllText(path: nameOfFile1, contents: writeText);

            // Read a text from file.
            string readText = File.ReadAllText(path: nameOfFile1);
            Console.WriteLine(readText);

            // Checks if file exists.
            Console.WriteLine(File.Exists(nameOfFile1));

            // Delete file
            //File.Delete(nameOfFile1);

            utility.Separator();
        }
    }
}
