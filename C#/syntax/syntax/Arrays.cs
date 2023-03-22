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

            // dataType[] variableName = {x, y, z}
            // dataType[] variableName = new datatype[numberOfExpectedItemsInThisArray]

            // MULTIPLE POSSIBILITIES TO CREATE AN ARRAY:
            // Create an array of four elements, and add values later
            string[] cars = new string[4];

            // Create an array of four elements and add values right away 
            string[] cars_1 = new string[4] { "Volvo", "BMW", "Ford", "Mazda" };

            // Create an array of four elements without specifying the size 
            string[] cars_2 = new string[] { "Volvo", "BMW", "Ford", "Mazda" };

            // Create an array of four elements, omitting the new keyword, and without specifying the size
            string[] cars_3 = { "Volvo", "BMW", "Ford", "Mazda" };

            // Another way to create an array:
            Array emptyArray = Array.CreateInstance(elementType:typeof(int), length:10);

            // Create array where the datatypes are not the same.
            object[] hetero = { "Car", 200, 43.5 }; foreach (object o in hetero){Console.WriteLine(o.GetType());}

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

            // ARRAY METHODS
            Console.WriteLine(cars_1.Length);  // get number of items in an array
            Array.Sort(cars_1);
            Array.Reverse(cars_1);
            foreach (string car in cars_1){ Console.WriteLine(car);}    
            Console.WriteLine();

            // Set new value at a given index.
            cars_1.SetValue(value: "Skoda", index: 0);
            foreach (string car in cars_1) { Console.WriteLine(car);}
            Console.WriteLine();

            // Copies one array to another.
            cars_1.CopyTo(array: cars_2, index: 0);
            foreach (string car in cars_2) { Console.WriteLine(car); }

            utility.Separator();


            // 2D ARRAYS
            // Use comma to indicate 2D array. (Two commas 3D array, 3 commas 4D array, etc...)
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

            // 3D ARRAYS
            int[,,] some3DArray = new int[2, 2, 3] { { { 1, 2, 3 }, { 4, 5, 6 } },
                                                   { { 7, 8, 9 }, { 10, 11, 12 } } };
            Console.WriteLine(some3DArray[0, 1, 1]);
            some3DArray[0, 0, 0] = 100;
            Console.WriteLine(some3DArray[0, 0, 0]);


            // ARRAY METHODS
            Array.Sort(cars_1); // (Sorts it inplace, returns nothing)


            // LINQ METHODS
            // https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/ef/language-reference/supported-and-unsupported-linq-methods-linq-to-entities

            utility.Separator();

        }
    }
}
