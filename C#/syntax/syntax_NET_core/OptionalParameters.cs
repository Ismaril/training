using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax_NET_core
{
    internal static class OptionalParameters
    {
        static int Calculate(int a, int b, int c, int d = 10)
        {
            return a + b + c + d;
        }

        static int Calculate(int a, int b)
        {
            return a + b;
        }

        public static void Main__()
        {
            // If you want to input into the parameters values you have to
            //  input them in order as they are defined in the method.
            Console.WriteLine(Calculate(10, 20, 30, 40));

            // But you can of course change the order of the parameters
            // You have to specify the name of the parameter and then input the value.
            Console.WriteLine(Calculate(d: 40, c: 30, b: 20, a: 10));

            // It is possible to use combination where you specify the 
            //  names of the parameters and skip some of them.
            // It is however important that the parameters names you skip must
            //  be in the right order. That means that you must start with
            //  the paramter without the name and you can use the named parameters.
            // Numbers 10 and 20 will still be assigned to a and b.
            Console.WriteLine(Calculate(10, 20, d: 40, c: 30));

            // You cannot however skip parameters.
            //Console.WriteLine(Calculate(d: 10, c: 30, b: 20));

            // You can however skip parameters by specifying the default value
            //  for the parameter.
            // The default parameters must follow the non-default parameters in 
            //  the method signature (Meaning where the method is defined).
            // Take a look at the last parameter in function definition.
            Console.WriteLine(Calculate(a:10, b: 20, c:30));

            // When there are multiple methods with the same name,
            //  but have different number of parameters, then the compiler
            //  will chose the method wich has the same number of parameters
            //  as the number of arguments you pass in.
            // This means that in this example we call the method with two parameters,
            //  which we defined above in this file.
            Console.WriteLine(Calculate(10, 20));
        }
    }


}
