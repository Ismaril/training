using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Complete the function scramble(str1, str2) that returns true if a portion of str1 characters can be rearranged to match str2, otherwise returns false.

Notes:

Only lower case letters will be used (a-z). No punctuation or digits will be included.
Performance needs to be considered.

scramble('rkqodlw', 'world') ==> True
scramble('cedewaraaossoqqyt', 'codewars') ==> True
scramble('katas', 'steak') ==> False
*/

namespace code_wars
{
    public class _5_kyu_scramblies
    {
        public static bool Scramble(string source, string expected)
        {
            string result = string.Empty; 

            foreach (char letter in expected)
            {
                if (source.Contains(letter))
                {
                    result += letter;
                    int letterIndex = source.IndexOf(letter);
                    source = source.Remove(startIndex: letterIndex, count: 1);
                }
                else if (!source.Contains(letter))
                {
                    return false;
                }
            }
            return expected == result;
        }
    }
}
