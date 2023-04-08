using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax
{
    internal static class Stacks
    {
        internal static void Main__()
        {
            Utilities utility = new Utilities();
            utility.Title("QUES");

            // Stack - last in, first out.
            Stack<int> myStack = new Stack<int>();
            
            myStack.Push(1); // Add new item inside.
            myStack.Push(2);
            myStack.Push(3);
            Console.WriteLine(myStack);
            
            // Notice, that it iterates over stack in order as the items were inserted. (From last to first)
            foreach (int item in myStack)
            {
                Console.WriteLine(item);
            }

            utility.Separator();

            Console.WriteLine($"Peek: {myStack.Peek()}"); // Return object at the top of stack without removing it.
            Console.WriteLine($"Pop: {myStack.Pop()}"); // Remove and return last item in stack. Just like in python. 
            Console.WriteLine(myStack.Contains(3)); // True if it contains that. 
            foreach (int item in myStack)
            {
                Console.WriteLine(item);
            }

            int[] myArray = myStack.ToArray(); // Convert stack to an array. 
            Console.WriteLine(myArray);
        }
    }
}
