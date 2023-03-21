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
            /*
             * When executing C# code, different errors can occur: coding errors made by the 
             * programmer, errors due to wrong input, or other unforeseeable things.
             * When an error occurs, C# will normally stop and generate an error message. 
             * The technical term for this is: C# will throw an exception (throw an error).
             */

            Utilities utility = new Utilities();
            utility.Title("EXCEPTIONS");

            int number1 = 3;
            int number2 = 0;

            // TRY, EXCEPT, FINALLY
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


            // THROW
            /* The throw statement allows you to create a custom error.
             * The throw statement is used together with an exception class. 
             * There are many exception classes available in C#: 
             *  ArithmeticException, FileNotFoundException, IndexOutOfRangeException, TimeOutException, etc.
             */

            int age = 60;
            if (age < 18)
            {
                throw new ArithmeticException("Access denied - You must be at least 18 years old.");
            }
            else
            {
                Console.WriteLine("Access granted - You are old enough!");
            }
        }
    }
}
