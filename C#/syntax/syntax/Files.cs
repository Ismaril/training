using System;
using System.IO; // Include the System.IO namespace for working with files.

namespace syntax
{
    internal static class Files
    {
        internal static void Main__()
        {
            Utilities utility = new Utilities();
            utility.Title("FILES");

            // @ before string means to read the string literaly/raw, meaning it will not take int account escape characters.
            // @"\\servername\share\folder" (this line of code does the same as the one below)
            // "\\\\servername\\share\\folder"

            // Relative paths work in C# also.

            string writeText = "This is just some text.";
            string nameOfFile1 = $"{Constants.projectDirectory}\\syntax\\text_files\\txtFile1.txt";

            // Write a text to file.
            File.WriteAllText(path: nameOfFile1, contents: writeText);

            // Read a text from file.
            string readText = File.ReadAllText(path: nameOfFile1);
            Console.WriteLine(readText);

            // Checks if file exists.
            Console.WriteLine(File.Exists(nameOfFile1));


            //FileStream openedFile = File.Open(nameOfFile1, FileMode.Open, FileAccess.Read);
            //Console.WriteLine(openedFile.Read());

            // Append text at the end of an existing file.
            //nameOfFile1.AppendText("Ou yeahh.");

            // Delete file
            //File.Delete(nameOfFile1);

            utility.Separator();

            // Get all directories.
            string[] projectDirectories = Directory.GetDirectories(
            path: Constants.projectDirectory,         // path from where to start looking
            searchPattern: "*",                       // "*" asterisk as search for any
            searchOption: SearchOption.AllDirectories // All directories = seach all floders below current level. TopDirectoriesOnly = search only at current level (default).
            );
            foreach (string directory in projectDirectories)
            {
                Console.WriteLine(directory);
            }

            utility.Separator();


            // Get all files
            // "var" type means that the compile will figure out the data type at compilation time. 
            var files_ = Directory.GetFiles(
                path: Constants.workingDirectory,
                searchPattern: "*.*",
                searchOption: SearchOption.TopDirectoryOnly
            );
            foreach (string file in files_)
            {
                // Console.WriteLine(file);


                // Path.GetFileName(file) will remove the complete path before the file name and will return only the file name.
                // Console.WriteLine(Path.GetFileName(file)); // Returns name of file only.
                // Console.WriteLine(Path.GetFileNameWithoutExtension(file)); 
                
                var info = new FileInfo(file); // methods on this object can return handy info about a file.
                Console.WriteLine($"Filename: {info.Name}, size: {info.Length} bytes");

            }

            // Check if directory exists
            Console.WriteLine(Directory.Exists(path:Constants.workingDirectory));

            // Copy files
            // Overwrite True means to overwrite the files with the same name at destination.
            //File.Copy(sourceFileName: XXX, destFileName: YYY, overwrite: true); 

            // Move files
            // There is no option to overwrite files, meaning there must not be a file
            //  with a same name at final destination.
            // File.Move(sourceFileName: XXX, destFileName: YYY); 

            utility.Separator();
        }
    }
}
