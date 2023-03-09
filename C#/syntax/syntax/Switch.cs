using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax
{
    internal static class Switch
    {
        internal static void Main__()
        {

            Utilities utility = new Utilities();
            utility.Title("SWITCH");
            

            string textos = "1";
            switch (textos)
            {
                case "1":
                    Console.WriteLine("The best\n");
                    break;
                case "2":
                    Console.WriteLine("Medium\n");
                    break;
                case "3":
                    Console.WriteLine("The worst\n");
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
