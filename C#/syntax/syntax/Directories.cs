using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax
{
    public class Directories
    {
        public static void Main__()
        {
            Utilities utility = new Utilities();
            utility.Title("DIRECTORIES");
            
            // Current working directory
            DirectoryInfo currentDir = new DirectoryInfo(".");
            Console.WriteLine($"Current working dir: {currentDir.FullName}");

            // Specify with which path you want to work with
            DirectoryInfo desktop = new DirectoryInfo(@"C:\Users\lazni\desktop");
            Console.WriteLine(desktop.FullName); // Full path
            Console.WriteLine(desktop.Name); // Directory name
            Console.WriteLine(desktop.Parent); // Parent dir
            Console.WriteLine(desktop.CreationTime); // Create at
            Console.WriteLine(desktop.LastWriteTime);
            Console.WriteLine(desktop.LastAccessTime);
            Console.WriteLine(desktop.Exists);
            Console.WriteLine(desktop.Root);

            DirectoryInfo someFolder = new DirectoryInfo(@"C:\Users\lazni\desktop\some_folder");
            someFolder.Create(); // Create folder
            someFolder.Delete(); // Delete folder

            // ... or you can operate with methods like this, directly on Directory class:
            // Directory.CreateDirectory("somePath")
 
        }
    }
}
