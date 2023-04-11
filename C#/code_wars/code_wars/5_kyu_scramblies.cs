using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
