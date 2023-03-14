using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Welcome. In this kata, you are asked to square every digit of a number and concatenate them.

For example, if we run 9119 through the function, 811181 will come out, because 92 is 81 and 12 is 1. (81-1-1-81)

Example #2: An input of 765 will/should return 493625 because 72 is 49, 62 is 36, and 52 is 25. (49-36-25)

Note: The function accepts an integer and returns an integer.
*/


namespace code_wars
{
    internal static class _7_kyu_digit_x_digit
    {
        public static int SquareDigits(int number)
        {
            string numberString = Convert.ToString(number);
            string result = "";

            for (int i = 0; i < numberString.Length; i++)
            {
                // Seems like numberString[i] returns only a 'Char' type and
                //  has to be converted into 'String' in order to get the correct
                //  coversion of number into int. When I used just Covert to string,
                //  it returned some nonsensical number. 
                // When checked with others, int.Parse(xxx.ToString()) has to be really
                //  used.
                int digit = int.Parse(numberString[i].ToString());
                int squared_digit = digit*digit;
                result += squared_digit; // it is possible to append integer into string
            }

            return Convert.ToInt32(result);
        }
    }
}
