
// COMPLEXITY OF PATTERN: EASY

/*
The Adapter design pattern is a structural pattern that allows objects 
with incompatible interfaces to work together. It acts as a bridge 
between two incompatible interfaces by converting the interface of a 
class into another interface that a client expects. This pattern is 
particularly useful when you want to reuse existing classes 
without modifying their source code.

KEY COMPONENTS
Target: The interface that the client expects.
Adaptee: An existing interface that needs to be adapted.
Adapter: A class that implements the Target interface and translates the requests from the Target interface to the Adaptee.
*/

namespace DesignPatterns
{
    // The Target defines the domain-specific interface used by the client code.
    public interface ITarget
    {
        string GetRequest();
    }

    // The Adaptee contains some useful behavior, but its interface is
    // incompatible with the existing client code. The Adaptee needs some
    // adaptation before the client code can use it.
    class Adaptee
    {
        public string GetSpecificRequest()
        {
            return "Specific request.";
        }
    }

    // The Adapter makes the Adaptee's interface compatible with the Target's
    // interface.
    class Adapter : ITarget
    {
        private readonly Adaptee _adaptee;

        public Adapter(Adaptee adaptee)
        {
            this._adaptee = adaptee;
        }

        public string GetRequest()
        {
            return $"This is '{this._adaptee.GetSpecificRequest()}'";
        }
    }

    public class ProgramAdapter
    {
        public static void Main__()
        {
            Adaptee adaptee = new Adaptee();
            ITarget target = new Adapter(adaptee);
            Console.WriteLine(target.GetRequest());

            Console.ReadLine();
        }
    }
}
