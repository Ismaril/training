using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax
{
    internal static class Functions
    {
        internal static void Main__()
        {
            Utilities utility = new Utilities();
            utility.Title("FUNCTIONS");


            SayHi("Pepo", 40);
            SayHi(name: "Tomas", 30);
            SayHi("Mike", age: 23);
            SayHi(name: "Johnson", age: 31);

            Console.WriteLine(Cube(number: 4));

            int number_assignment = Cube(number: 3); // possible as a variable
            Console.WriteLine(number_assignment);

            Console.WriteLine($"Pow function: {Power(4, 3)}\n");

            utility.Separator();

        }

        // FUNCTIONS / METHODS (for some reason C# uses rather mehtods name, check if
        //  method means also that it is inside a class or if it is more general.
        // TODO: check method vs function in C#

        // Void means, that the function is not returning anything.
        static void SayHi(string name, int age)
        {
            Console.WriteLine($"Hello {name} you are {age} years old.");
        }

        // Return statement
        // Int means here, that the function is going to return int type.
        static int Cube(int number)
        {
            int result = number * number * number;
            return result;
        }

        // Function to raise base number to the power of exponent.
        static int Power(int base_number, int exponent)
        {
            int result = base_number;
            for (int i = 1; i < exponent; i++)
            {
                result *= base_number;
            }
            return result;
        }
    }
}
