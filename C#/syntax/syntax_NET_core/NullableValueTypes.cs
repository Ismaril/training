using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax_NET_core
{
    internal class NullableValueTypes
    {
        // Basically specify whats going to happen if the value is null.
        // With a single question mark you specify that the value can be null. In some cases
        //  it would otherwise crash program if the question mark was not there and the value was null.
        public static void Main__()
        {
            Utilities utilities = new();
            utilities.PrintLine();

            //int i = null; // This is not allowed, because int is a value type.

            // Both below mean the same thing.
            // With question mark syntax you now allow the value to be null or just normal value.
            int? i = null; // This is allowed, because int? is a nullable value type.
            Nullable<int> j = null; // This is allowed, because Nullable<int> is a nullable value type.
            Console.WriteLine($"i: {i}.");
            Console.WriteLine($"j: {j}.");

            // Operation over null value of the nullable type will always be null again.
            Console.WriteLine($"Result: {i + 1}.");

            // Check here, that it really does not have any value.
            if (i.HasValue)
                Console.WriteLine($"i: {i.Value}");
            else
                Console.WriteLine("i is null.");

            // You can also use the GetValueOrDefault() method.
            // Into the parameter of GetValueOrDefault() method you can pass a default value,
            //  of your choice.
            Console.WriteLine($"Default value: {i.GetValueOrDefault()}.");
            Console.WriteLine($"Default value: {i.GetValueOrDefault(5)}.");
            // Shorter syntax.
            Console.WriteLine($"Default value: {i ?? 0}.");
            Console.WriteLine($"Default value: {i ?? 5}.");


            utilities.PrintLine();

            // ??= OPERATOR
            // You can use ??= operator to assign a value to a variable only if the variable is null.
            // It is basically like += operator, but for null values.
            int[]? integers = null;
            integers ??= new int[5];
            for (int index = 0; index < integers.Length; index++)
                Console.WriteLine($"At index {index} is value: {integers[index]}");


            utilities.PrintLine();


            // --------------------------------------------------------------------------------
            // So basically, how to understand all of this?:
            // You put single question marks there, where you expect the value to be null.
            int? n = null;

            //int m1 = n;    // Doesn't compile
            int m = 125;
            int n2 = (int)m; // Compiles, but throws an exception if m is null

            // Combination of ? and ??
            // Here you see that you put single question mark where you expect the value to be null.
            // Double question mark is here to asign default value if the value is null.
            string[] ints = null;
            Console.WriteLine(ints?[0]?.Length ?? 0);
        }


    }
}
