using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Return the number (count) of vowels in the given string.
We will consider a, e, i, o, u as vowels for this Kata (but not y).
The input string will only consist of lower case letters and/or spaces.
*/

namespace code_wars
{
    internal static class _7_kyu_vowel_count
    {
        internal static int GetVowelCount(string usersInput)
        {
            int vowelCount = 0;

            for (int i = 0; i < usersInput.Length; i++)
            {
                switch (usersInput[i])
                {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'o':
                    case 'u':
                        vowelCount++;
                        break;
                }
            }

            return vowelCount;

            // BEST PRACTISE:
            // return str.Count(i => "aeiou".Contains(i));
        }
    }
}
