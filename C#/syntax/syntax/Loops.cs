using System;
using System.Collections.Generic;
using System.Linq;
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
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Iteration number {i}");
            }
            Console.WriteLine("\n");

            // seems like the "i" variable is local to each for loop
            int[] some_numbers = { 10, 20, 30, 40 };
            for (int i = 0; i < some_numbers.Length; i++)
            {
                Console.WriteLine($"Item: {some_numbers[i]}");
            }
            Console.WriteLine("\n");


            // FOR EACH
            // Iterates through a container, while having the current item at a given index
            //  available for you.
            string[] cars = { "Volvo", "BMW", "Ford", "Mazda" };
            foreach (string car in cars)
            {
                Console.WriteLine(car);
            }

            utility.Separator();
        }
    }
}
