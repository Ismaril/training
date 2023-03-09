using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax
{
    internal static class Variables
    {
        internal static void Main__()
        {
            Utilities utility = new Utilities();

            utility.Title("VARIABLES");


            string character_name = "Tom";
            int character_age;
            character_age = 30; // see that it is possible to asign value later
            Console.WriteLine($"There once was a {character_name}."); // fstrings
            Console.WriteLine($"And he was {character_age} years old."); // fstrings
                                                                         // it is possible to also concatenate strings with '+' sign.
            Console.WriteLine("The name is " + character_name + " and he's a human.");

            character_age = 31;
            Console.WriteLine($"A year has passed and now his age is {character_age}");

            // possible to assign in one row
            // todo: check if it is possible without brackets
            var (color, height, width) = ("red", "tall", "narrow");
            Console.WriteLine((color, width, height));

            int x = 5, y = 3, z = 6;
            Console.WriteLine(x + y + z);

            utility.Separator();
        }

    }
}
