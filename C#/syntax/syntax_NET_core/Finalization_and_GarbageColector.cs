// THIS FILE IS NOT COMPLETE. THERE IS A NEED TO ADD MORE EXAMPLES AND EXPLANATIONS.

namespace syntax_NET_core
{
    internal static class Finalization_and_GarbageColector
    {
        public static void Main__()
        {
            Utilities utilities = new();    
            utilities.PrintLine();

            MyFileStream myFileStream = new();

            // This code block is not really safe becuase if an exception is thrown
            //  between the Open and Close method calls, the file will not be closed.
            // Depending on the exception and how you have it handled program will either
            //  crash or continue to run. But the point is that the file will not be closed.
            myFileStream.Open();
            // Doing something with the file
            //throw new Exception("Something went wrong");
            myFileStream.Close();

            utilities.PrintLine();

            // Safer solution is to use the try-finally block.
            // This way the file will be closed even if an exception is thrown.
            // If you want to fully test this try-finally block, do not run it
            //  in the debugger. Run it without debugging (Ctrl + F5).
            // Uncomment the throw new Exception("Something went wrong");
            //  if you want to test it.
            try
            {
                myFileStream.Open();
                // Doing something with the file
                //throw new Exception("Something went wrong");
            }
            finally
            {
                if (myFileStream != null)
                    myFileStream.Close();
                Console.WriteLine("File closed using finally block");
            }

            utilities.PrintLine();

            // The best way to solve the problem with opening and closing the file
            //  is to use the using statement.
            // It work the same way as the try-finally block but it's shorter.
            // Run this also without debugging (Ctrl + F5) to fully test it.
            using (MyFileStream myFileStream2 = new())
            {
                myFileStream2.Open();
                // Doing something with the file
                //throw new Exception("Something went wrong");
            }

            utilities.PrintLine();

            // Even shorter way to use the using statement.
            using MyFileStream myFileStream3 = new();
            myFileStream3.Open();
            // Doing something with the file
            Console.WriteLine("Shortest syntax of using statement.");
            // throw new Exception("Something went wrong");


        }
    }

    // When working with streams etc, you must inherit from IDisposable
    //  and implement the Dispose method.
    class MyFileStream: IDisposable
    {
        public void Open()
        {
            Console.WriteLine("File opened");
        }

        // It is not uncommon to have both a Close and a Dispose method in a class.
        public void Close()
        {
            Dispose();
        }

        // This method is called when the object is disposed.
        // It's called when the using statement is used.
        public void Dispose()
        {
            Console.WriteLine("File closed");
        }
    }
}
