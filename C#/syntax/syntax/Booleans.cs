using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax
{
    internal static class Booleans
    {
        internal static void Main__()
        {
            Utilities utility = new Utilities();
            utility.Title("BOOLEANS");

            bool isCSharpFun = true;
            bool isEarthFlat = false;
            Console.WriteLine(isCSharpFun);   // Outputs True
            Console.WriteLine(isEarthFlat);   // Outputs False


            // Boolean expression
            int myAge = 25;
            int votingAge = 18;
            Console.WriteLine(myAge >= votingAge);  // Outputs True

            Console.WriteLine(10 == 15); // returns False, because 10 is not equal to 15

            utility.Separator();
        }
    }
}
