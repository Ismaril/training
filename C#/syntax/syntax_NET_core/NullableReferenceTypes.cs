using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//q: What does #nullable enable do?
//a: It enables nullable reference types for the whole project.
# nullable enable

namespace syntax_NET_core
{
    internal static class NullableReferenceTypes
    {
        // In this exercise lets try to see how to identify possible problems with null values
        //  before the program is even run. This will prevent problem with one of the most common
        //  problems in programming languages, which is null reference exception.
        internal static void Main__()
        {
            List<string?> list = new();
            AddItem(list, "A");
            AddItem(list, "B");
            AddItem(list, null);
            foreach (string? item in list)
            {
                Console.WriteLine(item?.ToLower());

                // YOU CAN UNCOMMENT THE PARTS OF CODE BELOW TO SEE HOW THE NULL REFERENCE CHECKING WORKS.

                // This will cause null reference exception.
                // string s = item;
                //Console.WriteLine(s.ToLower()); 

                // This will disable null reference checking for the code below.
                // You will not see any warnings for the code below,
                //  if there is a possibility of null reference exception.
#nullable disable
                // This will not cause null reference exception.
                //string s = item;
                //Console.WriteLine(s.ToLower());
                // This will enable null reference checking for the code below.
#nullable enable

                // Notice the "!" after the variable name. It is called null-forgiving operator.
                // It does the same thing as the block above wher we used preprocessor directive
                //  #nullable disable/enable for null reference checking.
                //string s = item!;
                //Console.WriteLine(s.ToLower());

            }
        }

        static void AddItem(List<string?> list, string? newValue)
        {
            list.Add(newValue);
        }
    }
}
