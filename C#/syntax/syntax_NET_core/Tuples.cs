using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax_NET_core
{
    internal static class Tuples
    {
        // It is convinient to use tuples when you have multiple
        //  values that you need to encapsulate somehow.
        public static void Main__()
        {
            Utilities utilities = new();
            utilities.PrintLine();

            Tuple<int, string, bool> tuple = new(10, "John", true);
            // Item1, Item2, Item3 are default properties of the Tuple class.
            Console.WriteLine(tuple.Item1);
            Console.WriteLine(tuple.Item2);
            Console.WriteLine(tuple.Item3);

            utilities.PrintLine();

            var valueTuple = GetValueTupleData();
            Console.WriteLine(valueTuple.Id);
            Console.WriteLine(valueTuple.Name);
            Console.WriteLine(valueTuple.isMale);

            utilities.PrintLine();

            var valueTuple2 = GetValueTupleData2(20, "Jane", false);
            Console.WriteLine(valueTuple2.Id);
            Console.WriteLine(valueTuple2.Name);
            Console.WriteLine(valueTuple2.isMale);
        }

        static Tuple<int, string, bool> GetTupleData()
        {
            int identifier = 10;
            string name = "John";
            bool isMale = true;
            return new Tuple<int, string, bool>(identifier, name, isMale);

            // It definetelly makes sense to use tuples when you want
            //  to return multiple values from a method.
            // Imagine how it would look like if we has to for example
            //  had to return a list of values from a method and then
            //  use the indexer to get the values.
            // It would look something like this in the main method:
            // Console.WriteLine(GetData()[0]);
            // Console.WriteLine(GetData()[1]);
            // Console.WriteLine(GetData()[2]);
        }

        // VALUE TUPLE
        // C# 7.0 introduced a new syntax for tuples.
        //static ValueTuple<int, string, bool> GetValueTupleData()
        static (int Id, string Name, bool isMale) GetValueTupleData()
        // This function head is the same as the commented
        //  ValueTuple<int, string, bool> above.
        // But this is shorter and more readable.
        {
            int identifier = 10;
            string name = "John";
            bool isMale = true;
            return (identifier, name, isMale);
        }

        // You can use also parameters in the function head.
        // Then you will access each item by the property names which you defined in the
        //  tuple in the function head.
        static (int Id, string Name, bool isMale) GetValueTupleData2(int id, string name, bool isMale)
        {
            return (id, name, isMale);
        }
    }
}
