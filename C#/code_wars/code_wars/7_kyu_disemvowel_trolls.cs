using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

/*
Trolls are attacking your comment section!
A common way to deal with this situation is to remove all of the
vowels from the trolls' comments, neutralizing the threat.
Your task is to write a function that takes a string and
return a new string with all vowels removed.
For example, the string "This website is for losers LOL!"
would become "Ths wbst s fr lsrs LL!".
Note: for this kata y isn't considered a vowel.
*/

namespace code_wars
{
    internal static class _7_kyu_disemvowel_trolls
    {
        public static string Disemvowel(string user_input)
        {
            
            string result = "";
            for (int i = 0; i < user_input.Length; i++)
            {
                if (user_input[i] == 'a'
                    || user_input[i] == 'e'
                    || user_input[i] == 'i'
                    || user_input[i] == 'o'
                    || user_input[i] == 'u'
                    || user_input[i] == 'A'
                    || user_input[i] == 'E'
                    || user_input[i] == 'I'
                    || user_input[i] == 'O'
                    || user_input[i] == 'U')
                {
                    continue;
                }
                result += user_input[i];
            }
            return result;
        }
    }
}
