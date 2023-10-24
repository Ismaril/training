using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax_NET_core
{
    internal class Delegates
    {
        // Delegates are used to pass methods as arguments to other methods.
        public static void Main__()
        {
            Utilities utilities = new();
            utilities.PrintLine();

            Console.WriteLine(Sum_(10, 20));

            utilities.PrintLine();

            // Create an instance of the delegate with a function passed inside.
            SumDelegate sumDelegate = new(Sum_);
            Console.WriteLine(sumDelegate(10, 20));
            MaxDelegate maxDelegate = new(Max_);
            Console.WriteLine(maxDelegate(10, 20));

            utilities.PrintLine();

            // COMBINE DELEGATES
            // Below you will see also use of invocation list. This allows you to invoke/execute
            // all the functions when you have combined multiple delegates.

            // Use just one function passed inside.
            DoSomethingDelegate doSomethingDelegate = new(DoSomething);
            Console.WriteLine(doSomethingDelegate());

            // Unnecessary long syntax to combine two delegates.
            doSomethingDelegate = (DoSomethingDelegate)DoSomethingDelegate.Combine(
                    new DoSomethingDelegate(DoSomething),
                    new DoSomethingDelegate(DoSomethingElse)
                    );
            foreach (DoSomethingDelegate item in doSomethingDelegate.GetInvocationList())
                Console.WriteLine(item());

            // Shorter syntax to combine two delegates.
            doSomethingDelegate = new DoSomethingDelegate(DoSomething);
            doSomethingDelegate += new DoSomethingDelegate(DoSomethingElse);
            foreach (DoSomethingDelegate item in doSomethingDelegate.GetInvocationList())
                Console.WriteLine(item());

            // Even shorter syntax to combine two delegates.
            doSomethingDelegate = DoSomething;
            doSomethingDelegate += DoSomethingElse;
            foreach (DoSomethingDelegate item in doSomethingDelegate.GetInvocationList())
                Console.WriteLine(item());

            utilities.PrintLine();

        }

        private static int Sum_(int x, int y)
        {
            return x + y;
        }

        private static int Max_(int x, int y)
        {
            return x > y ? x : y;
        }

        private static string DoSomething()
        {
            return "Doing somehthing";
        }

        private static string DoSomethingElse()
        {
            return "Doing somehthing else";
        }

        // Create a delegate.
        private delegate int SumDelegate(int x, int y);
        private delegate int MaxDelegate(int x, int y);
        private delegate string DoSomethingDelegate();
    }
}
