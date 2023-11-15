using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax_NET_core
{
    internal static class LambdaMethods
    {
        public static void Main__()
        {
            // Below you will see a progression from anonymous method to lambda expression.


            Utilities utilities = new();
            utilities.PrintLine();

            ListArray(new int[] { 1, 2, 3, 4});

            utilities.PrintLine();

            ListArrayDelegate listArrayDelegate = new ListArrayDelegate(ListArray);
            listArrayDelegate(new int[] { 5, 6, 7, 8 });

            utilities.PrintLine();

            // ANONYMOUS METHOD
            // Assign anonymous method to listArrayDelegate2 using delegate keyword.
            ListArrayDelegate listArrayDelegate2 = delegate (int[] myList)
            {
                foreach (var item in myList)
                {
                    Console.WriteLine(item);
                }
            };
            listArrayDelegate2(new int[] { 9, 10, 11, 12 });

            utilities.PrintLine();

            // PASSING ANONYMOUS METHOD AS A PARAMETER
            // Pass anonymous method as a second parameter to Array.ForEach method.
            Array.ForEach(new int[] { 13, 14, 15, 16 }, delegate (int item){Console.WriteLine(item);});

            utilities.PrintLine();

            int[] myList = Array.FindAll(new int[] { 17, 18, 19, 20 }, delegate (int item) { return item > 18; });
            Array.ForEach(myList, delegate (int item) { Console.WriteLine(item); });

            utilities.PrintLine();

            // LAMBDA EXPRESSION
            // delegate(int[] item) { return item > 18; } is replaced with:
            // (int item) => { return item > 18; } is replaced with:
            // (item) => (item > 18) is replaced with:
            // item => item > 18

            // All code below does the same thing.
            // Use normal delegate with method inside it.
            ShowResult(100, 200, new MathDelegate(Add));
            ShowResult(100, 200, new MathDelegate(Multiply));
            // Also possible to use anonymous method as a parameter.
            ShowResult(100, 200, delegate (int x, int y) { return x + y; });
            ShowResult(100, 200, delegate (int x, int y) { return x * y; });
            // Use lambda expression as a parameter.
            ShowResult(100, 200, (x, y) => x + y);
            ShowResult(100, 200, (x, y) => x * y);
            ShowResult(100, 200, (x, y) => x / y); // You just create a lambda expression without any other other additional code and it works.

            utilities.PrintLine();

            // GENERIC DELEGATE
            // Just a reminder, you do not always have to create your own delegate.
            // You can use builtin generic delegate like Func<> or Action<>.
            ShowResultGeneric(500, 600, (x, y) => x + y);
            ShowResultGeneric("Hello", "YouCucumber", (x, y) => x + y);

            utilities.PrintLine();

            // EXPRESSION BODY
            // Explained in the class ToughGuy.
            // Basically expression bodies are used to simplify the code.
            // Making for example properties and methods shorter by
            //  removing brackets and return keyword.
            // It is done by using => operator.
           
        }

        static void ListArray(int[] myList)
        {
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }

        delegate void ListArrayDelegate(int[] myList);

        static int Add(int x, int y)
        {
            return x + y;
        }

        static int Multiply(int x, int y)
        {
            return x * y;
        }

        delegate int MathDelegate(int x, int y);

        static void ShowResult(int x, int y, MathDelegate mathDelegate)
        {
            Console.WriteLine(mathDelegate(x, y));
        }

        // Func is some built-in generic delegate.
        // The first type int <> represents the type of the first parameter.
        // The second type int <> represents the type of the second parameter.
        // The third type int <> represents the type of the return value.
        static void ShowResultGeneric(int x, int y, Func<int, int, int> mathDelegate)
        {
            Console.WriteLine(mathDelegate(x, y));
        }

        static void ShowResultGeneric(string x, string y, Func<string, string, string> mathDelegate)
        {
            Console.WriteLine(mathDelegate(x, y));
        }
    }

    class ToughGuy
    {
        // Expression body
        public string Name => "Tough Guy";
        public int Age { get; set; }

        public ToughGuy(int age)
        {
            Age = age;
        }

        // Expression body
        public void Salute() => Console.WriteLine("Salute!");
    }
}
