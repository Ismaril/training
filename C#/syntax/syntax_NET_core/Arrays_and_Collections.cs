using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax_NET_core
{
    internal class Arrays_and_Collections
    {
        public static void Main__()
        {
            var utilities = new Utilities();
            utilities.PrintLine();


            Stopwatch stopwatch = new();
            Console.WriteLine("Started counting");
            stopwatch.Start();

            // See an example of inefficient way of enlarging an array.
            // It has to copy the whole array to a new array every time it is resized.
            int[] myArray = new int[1];
            for (int i = 0; i < 100_000; i++)
            {
                Array.Resize(
                    array: ref myArray,
                    newSize: myArray.Length + 1
                    );
            }

            stopwatch.Stop();
            Console.WriteLine("Stopped counting");
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
            stopwatch.Reset();


            utilities.PrintLine();


            Console.WriteLine("Started counting");
            stopwatch.Start();

            // See an example of efficient way of enlarging an array.
            // Generic use of types in Class<yourType>.
            var myList = new List<int>();
            for (int i = 0; i < 100_000; i++)
            {
                myList.Add(0);
            }

            stopwatch.Stop();
            Console.WriteLine("Stopped counting");
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
            stopwatch.Reset();


            utilities.PrintLine();


            // Generic use of types in Class<yourType>.
            var myQueue = new Queue<string>();
            myQueue.Enqueue("First");
            myQueue.Enqueue("Second");
            myQueue.Enqueue("Third");
            Console.WriteLine(myQueue.Dequeue());  // First in, first out.
            Console.WriteLine(myQueue.Dequeue());  // First in, first out.
            Console.WriteLine(myQueue.Peek());  // Only peeking at next item, not removing.
            Console.WriteLine(myQueue.Peek());  // Only peeking at next item, not removing.

            utilities.PrintLine();

            foreach (var item in myQueue)
                Console.WriteLine(item);

            utilities.PrintLine();


            // Generic use of types in Class<yourType>.
            var myStack = new Stack<string>();
            myStack.Push("First");
            myStack.Push("Second");
            myStack.Push("Third");
            Console.WriteLine(myStack.Pop());  // Last in, first out.
            Console.WriteLine(myStack.Pop());  // Last in, first out.
            Console.WriteLine(myStack.Peek());  // Only peeking at next item, not removing.
            Console.WriteLine(myStack.Peek());  // Only peeking at next item, not removing.

            utilities.PrintLine();

            foreach (var item in myStack)
                Console.WriteLine(item);


            utilities.PrintLine();


            // Generic use of types in Class<yourType, yourType>.
            var myDictionary = new Dictionary<string, int>();
            myDictionary.Add("First", 1);
            myDictionary.Add("Second", 2);
            myDictionary.Add("Third", 3);
            Console.WriteLine(myDictionary["First"]);  // Get the value of the key.

            // You can iterate through the dictionary with foreach loop and access both key and value.
            foreach(KeyValuePair<string, int> item in myDictionary)
                Console.WriteLine(item.Key + " " + item.Value);


            utilities.PrintLine();

            var myDictionaryOfTrainingIDs = new Dictionary<TrainingID, string>
            {
                { new TrainingID("A", 1), "First" },
                { new TrainingID("B", 2), "Second" },
                { new TrainingID("C", 3), "Third" }
            };

            // In order for this to work, you need to override Equals and GetHashCode methods in the class,
            //   because when lookin for a key, in this dictionary, you use a class. And when you want to compare
            //   two objects of a class, you need to override Equals and GetHashCode methods. Also, in order for
            //   GetHashCode to work, you need to override ToString method, because you want to get the hash code
            //   of the string representation of the object fields (for example). I tryied to compare two objects
            //   just based on plain GetHaschode, but the hash was different for the objects with the same values.
            //   It is really necessary to specify yourself how to construct the hash code in the GetHashCode method.
            Console.WriteLine(myDictionaryOfTrainingIDs[new TrainingID("A", 1)]);  // Get the value of the key.

        }


        class TrainingID
        {
            public string Prefix;
            public int Code;

            public TrainingID(string prefix, int code)
            {
                Prefix = prefix;
                Code = code;
            }

            public override string ToString()
            {
                return Prefix + Code;
            }

            public override bool Equals(object? obj)
            {
                TrainingID? temp = obj as TrainingID;
                return temp.Prefix == Prefix && temp.Code == Code;
            }

            public override int GetHashCode()
            {
                return ToString().GetHashCode();
            }
        }
    }
}
