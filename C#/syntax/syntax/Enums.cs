using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace syntax
{
    internal static class Enums
    {
        // Why And When To Use Enums?:
        // Use enums when you have values that you know aren't going to change,
        //  like month days, days, colors, deck of cards, etc.

        // Enum is short for "enumerations", which means "specifically listed".
        // An enum is a special "class" that represents a group of constants (unchangeable/read-only variables).
        // To create an enum, use the enum keyword (instead of class or interface),
        //  and separate the enum items with a comma:
        enum Level
        {
            Low,
            Medium,
            High
        }

        // By default, the first item of an enum has the value 0. The second has the value 1, and so on.
        // To get the integer value from an item, you must explicitly convert the item to an int:
        enum Months
        {
            January,    // 0
            February,   // 1
            March,      // 2
            April,      // 3
            May,        // 4
            June,       // 5
            July        // 6
        }

        // You can also assign your own enum values, and the next items will update their numbers accordingly:
        enum Months_2
        {
            January,    // 0
            February,   // 1
            March = 6,    // 6
            April,      // 7
            May,        // 8
            June,       // 9
            July        // 10
        }


        internal static void Main__()
        {

            Utilities utility = new Utilities();
            utility.Title("ENUMS");

            // Enums are often used in switch statements to check for corresponding values:
            Level myVar = Level.Medium;
            switch (myVar)
            {
                case Level.Low:
                    Console.WriteLine("Low level");
                    break;
                case Level.Medium:
                    Console.WriteLine("Medium level");
                    break;
                case Level.High:
                    Console.WriteLine("High level");
                    break;
            }

            // Access values from already created enum.
            int myNum = (int) Months.April; // Access index
            int myNum2 = (int) Months_2.July; // Access idnex
            Months month = Months.January; // Acess actual text

            Console.WriteLine(myNum);
            Console.WriteLine(myNum2);
            Console.WriteLine(month);  

            utility.Separator();
        }
    }
}