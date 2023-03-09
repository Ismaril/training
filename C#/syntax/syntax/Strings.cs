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
            // \n - new line
            // \t - tab
            // \ - make the following character just string

            Console.WriteLine("Escape characters:\n" +
                "New line \n" +
                "Tab \t some text\n" +
                "Single qoute is possible without backslash'\n" +
                "Backslash has to be used with another backlash \\ \n" +
                "And so on...\n");

            // possible to concatenate during assignement to variable
            string some_sentence = "First sentence " + "Second sentence";
            Console.WriteLine(some_sentence);

            // check lenth of string
            Console.WriteLine($"String length: {some_sentence.Length}");

            // STRING METHODS
            string some_string = "Mazooon je veliky";
            Console.WriteLine(some_string.ToLower());
            Console.WriteLine(some_string.ToUpper());
            Console.WriteLine(some_string.EndsWith("iky"));
            Console.WriteLine(some_string.StartsWith("Mazoo"));
            Console.WriteLine(some_string.StartsWith("M"));
            Console.WriteLine(some_string.Contains("veliky"));
            Console.WriteLine(some_string[0]); // return first character of string
            Console.WriteLine(some_string[1]);

            // Returns a substring starting from the index position you specified.
            Console.WriteLine(some_string.Substring(8));

            // You can also specify a length of string which you want to return.
            // Here it means that it will return 2 charcaters starting from index 8.
            Console.WriteLine(some_string.Substring(8, 2));

            // Returns index of first occurence, if it does not find the letter, -1 will
            //  be returned.
            Console.WriteLine(some_string.IndexOf("o"));

            utility.Separator();
        }
    }
}
