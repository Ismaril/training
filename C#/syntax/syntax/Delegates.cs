using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax
{
    public static class Delegates
    {
        /*
        DELEGATES:
        Provides a good way to encapsulate the methods.
        Delegates are the library class in System namespace.
        These are the type-safe pointer of any method.
        Delegates are mainly used in implementing the call-back methods and events.
        Delegates can be chained together as two or more methods can be called on a single event.
        It doesn’t care about the class of the object that it references.
        Delegates can also be used in “anonymous methods” invocation.
        Anonymous Methods(C# 2.0) and Lambda expressions(C# 3.0) are compiled to delegate types in certain contexts. Sometimes, these features together are known as anonymous functions.
            */
        public static void Main__()
        {
            Utilities utility = new Utilities();
            utility.Title("DELEGATES");

            Arithmetic add = new Arithmetic(AddTwoNumbers);
            Arithmetic subtract = new Arithmetic(SubtractTwoNumbers);
            Arithmetic addAndSubtract = add + subtract;
            int n1 = 50, n2 = 20;

            Console.WriteLine($"{n1} + {n2}:");
            add(n1, n2);
            Console.WriteLine($"{n1} - {n2}:");
            subtract(n1, n2);

            utility.Separator();
            Console.WriteLine("Chain two delegates together:");
            addAndSubtract(n1, n2);
        }

        public delegate void Arithmetic(int x, int y);

        public static void AddTwoNumbers(int x, int y)
        {
            Console.WriteLine(x + y);
        }
        public static void SubtractTwoNumbers(int x, int y)
        {
            Console.WriteLine(x - y);
        }

    }
}
