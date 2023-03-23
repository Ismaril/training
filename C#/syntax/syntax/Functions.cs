using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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

            // It is possible to switch parameter position if you write the name of parameter.
            SayHi(age: 31, name: "Johnson"); 
            SayHi();

            Console.WriteLine(Cube(number: 4));

            int number_assignment = Cube(number: 3); // possible as a variable
            Console.WriteLine(number_assignment);

            Console.WriteLine($"Pow function: {Power(4, 3)}\n");

            utility.Separator();

            int solution;
            DoubleIt(inputNumber: 35, out solution);
            Console.WriteLine(solution);

            int numba66 = 1_000;
            int numba77 = 4_000;
            Console.WriteLine($"Numba66: {numba66}, Numba77: {numba77} (Original values)");
            Swap(ref numba66, ref numba77);
            Console.WriteLine($"Numba66: {numba66}, Numba77: {numba77} (Numbers after Swap function)");

            // With unknown number of parameters, you can use both new array or just numbers
            //  as if they were separate parameters.
            Console.WriteLine($"Summary: {ComputeArraySum(new double[] { 4, 3, 13 })}");
            Console.WriteLine($"Summary: {ComputeArraySum(4, 3, 13)}");

        }

        // FUNCTIONS / METHODS (for some reason C# uses rather mehtods name, check if
        //  method means also that it is inside a class or if it is more general.
        // TODO: check method vs function in C#
        // Notice, that it is also possible to define default value for parameters.

        // Void means, that the function is not returning anything.
        static void SayHi(string name = "Tom", int age = 125)
        {
            Console.WriteLine($"Hello {name} you are {age} years old.");
        }

        // RETURN STATEMENT
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

        // OUT parameter
        // Allows the parameter to be accessed outside of the function, once the function
        //  has run.
        // If there was a return statement, the function would now have to outputs.
        static void DoubleIt(int inputNumber, out int solution)
        {
            solution =  inputNumber * 2;
        }


        // RETURN MORE THAN ONE VALUE USING TUPLE.
        static (int result1, int result2) MyMethodReturnsTuple(int input1, int input2)
        {
            int r1 = 5 * input1;
            int r2 = 100 * input2;
            return (r1, r2);
        }


        // REF keyword (pass a value into function by reference)
        // It allows to take as a parameter variable from the outside and change it so that
        //  the change is also done on the outside variable. It is done inplace (no return 
        //  statement, or anything needed)
        // In normal case when you input a value into function parameter, the value is copied
        //  into local scope. This copy dies when the function executes.
        /// <summary>
        /// This function swaps two numbers.
        /// </summary>
        static void Swap(ref int nr1, ref int nr2)
        {
            int temporary = nr1;
            nr1 = nr2;
            nr2 = temporary;

        }

        // PARAMS keyword - passing unknown number of parameters
        // Its the same like in Python - "*args" = "param dataType[] nameOfParameter"
        static double ComputeArraySum(params double[] unknownNumberOfParametrs)
        {
            double sum = 0;
            foreach (int number in unknownNumberOfParametrs)
            {
                sum += number;
            }
            return sum;
        } 
    }
}
