using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Digital root is the recursive sum of all the digits in a number.
 * Given n, take the sum of the digits of n. If that value has more than one digit, 
 *     continue reducing in this way until a single-digit number is produced. 
 * The input will be a non-negative integer.
 * 
 *  16  -->  1 + 6 = 7
 *  942  -->  9 + 4 + 2 = 15  -->  1 + 5 = 6
 *  132189  -->  1 + 3 + 2 + 1 + 8 + 9 = 24  -->  2 + 4 = 6
 *  493193  -->  4 + 9 + 3 + 1 + 9 + 3 = 29  -->  2 + 9 = 11  -->  1 + 1 = 2
 */
namespace code_wars
{
    internal static class _6_kyu_digital_root
    {
        public static int DigitalRoot(long number)
        {
            int result = 0;
            string numberStr = number.ToString();
            
            foreach (char character in numberStr)
            {
                int digit = Convert.ToInt32(character.ToString());
                result += digit;
            }
            int resultLength = result.ToString().Length;

            if (resultLength > 1)
            {
                return DigitalRoot(result);
            }
            return result;
        }
    }
}
