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
            /*
            SOME QUESTIONS ASKED TO CHATGPT:
            
            EXPLAIN "FILE STREAM" PROGRAMMING TERM:
            A file stream is a sequence of bytes that represent data that is read from or written to a file in programming.

            In programming, a file stream is typically used to perform input/output (I/O) operations on a file, such as reading data from a file or writing data to a file. To create a file stream, you first need to open a file using a file handle, which provides a reference to the file on disk.

            Once you have a file handle, you can create a file stream object that allows you to read or write data to the file. The file stream object provides methods and properties for reading and writing data to and from the file, as well as for seeking to specific positions in the file and controlling the behavior of the stream.

            File streams are commonly used in programming languages such as C# and Java, where they are used to perform I/O operations on files, such as reading text or binary data from a file, writing data to a file, or appending data to an existing file.

            File streams can be used in a variety of applications, such as reading and writing configuration files, processing log files, storing and retrieving user preferences or settings, and reading and writing data in database or network protocols.

            -----------------------------------------------------------------------------------
            WHAT ADVANTAGE HAS USING FILESTREAM CLASS OVER FILE CLASS IN C#?:
            In C#, the File and FileStream classes are used for reading and writing files.

            The File class provides a set of static methods for reading from and writing to files, while the FileStream class is a more flexible and powerful class that allows you to work with streams of data from a file.

            One advantage of using the FileStream class over the File class is that the FileStream class provides more control over the data being read or written. For example, you can specify the buffer size for the stream, read or write to specific positions in the file, and choose between synchronous and asynchronous access.

            Another advantage of using the FileStream class is that it supports both synchronous and asynchronous reading and writing operations, while the File class only supports synchronous operations. This can be useful when working with large files or when you need to perform I/O operations on a background thread to avoid blocking the main thread of your application.

            Overall, the FileStream class is a more powerful and flexible class that provides greater control over the data being read or written and supports both synchronous and asynchronous operations, while the File class is a simpler and more convenient class that is useful for basic file I/O operations.
     
            */

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
            // When working fith file streams either use "using" ("with" in python) keyword, or you have to manually close the stream.
            // Used for reading files as bytes/byte arrays.

            // Write into file
            string path = @"C:\users\lazni\desktop\my_file.txt";
            // FileMode.Create - Create the file if it does not exist, else overwrite it.
            FileStream myFileStream = File.Open(path: path, mode: FileMode.Create);
            string text = "Tom";
            byte[] myByteArray = Encoding.Default.GetBytes(text);
            // If interested below parameter offset is explained ok in code docs.
            myFileStream.Write(array: myByteArray, offset: 0, count: myByteArray.Length);
            myFileStream.Close();
            
            // Open file and read its contents, but now with "using" keyword.
            using (FileStream fileStreamRead1 =  File.Open(path: path, mode: FileMode.Open))
            {
                // You can read each single byte by calling it. Seems like it is some iterator because with each next call it returns next item. But you can call it only that many times till you deplete all bytes in that array. This means if the array is exhausted it returns -1.
                Console.WriteLine(fileStreamRead1.ReadByte()); 
                Console.WriteLine(fileStreamRead1.ReadByte());
                Console.WriteLine(fileStreamRead1.ReadByte());
                Console.WriteLine(fileStreamRead1.ReadByte()); // returns -1
                Console.WriteLine(fileStreamRead1.ReadByte()); // returns -1
            }
            
            // Create a bytearray from the FileStream and then convert it to string.
            using (FileStream fileStreamRead2 =  File.Open(path: path, mode: FileMode.Open))
            {
                byte[] bytes = new byte[fileStreamRead2.Length];
                
                for(int i=0; i < fileStreamRead2.Length; i++)
                {
                    bytes[i] = (byte)fileStreamRead2.ReadByte();
                }

                Console.WriteLine(Encoding.Default.GetString(bytes));
            }

            utility.Separator();

            // STREAM WRITER/READER
            // TODO: This is another option to write files, needs to be checked where is an advantage compared to other classes.
            string path2 = @"C:\users\lazni\desktop\my_file2.txt";
            StreamWriter myStreamWriter = new StreamWriter(path: path2);
            myStreamWriter.WriteLine("Bob");
            myStreamWriter.WriteLine(1);
            myStreamWriter.Close();

            StreamReader myStreamReader = new StreamReader(path2);
            // Return first item of the array (without removing it)
            Console.WriteLine(Convert.ToChar(myStreamReader.Peek()));
            // Returns first line in the file.
            Console.WriteLine(myStreamReader.ReadLine());
            // Read to the end.
            Console.WriteLine(myStreamReader.ReadToEnd());

            utility.Separator();

            // BINARYWRITER
            // Some hint from chatGPT what is the difference between FileStream and BinaryWriter
            /*
            In C#, the FileStream class and BinaryWriter class are used for writing data to a file, but they have different purposes and functionality.

            The FileStream class provides a stream for reading from and writing to a file, allowing you to read and write raw bytes of data. It is a low-level class that provides a wide range of methods for reading and writing data to a file, including methods for seeking to specific positions in the file and for controlling the behavior of the stream.

            The BinaryWriter class, on the other hand, provides a higher-level abstraction for writing binary data to a stream. It wraps a Stream object, such as a FileStream, and provides methods for writing binary data in a specific format, such as integers, floats, and strings, as well as for writing arrays of data.

            In other words, FileStream is a basic class for working with files, while BinaryWriter is a higher-level class that provides convenient methods for writing data to a file in binary format.

            So, the main difference between FileStream and BinaryWriter is that FileStream is a more general-purpose class for reading and writing data to a file, while BinaryWriter is a specialized class that provides a more high-level and convenient way of writing binary data to a stream.
            */

            // create a binary writer for the file
            using (BinaryWriter writer = new BinaryWriter(File.Open(@"C:\users\lazni\desktop\myfile.bin", FileMode.Create)))
            {
                // write some hex (binary also possible) data to the file
                byte[] data = { 0x41, 0x42, 0x43, 0x44 };
                writer.Write(data);
                writer.Write(40);
                writer.Write(40.5d);

            }

            using (BinaryReader reader = new BinaryReader(File.Open(@"C:\users\lazni\desktop\myfile.bin", FileMode.Open)))
            {
                Console.WriteLine(reader.ReadChar());
                Console.WriteLine(reader.ReadChar());
                Console.WriteLine(reader.ReadChar());
                Console.WriteLine(reader.ReadChar());
                Console.WriteLine(reader.ReadInt32());
                Console.WriteLine(reader.ReadDouble());
            }

        }
    }
}
