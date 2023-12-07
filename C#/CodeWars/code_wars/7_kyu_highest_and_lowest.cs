using System;
using System.Linq;


/*
In this little assignment you are given a string of space separated numbers,
and have to return the highest and lowest number.

Kata.HighAndLow("1 2 3 4 5");  // return "5 1"
Kata.HighAndLow("1 2 -3 4 5"); // return "5 -3"
Kata.HighAndLow("1 9 3 4 -5"); // return "9 -5"

All numbers are valid Int32, no need to validate them.
There will always be at least one number in the input string.
Output string must be two numbers separated by a single space, and highest number is first.
*/
namespace code_wars
{
    internal static class _7_kyu_highest_and_lowest
    {
        public static string HighAndLow(string numbers)
        {
            // Split string into an array of strings,
            //  it is splited based on whitespace in original string.
            string[] stringArray = numbers.Split(' ');

            // Prepare new array for integers only.
            int[] integerArray = new int[stringArray.Length];


            for (int i = 0; i < stringArray.Length; i++)
            {
                // convert to int
                int numberConverted = Convert.ToInt32(stringArray[i]);

                // assign new values to integerArray
                integerArray[i] = numberConverted;
            }

            return $"{integerArray.Max()} {integerArray.Min()}";

            // BEST PRACTISE:
            // var parsed = numbers.Split().Select(int.Parse);
            // return parsed.Max() + " " + parsed.Min();
        }
    }
}
