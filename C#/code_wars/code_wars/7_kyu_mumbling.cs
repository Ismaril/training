using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * accum("abcd") -> "A-Bb-Ccc-Dddd"
 * accum("RqaEzty") -> "R-Qq-Aaa-Eeee-Zzzzz-Tttttt-Yyyyyyy"
 * accum("cwAt") -> "C-Ww-Aaa-Tttt"
 * 
 * The parameter of accum is a string which includes only letters from a..z and A..Z.
 */

namespace code_wars
{
    public static class _7_kyu_mumbling
    {
        public static string Accum(string s)
        {
            string result = string.Empty;

            for (int i  = 0; i < s.Length; i++)
            {
               for (int j = 0;j < i+1; j++)
                {
                    string letter = s.Substring(startIndex: i, length: 1);
                    if (j == 0)
                    {
                        result += letter.ToUpper();
                    }
                    else
                    {
                    result += letter.ToLower();
                    }
                }
                result += "-";
            }
            return result.Substring(startIndex: 0, length: result.Length-1);
        }
    }
}
