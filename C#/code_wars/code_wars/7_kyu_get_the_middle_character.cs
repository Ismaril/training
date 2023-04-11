using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* Return the middle character of string:
 * 
 * "prd" -> 'r'
 * "look" -> "oo"
 * 
 */


namespace code_wars
{
    internal static class _7_kyu_get_the_middle_character
    {
        public static string GetMiddle(string s)
        {
            
            if (s.Length % 2 == 0)
            {
                return s.Substring(startIndex: s.Length / 2 - 1, length: 2);
            }
            decimal middlechar = Math.Floor((decimal)s.Length / 2 + 1);
            return Convert.ToString(s.Substring(startIndex: (int)middlechar - 1, length: 1)); 
        }        
    }
}
