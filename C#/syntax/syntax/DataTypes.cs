using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace syntax
{
    internal static class DataTypes
    {
        internal static void Main__()
        {
            Utilities utility = new Utilities();

            utility.Title("DATATYPES");

            string some_phrase = "This is just some sentence";
            char some_character = 'a';  // single qoutes necessary for char type
            int some_integer = 1;
            float some_float = 3.4f; // have to append the f letter?
            double some_double = 4.5555555555;
            bool some_boolean = false;

            Console.WriteLine(some_phrase);
            Console.WriteLine(some_character);
            Console.WriteLine(some_integer);
            Console.WriteLine(some_float);
            Console.WriteLine(some_double);
            Console.WriteLine(some_boolean);

            utility.Separator();

        }
    }
}
