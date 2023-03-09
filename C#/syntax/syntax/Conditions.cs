using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax
{
    internal static class Conditions
    {
        internal static void Main__()
        {
            Utilities utility = new Utilities();
            utility.Title("IF ELSE");


            bool isMale = true;
            bool isTall = false;

            // && means AND
            if (isMale && isTall)
            {
                Console.WriteLine("He is male and is tall.");
            }
            // "!" means NOT operator
            else if (isMale && !isTall)
            {
                Console.WriteLine("He is male but is not tall.");
            }
            else if (!isMale && isTall)
            {
                Console.WriteLine("She is female and is tall.");
            }
            else
            {
                Console.WriteLine("She is a small female.");
            }

            // || means OR operator
            if (isMale || isTall)
            {
                Console.WriteLine("You are either a man or you are tall.");
            }

            int some_var = 2;
            if (some_var > 0)
            {
                Console.WriteLine("The number is positive.\n");
            }
                
            // shorter if else (ternary operator)
            int time = 20;
            string result = (time < 18) ? "Good day." : "Good evening.";
            Console.WriteLine(result);

            utility.Separator();
        }
    }
}
