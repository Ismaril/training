using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax
{
    internal class Strings
    {
        internal static void Main__()
        {
            Utilities utility = new Utilities();

            utility.Title("STRINGS");


            // Escape characters:
            // \  - makes the following character just string (general explanation)
            // \n - new line
            // \t - tab
            // \b - backspace
            // \' - single qoute
            // \" - double qoute
            // \\ - backslash
            // @ - (verbatim) = the string will be taken literally -> @"Hello\n" -> prints: Hello\n

            Console.WriteLine("Escape characters:\n" +
                "New line \n" +
                "Tab \t some text\n" +
                "Single qoute is possible without backslash'\n" +
                "Backslash has to be used with another backlash \\ \n" +
                "And so on...\n");

            // possible to concatenate during assignement to variable
            string some_sentence = "First sentence " + "Second sentence";
            Console.WriteLine(some_sentence);

            // STRING METHODS
            // todo: make the list of methods complete
            string some_string = "Mazooon je veliky";
            Console.WriteLine(some_string.Length);  // length of string (number of characters)
            Console.WriteLine(some_string.ToLower());
            Console.WriteLine(some_string.ToUpper());
            Console.WriteLine(some_string.EndsWith("iky"));      // returns True/False
            Console.WriteLine(some_string.StartsWith("Mazoo"));  // returns True/False
            Console.WriteLine(some_string.StartsWith("M"));      // returns True/False
            Console.WriteLine(some_string.Contains("veliky"));   // returns True/False
            Console.WriteLine(some_string[0]); // return first character of string

            utility.Separator();

            // Trim characters
            // Removes all leading and trailing occurences.
            char[] unwantedCharacters = { '1', '2', '3', '*' };
            Console.WriteLine("12Bla*bla333".Trim(unwantedCharacters));

            // Pad strings
            Console.WriteLine(some_string.PadLeft(totalWidth: 30, paddingChar: '#'));
            Console.WriteLine(some_string.PadRight(totalWidth: 30, paddingChar: '#'));

            // Insert new string, starting at given index.
            Console.WriteLine(some_string.Insert(startIndex: 11, value: "tak "));

            // Replace a part of string with new part
            Console.WriteLine(some_string.Replace(oldValue: "je", newValue: "neni"));

            // Compare strings
            // If returned 0, both strings are equal.
            // This method is designed to produce a total-order comparison that can be used for sorting.
            Console.WriteLine(String.Compare(strA: "HELLO", strB: "hello", ignoreCase:true)) ;

            // Check if strings are equal
            Console.WriteLine(String.Equals(objA:"A", objB: "A"));

            // Remove the part from string starting at specified index and based on specified length
            //  (count)
            // If the removed string was inside the original string, the remaining characters will
            //  be appended together.
            Console.WriteLine(some_string.Remove(startIndex:7, count: 8));

            // Returns a substring starting from the index position you specified.
            Console.WriteLine(some_string.Substring(8));

            // You can also specify a length of string which you want to return.
            // Here it means that it will return 2 charcaters starting from index 8.
            Console.WriteLine(some_string.Substring(8, 2));

            // Returns index of first occurence, if it does not find the letter, -1 will
            //  be returned.
            Console.WriteLine(some_string.IndexOf("o"));

            utility.Separator();


            // STRING FORMATTING
            // All of these do the same thing.
            Console.WriteLine($"{some_string} blablabla {1} {100}");
            Console.WriteLine(some_string + " " + "blablabla" + " " + "1" + " " + "100");
            Console.WriteLine("{0} blablabla {1} {2}", some_string, 1, 100);

            Console.WriteLine("{0:c}", 45.345); // convert to currency $
            Console.WriteLine("{0:d4}", 30);  // add zeros as padding from left (number of all digits will be 4 here)
            Console.WriteLine("{0:f3}", 23.34666); // return number with 3 numbers after dot. Last number will be rounded.

            utility.Separator();

        }
    }
}
