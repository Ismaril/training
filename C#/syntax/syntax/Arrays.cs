using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
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


            // WHERE
            // Specify a condition which is going to filter out the array.
            int[] someBinary = { 1, 0, 0, 1, 1, 1 };
            // Apply lambda function which is gonna check if number is equal to 1 or 0, then convert it
            //  to list, and then count the number of elements which met the condition.
            Console.WriteLine(someBinary.Where(number => number == 1).ToList().Count());
            Console.WriteLine(someBinary.Where(number => number == 0).ToList().Count());
            

            // SELECT
            // Specify a function that is going to perform an operation on each element in an array
            int[] someRangeOfnrs = { 1, 2, 3, 4 };
            int[] squared = someRangeOfnrs.Select(x => x * x).ToArray(); 
            // should return {1, 4, 9, 16}


            // ZIP  
            // Applies a function to two arrays.
            int[] arr1 = { 1, 2, 3, 4 };
            int[] arr2 = { 1, 1, 1, 0 };
            int[] zippedAndAdded = arr1.Zip(arr2, (x, y) => x + y).ToArray();
            // If you just want to zip it:
            var justZipped = arr1.Zip(arr2, (x, y) => (x, y)).ToArray();


            // AGGREGATE
            // Use to perform accumulation operations accross an array
            arr1.Aggregate((total, next) => total + next); // Sum all items.


            // ANY method
            string strWithDigits = "Hello5";
            if (strWithDigits.Any(char.IsDigit)) // Returns true if any character in that string is digit
            {
                Console.WriteLine("String has digits in it.");
            }

            // ALL method
            if (strWithDigits.All(char.IsDigit)) // Returns true if all characters in that string are digits.
            {
                Console.WriteLine(true);
            }

            // DISTINCT
            // Select only unique items in array. Here is also used Join method, because Distinct returns only Distinct object.
            Console.WriteLine(String.Join("", strWithDigits.Distinct()));

            // EXCEPT
            // You can use this to filter out items from an array an return it.
            int[] listos = { 100, 200, 300, 300 };
            int[] listos2 = { 300 };
            Console.WriteLine(String.Join(", ", listos.Except(listos2)));
            
            // INTERSECT
            // Use this if you want to return items that are present in both arrays.
            Console.WriteLine(String.Join(", ", listos.Intersect(listos2)));
            

            // PRINT A COMPLETE ARRAY JUST LIKE IN PYTHON
            int[] myArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, };
            Console.WriteLine(String.Join(separator: ", ", values: myArray));

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

            utility.Separator();

            // ARRAY METHODS
            Array.Sort(cars_1); // (Sorts it inplace, returns nothing)
            Console.WriteLine($"Average: {arr1.AsQueryable().Average()}"); // Compute average of array

            // LINQ METHODS
            // https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/ef/language-reference/supported-and-unsupported-linq-methods-linq-to-entities

            utility.Separator();


            utility.Title("LIST"); 
            // ! ARRAYLIST is deprecated in favor of list. Use LIST instead. !
            // ARRAYLIST acts the same as list in Python. You can add different datatypes to the same array.
            //  Also you can perform many operations on that list such as sort, revers and many others...

            ArrayList myArrayList = new ArrayList();
            
            // Add new items into list.
            myArrayList.Add(1);
            myArrayList.Add(3);
            myArrayList.Add(2); 
            myArrayList.Add("hello");
            myArrayList.Add(null);
            myArrayList.Add("Matador");
            myArrayList.Add(true);
            // Add new items as a range:
            var someBSList = new List<int>();
            someBSList.AddRange(Enumerable.Range(1, 10));
            
            for (int i = 0; i < myArrayList.Count; i++)
            {
                Console.WriteLine($"Index: {i}, item: {myArrayList[i]}");    
            }
            
            myArrayList.Insert(index: 0, value: "Farks"); // Insert item at given index.
            myArrayList.RemoveAt(index: myArrayList.Count - 1); // Remove item at given index.

            utility.Separator();

            for (int i = 0; i < myArrayList.Count; i++)
            {
                Console.WriteLine($"Index: {i}, item: {myArrayList[i]}");    
            }          
            
            myArrayList.RemoveRange(index: 4, count: 3); // Remove number of items starting from some index.
            
            utility.Separator();

            for (int i = 0; i < myArrayList.Count; i++)
            {
                Console.WriteLine($"Index: {i}, item: {myArrayList[i]}");    
            }

            ArrayList myArrayList2 = new ArrayList();
            myArrayList2.Add(40);
            myArrayList2.Add(100);

            myArrayList.AddRange(myArrayList2); // Append list.
             for (int i = 0; i < myArrayList.Count; i++)
            {
                Console.WriteLine($"Index: {i}, item: {myArrayList[i]}");    
            }

            utility.Separator();
            utility.Title("LIST");

            List<object> myList = new List<object>();
            myList.Add(10);
            myList.Add(20);
            myList.Add(30);
            myList.Add("Meen");
            myList.Add(null);
            myList.Add(true);

            for (int i = 0; i < myList.Count;i++)
            {
                Console.WriteLine($"Index: {i}, Value: {myList[i]}");
            }
            
            utility.Separator();

            // It is possible to direcly assign new values:
            List<object> myList2 = new List<object>{100, 200, 300, "lalala", null, true, false};
            for (int i = 0; i < myList2.Count;i++)
            {
                Console.WriteLine($"Index: {i}, Value: {myList2[i]}");
            }



        }
    }
}
