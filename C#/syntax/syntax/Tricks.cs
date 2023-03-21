using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax
{
    internal static class Tricks
    {
        internal static void Trick()
        {
            // CHANGE COLOR OF CMD TEXT AND BACKGROUND.
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            // Just a name of block as a printed output into console.
            Utilities utility = new Utilities();
            utility.Title("TRICKS");


            // IT IS POSSIBLE TO ASSIGN INTEGER DIRECTLY INTO STRING.
            string someString = "";
            someString += 5;
            Console.WriteLine(someString);

            utility.Separator();


            // PARSING DATATYPES
            // Parse method accepts string parameter.
            bool boolFromString = bool.Parse("true");
            Console.WriteLine(boolFromString is true);

            int intFromString = int.Parse("3000");
            Console.WriteLine(intFromString == 3000);

            // Note that when parsing number with decimal point, you have to use ',' instead
            //  of '.' in a parsed string.
            double doubleFromString = double.Parse("1,234"); 
            Console.WriteLine(doubleFromString);

            utility.Separator();


            // CREATING NEW VARIABLES
            double myNumDouble = 4.5080D;
            int muNumInt = (int)myNumDouble;
            Console.WriteLine(muNumInt);
        }
    }
}

