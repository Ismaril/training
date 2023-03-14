using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

/*
 * Write a function, persistence, that takes in a positive parameter num and returns 
 * its multiplicative persistence, which is the number of times you must multiply the digits 
 * in num until you reach a single digit.
 * 
 * 
 * 39 --> 3 (because 3*9 = 27, 2*7 = 14, 1*4 = 4 and 4 has only one digit)
 * 999 --> 4 (because 9*9*9 = 729, 7*2*9 = 126, 1*2*6 = 12, and finally 1*2 = 2)
 * 4 --> 0 (because 4 is already a one-digit number)
 * 
 */

namespace code_wars
{
    internal static class _6_kyu_persistent_bugger
    {
        internal static int counter = 0;

        internal static int Persistence(long n)
        {
            char[] arr = n.ToString().ToCharArray(); // make an array of characters
            int temporaryResult = 1;

            if (arr.Length == 1)
            {
                // set counter to 0, because when calling the class again, it still
                // remembers the value from previous call (I think it is due to being static)
                int result = counter;
                counter = 0;  
                return result;
            }
            else
            {
                foreach ( char c in arr )
                {
                    temporaryResult *= int.Parse(c.ToString());
                }
                counter++;

                // Recursion
                return Persistence(temporaryResult);
            }

        }
    }
}
