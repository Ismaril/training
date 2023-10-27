using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace syntax_NET_core
{
    internal class Delegates
    {
        // Delegates are used to pass methods as arguments to other methods.
        // Think of delegates as a template for a method -> Suppose you have a class
        //  which you you do not want to change once created, and you want to add some
        //  functionality into it from the outside, which has a possibility to change.
        //  You can use delegates to do that. You can create a delegate, which will be
        //  a placeholder for a external method. Into that placholder you can pass 
        //  any method you want from the outside, as long as it matches the signature
        //  of the delegate. Check the example in the file Delegates_0.cs.

        public static void Main__()
        {
            Utilities utilities = new();
            utilities.PrintLine();

            Console.WriteLine(Sum_(10, 20));

            utilities.PrintLine();

            // BASIC DELEGATE USE
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

            // CALLBACKS
            SomeAribitraryClass.CallBack = FunctionToPassIntoCallback;
            SomeAribitraryClass.DoWork("This is text inputted into callback delegate");

            utilities.PrintLine();

            // Careful when using callbacks, because if you assign a new function to the delegate,
            //  with only one = sign, you will overwrite the old function. If you use +=, then
            //  you can add multiple functions to the delegate.
            SomeAribitraryClass.CallBack = FunctionToPassIntoCallback_2; // Overwrites the old function.
            SomeAribitraryClass.DoWork("This is text inputted into callback delegate");

            utilities.PrintLine();

            // See here that there will be actually executed two functions with DoWork().
            SomeAribitraryClass.CallBack = FunctionToPassIntoCallback;
            SomeAribitraryClass.CallBack += FunctionToPassIntoCallback_2;
            SomeAribitraryClass.DoWork("This is text inputted into callback delegate");

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

        // --------------------------------------------------------------------------------
        public static void FunctionToPassIntoCallback(string result)
        {
            Console.WriteLine("(1stFunctionRegisteredIntoCallback), " + result);
        }

        public static void FunctionToPassIntoCallback_2(string result)
        {
            Console.WriteLine("(2ndFunctionRegisteredIntoCallback), " + result);
        }
    }

    public static class SomeAribitraryClass
    {

        public static WorkCompletedCallback CallBack;

        public static void DoWork(string stringFromUser)
        {
            Console.WriteLine("Doing some work.");
            Thread.Sleep(2000);
            CallBack(stringFromUser);
        }
    }

    public delegate void WorkCompletedCallback(string result);


}
