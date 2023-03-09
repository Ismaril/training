using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax
{
    internal static class Arrays
    {
        internal static void Main__()
        {
            Utilities utility = new Utilities();
            utility.Title("ARRAYS");

            // Create an array with int types.
            int[] lucky_numbers = { 1, 2, 3, 4, 5, 6 };
            Console.WriteLine(lucky_numbers[0]); // print first index
            Console.WriteLine(lucky_numbers[1]); // print second index

            lucky_numbers[2] = 300;  // asign new value to a specified index
            Console.WriteLine(lucky_numbers[2]);

            // Create an array where you do not assign variables right away but later.
            // Here we specify, that the array will get maximally 3 items.
            string[] names = new string[3];
            names[0] = "John";
            names[1] = "Don";
            names[2] = "Dylan";
            Console.WriteLine(names[0] + "\n");

            // Crate an array where you specify only dimensions, and will insert values later.
            int[] someRandomArray = new int[3];
            someRandomArray[0] = 10;

            utility.Separator();

            // 2D ARRAYS
            // Use comma to indicate 2D array.
            int[,] twodArray = {
                { 10, 20, 30, 40},
                { 100, 200, 300, 400}
            };

            // container.Length - gets length across all dimensions
            // container.Getlength(dimension) - gets length of specified dimension
            for (int i = 0; i < twodArray.GetLength(0); i++)
            {
                for (int j = 0; j < twodArray.GetLength(1); j++)
                {
                    Console.WriteLine(twodArray[i, j]);
                }
            }
            utility.Separator();

        }
    }
}
