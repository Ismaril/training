using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*Write a function that takes in a string of one or more words, and returns the same string, but with all five or more letter words reversed (Just like the name of this Kata). Strings passed in will consist of only letters and spaces. Spaces will be included only when more than one word is present.*/

/*
 * spinWords( "Hey fellow warriors" ) => returns "Hey wollef sroirraw" 
 * spinWords( "This is a test") => returns "This is a test" 
 * spinWords( "This is another test" )=> returns "This is rehtona test"
 */
namespace code_wars
{
    public class _6_kyu_spin_words
    {
        public static string SpinWords(string sentence)
        {
            List<string> wordsOriginal = new List<string>(sentence.Split());
            List<string> wordsReversed = new List<string>();


            foreach (string word in wordsOriginal)
            {
                if (word.Length >= 5)
                {
                    char[] chars = word.ToCharArray(); // String needs to be converted to character array before reversing it.
                    Array.Reverse(chars);
                    string wordReversed = new string(chars);
                    wordsReversed.Add(wordReversed);
                }
                else { wordsReversed.Add(word); }

            }
            
            return String.Join(separator: " ", values: wordsReversed);
;
        }
    }
}
