using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code_wars
{
    internal static class _8_kyu_even_or_odd
    {
        public static string EvenOrOdd(int number)
        {
            if (number % 2 == 0) return "Even";
            else return "Odd";

            // BEST PRACTISE:
            // return number % 2 == 0 ? "Even" : "Odd";

        }
    }
}
