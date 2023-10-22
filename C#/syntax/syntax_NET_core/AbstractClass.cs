using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax_NET_core
{
    internal static class AbstractClass
    {
        public static void Main__()
        {
            //var myStream = new Stream(); // Does not work, because Stream is abstract.

            Stream[] streams = { new FileStream(), new MemoryStream() };

            // The program can now work with any type of stream by taking advantage of the
            //  ability to map a specific stream to its ancestor, which is and abstract class.
            OpenStreams(streams);
            CloseStreams(streams);
        }

        static void OpenStreams(Stream[] streams)
        {
            foreach (var stream in streams)
            {
                stream.Open();
            }
        }

        static void CloseStreams(Stream[] streams)
        {
            foreach (var stream in streams)
            {
                stream.Close();
            }
        }

    }

    // Abstract classes are classes that cannot be instantiated.
    abstract class Stream
    {
        public void Close()
        {
            Console.WriteLine("Closing stream");
        }

        // This method is abstract, so it does not have a body.
        // It has to be overriden in the derived class.
        // Abstract method is virtual by default.
        public abstract void Open();

    }

    class FileStream : Stream
    {
        // Overriding the abstract method from the base class.
        public override void Open()
        {
            Console.WriteLine("Opening file stream");
        }
    }

    class MemoryStream : Stream
    {
        // Overriding the abstract method from the base class.
        public override void Open()
        {
            Console.WriteLine("Opening memory stream");
        }
    }
}
