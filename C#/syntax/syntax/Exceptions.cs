using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax
{
    internal static class Exceptions
    {
        internal static void Main__()
        {

            Utilities utility = new Utilities();
            utility.Title("EXCEPTIONS");

            int number1 = 3;
            int number2 = 0;

            try
            {
                Console.WriteLine(number1 / number2);
            }
            catch (Exception msg) // Catch Exception message as a variable "msg".
            {
                Console.WriteLine(msg.Message);
            }

            // Specify exact error,
            //  specify multiple exceptions,
            //  specify finally block, which executes always
            try
            {
                Console.WriteLine(number1 / number2);
            }
            catch (DivideByZeroException msg)
            {
                Console.WriteLine(msg.Message);
            }
            catch (IndexOutOfRangeException msg)
            {
                Console.WriteLine(msg.Message);
            }
            finally { Console.WriteLine("Executing 'finally' block."); }
                
            utility.Separator();
        }
    }
}
