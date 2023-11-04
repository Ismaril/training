using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax_NET_core
{
    internal static class Index_and_Range_Operator
    {
        public static void Main__()
        {
            Utilities utilities = new();
            utilities.PrintLine();

            string text = "ABCDEFGH";

            // INDEX OPERATOR
            // Get the first character.
            Console.WriteLine(text[0]);

            // Get the last character.
            Console.WriteLine(text[text.Length - 1]); // Old syntax.
            Console.WriteLine(text[^1]); // New syntax.

            // Get the second last character.
            Console.WriteLine(text[^2]);

            utilities.PrintLine();

            // RANGE OPERATOR
            // Get the first 3 characters.
            // Last index does not count just like in python.
            Console.WriteLine(text[new Range(1, 3)]); // Old syntax.
            Console.WriteLine(text[1..3]); // New syntax.

            // Get complete string.
            Console.WriteLine(text[0..^1]);

            // Get the last 2 characters.
            Console.WriteLine(text[^2..^0]);
        }
    }
}
