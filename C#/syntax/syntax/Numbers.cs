using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax
{
    internal static class Numbers
    {
        internal static void Main__()
        {
            Utilities utility = new Utilities();

            utility.Title("NUMBERS");

            Console.WriteLine(4);
            Console.WriteLine(4 * 2);
            Console.WriteLine(4 / 2);
            Console.WriteLine(4 + 3);
            Console.WriteLine(4 - 2);
            Console.WriteLine(4 % 2);
            Console.WriteLine((4 - 2) * 2);
            Console.WriteLine(4.0 + 2); // the type will be converted to float/double
            Console.WriteLine(5 / 2);  // this will not be converted to float/double
            Console.WriteLine(5 / 2.0); // this will give correct answer

            int number = 5;
            Console.WriteLine(number);
            number++;  // increment number by 1
            Console.WriteLine(number);
            number--;  // decrement number by 1
            Console.WriteLine(number);

            Console.WriteLine(Math.Abs(-3));
            Console.WriteLine(Math.Pow(2, 4));
            Console.WriteLine(Math.Sqrt(16));
            
            utility.Separator();
        }
    }
}
