using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code_wars
{
    internal class _6_kyu_multiples_of_3_and_5
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
