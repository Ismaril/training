using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

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
