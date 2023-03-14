using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Format an array of numbers into format below:
 * 
 * Kata.CreatePhoneNumber(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 0})
 * => returns "(123) 456-7890"
 * 
 */

namespace code_wars
{
    internal static class _6_kyu_create_phone_number
    {
        internal static string CreatePhoneNumber(int[] n)
        {
            return $"({n[0]}{n[1]}{n[2]}) {n[3]}{n[4]}{n[5]}-{n[6]}{n[7]}{n[8]}{n[9]}";

        }
    }
}
