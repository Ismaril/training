using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
Your task is to make a function that can take any non-negative integer as an argument
and return it with its digits in descending order. Essentially, rearrange the digits
to create the highest possible number.

Input: 42145 Output: 54421
Input: 145263 Output: 654321
Input: 123456789 Output: 987654321
*/
namespace code_wars
{
    internal static class _7_kyu_descending_order
    {
        public static int DescendingOrder(int num)
        {
            string numbers_concatenated = "";
            string num_str = num.ToString(); // convert to string
            int[] int_array = new int[num_str.Length];


            for (int i = 0; i < num_str.Length; i++)
            {
                // First converts Char into String and then into Int.
                int number = int.Parse(num_str[i].ToString());

                // Asign new value to a specified index
                int_array[i] = number;
            }

            Array.Sort(int_array);
            Array.Reverse(int_array);

            for (int i = 0;i < int_array.Length; i++)
            {
                // append string into existing one
                numbers_concatenated += Convert.ToString(int_array[i]);
            }
            return Convert.ToInt32(numbers_concatenated);
        }
    }
}
