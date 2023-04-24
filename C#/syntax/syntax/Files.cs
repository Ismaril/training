using System;
using System.IO; // Include the System.IO namespace for working with files.
using System.Text;

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

            // Use this if you want to write down some array into file.
            //File.WriteAllLines(filePath, array);

            // Read a text from file, returns a string.
            string readText = File.ReadAllText(path: nameOfFile1);
            Console.WriteLine(readText);

            // Read all lines from file, returns a string array based on each row.
            // File.ReadAllLines(filePath);

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

            // FILE STREAMS
            // Used for reading files as bytes/byte arrays.
            string path = @"C:\users\lazni\desktop\my_file.txt";
            // FileMode.Create - Create the file if it does not exist, else overwrite it.
            FileStream myFileStream = File.Open(path: path, mode: FileMode.Create);
            string text = "Duke Nukem";
            byte[] myByteArray = Encoding.Default.GetBytes(text);
            // If interested below parameter offset is explained ok in code docs.
            myFileStream.Write(array: myByteArray, offset: 0, count: myByteArray.Length);



        }
    }
}
