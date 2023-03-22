using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace syntax
{
    internal static class Switch
    {
        internal static void Main__()
        {

            Utilities utility = new Utilities();
            utility.Title("SWITCH");

            // Use the switch statement to select one of many code blocks to be executed.
            // The switch expression is evaluated once.
            // The value of the expression is compared with the values of each case.
            // If there is a match, the associated block of code is executed.

            // When C# reaches a break keyword, it breaks out of the switch block.
            // This will stop the execution of more code and case testing inside the block.
            // When a match is found, and the job is done, it's time for a break.
            // A break can save a lot of execution time because it "ignores" the
            //  execution of all the rest of the code in the switch block.

            // The default keyword is optional and specifies some code to run if there is no case match.
            string textos = "1";
            switch (textos)
            {
                case "1":
                    Console.WriteLine("The best\n");
                    goto case "2"; // it is possible to "fall through" switch case using "goto"
                case "2":
                    Console.WriteLine("Medium\n");
                    break;
                case "3":
                    Console.WriteLine("The worst\n");
                    break;

                // There can be multiple cases that will have the same code, that will
                //  be executed if there is match on any of them.
                case "4":
                case "5":
                case "6":
                    Console.WriteLine("There was a match on either 4, 5 or 6.");
                    break;
                // Default is used when no case is matched.
                default:
                    Console.WriteLine("You specified wrong number.\n");
                    break;
            }

            utility.Separator();
        }
    }
}
