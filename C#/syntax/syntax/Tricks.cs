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
        Utilities utility = new Utilities();
        utility.Title("TRICKS");

        // It is possible to assign integer directly into string.
        string someString = "";
        someString += 5;
        Console.WriteLine(someString);

        utility.Separator();
        }
    }
}

