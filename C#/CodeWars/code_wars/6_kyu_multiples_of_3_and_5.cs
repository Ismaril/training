using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * If we list all the natural numbers below 10 that are multiples of 3 or 5,
 * we get 3, 5, 6 and 9. The sum of these multiples is 23. Finish the solution 
 * so that it returns the sum of all the multiples of 3 or 5 below the number passed in.
 * Additionally, if the number is negative, return 0 (for languages that do have them).
 * Note: If the number is a multiple of both 3 and 5, only count it once.
 */


namespace code_wars
{
    internal static class _6_kyu_multiples_of_3_and_5
    {
        public static int Solution(int value)
        {
            int result = 0;
            for (int i = 0; i < value; i++)
            {
                result += i % 3 == 0 || i % 5 == 0 ? i : 0;
            }

            return result;
        }
    }
}
