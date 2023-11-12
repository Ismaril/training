using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace syntax_NET_core
{
    internal static class AnonymousTypes
    {
        // Not possible to create anonymous instance outside of method.
        // var employee3 = new { LastName = "Alonso", FirstName = "Fernando" };

        public static void Main__()
        {
            var utilities = new Utilities();
            utilities.PrintLine();

            var employee1 = new { FirstName = "Fernando", LastName = "Alonso" };
            Console.WriteLine($"FirstName: {employee1.FirstName}, LastName: {employee1.LastName}");

            //employee1.FirstName = "Roberto" // This is not possible, anonymous types are immutable.

            var employee2 = new { FirstName = "Fernando", LastName = "Alonso" };
            Console.WriteLine($"Equality: {employee1.Equals(employee2)}");
            Console.WriteLine($"GetHashCode: {employee1.GetHashCode() == employee2.GetHashCode()}");

            // When the Properties are switched, but their values are the same, the objects will
            //  not equal.
            var employee3 = new { LastName = "Alonso", FirstName = "Fernando" };
            Console.WriteLine($"Equality: {employee1.Equals(employee3)}");
            Console.WriteLine($"GetHashCode: {employee1.GetHashCode() == employee3.GetHashCode()}");

            utilities.PrintLine();

            Console.WriteLine($"Ancestor class: {employee1.GetType().BaseType}");

            utilities.PrintLine();

            // ShowEmployeeUsingReflection(employee1);
            ShowEmployeeUsingDynamicType(employee1);
            ShowEmployeeUsingReferenceTuple(new Tuple<string, string>(employee1.FirstName, employee1.LastName));
            ShowEmployeeUsingValueTuple((employee1.FirstName, employee1.LastName));

            utilities.PrintLine();

            // LIST OF ANONYMOUS TYPES
            // List myList = new List() { new { FirstName = "", LastName = "" } }; // Not possible
            var myList2 = new[] { 10, 20, 30 }; // Automatically knows it is integer array
            var myList3 = new[] { "A", "B", "C" }; // Automatically knows it is string array

            // If you hower with mouse over the myList4 you see syntax 'a[]. I could not google up
            //  the syntax 'a[] but I suspect that 'a is for anonymous types, therefore 
            //  an array of anonymous types.
            var myList4 = new[] { new { FirstName = "", LastName = "" } };

            var myList4converted = myList4.ToList();
            myList4converted.Add(new { FirstName = "Pepa", LastName = "Zdepa" });
            myList4converted.Add(new { FirstName = "Franta", LastName = "Tondak" });

            for (int i = 0; i < myList4converted.Count; i++)
            {
                Console.WriteLine($"Index {i}: {myList4converted[i].FirstName}{myList4converted[i].LastName}");
            }

        }

        // PASSING ANONYMOUS TYPE TO A METHOD USING REFLECTION
        static void ShowEmployeeUsingReflection(object objectParameter)
        {
            // This is not possible. Checkout options in different methods melow.
            //Console.WriteLine(objectParameter.FirstName);
        }

        // PASSING ANONYMOUS TYPE TO A METHOD USING DYNAMIC TYPE
        static void ShowEmployeeUsingDynamicType(dynamic employee)
        {
            // This will work with anonymous class type.
            Console.WriteLine($"FirstName: {employee.FirstName}, LastName: {employee.LastName}");
        }

        // PASSING ANONYMOUS TYPE TO A METHOD USING TUPLE REFERENCE DATA TYPE
        static void ShowEmployeeUsingReferenceTuple(Tuple<string, string> employeeName)
        {
            Console.WriteLine($"FirstName: {employeeName.Item1}, LastName: {employeeName.Item2}");
        }

        // PASSING ANONYMOUS TYPE TO A METHOD USING TUPLE VALUE DATA TYPE
        // The (string FiName, string LaName) are actually tuple Item names here.
        // So the employeeName is actually a tuple data type here.
        static void ShowEmployeeUsingValueTuple((string FiName, string LaName) employeeName)
        {
            Console.WriteLine($"FirstName: {employeeName.FiName}, LastName: {employeeName.LaName}");
        }


    }


}
