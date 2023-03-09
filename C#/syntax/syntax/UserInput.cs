using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax
{
    internal static class UserInput
    {
        internal static void Main__()
        {
            Utilities utility = new Utilities();
            utility.Title("GETTING USER INPUT");

            // Console.Write means that there is no "\n" at the end.
            Console.Write("Write your name: "); 
            string name = Console.ReadLine();
            Console.WriteLine($"Hello {name}");
            
            Console.Write("Enter the first number: ");
            int number1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the second number: ");
            int number2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(number1 + number2);
            
            utility.Separator();
        }
    }
}
