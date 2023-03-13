using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code_wars
{
    internal class _6_kyu_create_phone_number
    {
        internal static string CreatePhoneNumber(int[] n)
        {
            return $"({n[0]}{n[1]}{n[2]}) {n[3]}{n[4]}{n[5]}-{n[6]}{n[7]}{n[8]}{n[9]}";

        }
    }
}
