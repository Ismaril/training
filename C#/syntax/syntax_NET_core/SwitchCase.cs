using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax_NET_core
{
    internal static class SwitchCase
    {
        public static void Main__()
        {
            Utilities utilities = new();
            utilities.PrintLine();

            Console.WriteLine(GetStatusString(200));
            Console.WriteLine(GetStatusString(404));
            Console.WriteLine(GetStatusString(888));

            utilities.PrintLine();

            Console.WriteLine(GetStatusString2(1));
            Console.WriteLine(GetStatusString2(401));
            Console.WriteLine(GetStatusString2(999));

            utilities.PrintLine();

            Console.WriteLine(IsKeyword(null));
            Console.WriteLine(IsKeyword(1));
            Console.WriteLine(IsKeyword("abcd"));
            Console.WriteLine(IsKeyword("abcde"));


        }
        static void MakeToolSound(Tool tool)
        {
            // If a tool is a Hammer, then create a new variable
            //  "hammer" of type Hammer.
            if (tool is Hammer hammer)
            {
                // Hammer hammer = (Hammer)tool;
                hammer.Hit();
            }
            // Here is a classic way of checking if a tool is of
            //  a certain type. Then we create manually a new
            //  variable of that type inside the else block.
            else if (tool is Screwdriver)
            {
                Screwdriver screwdriver = (Screwdriver)tool;
                screwdriver.Screw();
            }
            else
            {
                // This is not possible because hammer variable is
                //   only created if the tool in the if block is
                //   a Hammer.
                // hammer.Hit(); // <---------

                // Therefore if you want to use for example hammer
                //  variable you need to create new one here.
                var hammer__ = new Hammer();
                var screwdriver__ = new Screwdriver();
            }
        }

        static void MakeToolSound2(Tool tool)
        {
            // This is a switch statement with pattern matching.
            // It is the same as the MakeToolSound method above.
            switch (tool)
            {
                case Hammer hammer:
                    hammer.Hit();
                    break;
                // For info, you can create a new variable also with some extra conditions.
                // Also this case block with "when" syntax has to be above the "case Screwdriver"
                //  it would not compile otherwise.
                case Screwdriver screwdriver_ when screwdriver_.Description == "Screwdriver":
                    screwdriver_.Screw();
                    break;
                case Screwdriver:
                    Screwdriver screwdriver = (Screwdriver)tool;
                    screwdriver.Screw();
                    break;
                default:
                    var hammer__ = new Hammer();
                    var screwdriver__ = new Screwdriver();
                    break;
            }
        }

        static string GetStatusString(int statusCode)
        {           
            // There are multiple the same switches which obviously
            // do not make sense. It is only for demonstration purposes.


            string statusResult = "";
            switch (statusCode)
            {
                case 200:
                    statusResult = "OK"; break;
                case 404:
                    statusResult = "Not Found"; break;
                case 500:
                    statusResult = "Internal Server Error"; break;
            }
            // Then you would have to return the value.
            // return statusResult;

#if false
            // You can also directly assign the value to the variable.
            // Careful this crashes a program if you do not have a default case
            //  and you pass a value which is not in the switch.
            string statusResult_ = statusCode switch
            {
                200 => statusResult_ = "OK",
                404 => statusResult_ = "Not Found",
                500 => statusResult_ = "Internal Server Error"
            };
            //return statusResult_;
# endif

            switch (statusCode)
            {
                case 200:
                    return "OK";
                case 404:
                    return "Not Found";
                case 500:
                    return "Internal Server Error";
            }


            switch (statusCode)
            {
                case 200: return "OK";
                case 404: return "Not Found";
                case 500: return "Internal Server Error";
            }


            // You can load whole switch into return statement.
            return statusCode switch
            {
                200 => "OK",
                404 => "Not Found",
                500 => "Internal Server Error",
                // You can also use default case using _.
                _ => "Invalid status code."
            };
        }

        static string GetStatusString2(int statusCode)
        {
            return statusCode switch
            {
                1 or 2 or 3 => "OK",
                >= 400 and < 500 and not 401 => "Not Found",
                401 => "Unauthorized",
                999 => "Error",
            };

        }

        /// <summary>
        /// In this function you can see how to use "is" keyword in
        ///  if else statement.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        static string IsKeyword(object parameter)
        {
            if (parameter is null) return "null";
            else if (parameter is int) return "integer";
            // You can specify also length of a string.
            else if (parameter is string { Length: 4 }) return "string of length 4";

            return "Nothing";
        }
    }

    public abstract class Tool
    {
    }

    public class Hammer : Tool
    {
        public void Hit()
        {
            Console.WriteLine("Hammer is hitting.");
        }
    }

    public class Screwdriver : Tool
    {
        public  string Description { get; set; } = "Screwdriver";

        public void Screw()
        {
            Console.WriteLine("Screwdriver is screwing.");
        }
    }

}
