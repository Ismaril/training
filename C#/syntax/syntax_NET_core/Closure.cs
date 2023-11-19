// This is a simple example of a closure in C#.
// The myFunc delegate is a closure because it "closes over" the outerVariable
//  variable, meaning it retains access to outerVariable even after GetClosure
//  has finished execution.

namespace syntax_NET_core
{
    internal static class Closure
    { 
        public static void Main__()
        {
            Utilities utilities = new();
            utilities.PrintLine();

            // This line calls the GetClosure method and assigns the
            //  returned delegate to a variable named closure.
            var closure = GetClosure();

            // This line calls the closure delegate with 10 as an argument and
            //  writes the result to the console.
            // Since closure is myFunc returned from GetClosure,
            //  it adds 10 to outerVariable (which is 5), and outputs 15.
            Console.WriteLine(closure(10)); // Outputs 15
        }

        // This line declares a public static method named GetClosure that returns
        //  a Func<int, int>.
        // Func<int, int> is a delegate that takes an integer as an argument and
        //  returns an integer.
        public static Func<int, int> GetClosure()
        {
            int outerVariable = 5;

            // This line declares a Func<int, int> delegate named myFunc.
            // The delegate is assigned a lambda expression x => x + outerVariable.
            // This lambda expression takes an integer x as an argument and returns
            //  the sum of x and outerVariable.
            Func<int, int> myFunc = x => x + outerVariable;

            // This line returns myFunc.
            // Since myFunc is a closure that references outerVariable,
            //  the returned delegate will still have access to outerVariable even
            //  after GetClosure has finished execution.
            return myFunc;
        }
    }
}
