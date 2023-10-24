using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax_NET_core
{
    internal class NullableValueTypes
    {
        public static void Main__()
        {
            Utilities utilities = new();
            utilities.PrintLine();

            //int i = null; // This is not allowed, because int is a value type.

            // Both mean the same thing.
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


        }


    }
}
