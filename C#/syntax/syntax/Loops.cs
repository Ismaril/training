using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace syntax
{
    internal static class Loops
    {
        internal static void Main__()
        {

            Utilities utility = new Utilities();
            utility.Title("LOOPS");

            // WHILE LOOP, DO WHILE LOOP, FOR LOOP
            // WHILE LOOP - checks the condition and then continues with code or it breaks
            int index1 = 0;
            while (index1 <= 4)
            {
                Console.WriteLine($"The index is {index1}");
                index1++;
            }
            Console.WriteLine("\n");

            // DO WHILE LOOP - executes the code and then checks the condition
            int index2 = 0;
            do
            {
                Console.WriteLine($"The index is {index2}");
                index2++;
            }
            while (index2 <= 4);
            Console.WriteLine("\n");

            // FOR LOOP
            /* Statement 1 is executed (one time) before the execution of the code block.
             * Statement 2 defines the condition for executing the code block.
             * Statement 3 is executed(every time) after the code block has been executed.
             *
             * for (statement 1; statement 2; statement 3) 
             * { 
             *     // code block to be executed
             * }
             */
            
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Iteration number {i}");
            }
            Console.WriteLine("\n");

            // "i" variable is local to each for loop
            int[] some_numbers = { 10, 20, 30, 40 };
            for (int i = 0; i < some_numbers.Length; i++)
            {
                Console.WriteLine($"Item: {some_numbers[i]}");
            }
            Console.WriteLine("\n");


            // FOR EACH
            // Iterates through a container, while having the current item at a given index
            //  available for you.
            // foreach (type variableName in arrayName)
            // {
            //     // code block to be executed
            // }

            string[] cars = { "Volvo", "BMW", "Ford", "Mazda" };
            foreach (string car in cars)
            {
                Console.WriteLine(car);
            }


            // NESTED LOOPS
            // Outer loop
            for (int i = 1; i <= 2; ++i)
            {
                Console.WriteLine("Outer: " + i);  // Executes 2 times

                // Inner loop
                for (int j = 1; j <= 3; j++)
                {
                    Console.WriteLine(" Inner: " + j); // Executes 6 times (2 * 3)
                }
            }

            // BREAK    (keyword) - breakes completely out of loop
            // CONTINUE (keyword) - skips to the next iteration of loop

            utility.Separator();
        }
    }
}
