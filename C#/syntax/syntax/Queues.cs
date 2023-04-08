using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace syntax
{
    internal static class Queues
    {
        internal static void Main__()
        {
            Utilities utility = new Utilities();
            utility.Title("QUES");
            
            // Queues - first in first out.
            Queue myQueue = new Queue();
            
            // Add new items into queue.
            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);
            myQueue.Enqueue("heeyy"); // It is possible to have different datatypes inside queue at the same time.
            
            // Iterate over queue.
            foreach (var item in myQueue)
            {
                Console.WriteLine(item);
            }

            utility.Separator();
            
            Console.WriteLine(myQueue.Contains(1));
            Console.WriteLine(myQueue.Dequeue()); // Removes and returns first element that was added to queue.
            Console.WriteLine(myQueue.Peek()); // Returns object at the beginning without removing it.

            utility.Separator();

            object[] someArray = myQueue.ToArray(); // Convert queue into an array.
            Console.WriteLine(String.Join(separator: ", ", values: someArray));



        }
    }
}
