using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code_wars
{
    public static class _7_kyu_youre_a_square
    {
        public static bool IsSquare(int number)
        {
            if (number < 0) return false;

            double result = Math.Sqrt((double)number);
            if (Math.Floor((decimal)result) == (decimal)result ) return true;
            else return false;
        }
    }
}
