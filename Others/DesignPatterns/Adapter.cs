﻿/*
COMPLEXITY OF PATTERN: EASY

The Adapter design pattern is a structural pattern that allows objects 
with incompatible interfaces to work together. It acts as a bridge 
between two incompatible interfaces by converting the interface of a 
class into another interface that a client expects. This pattern is 
particularly useful when you want to reuse existing classes 
without modifying their source code.


KEY COMPONENTS
1. TARGET:
The interface that the client expects.

2. ADAPTEE: 
An existing interface that needs to be adapted.

3. ADAPTER: 
A class that implements the Target interface and translates the requests from 
the Target interface to the Adaptee.

*/

namespace DesignPatterns
{   
    // ---------------------------------------------------------------------------
    // 1. TARGET
    // The Target defines the domain-specific interface used by the client code.
    public interface ITarget
    {
        string GetRequest();
    }

    // ---------------------------------------------------------------------------
    // 2. ADAPTEE
    // The Adaptee contains some useful behavior, but its interface is
    // incompatible with the existing client code. The Adaptee needs some
    // adaptation before the client code can use it.
    class Adaptee
    {
        public string GetSpecificRequest() => "Specific request.";
    }

    // ---------------------------------------------------------------------------
    // 3. ADAPTER
    // The Adapter makes the Adaptee's interface compatible with the Target's
    // interface.
    class Adapter(Adaptee adaptee) : ITarget
    {
        public string GetRequest() => $"This is '{adaptee.GetSpecificRequest()}'";
    }

    public class ProgramAdapter
    {
        public static void Main__()
        {
            Adaptee adaptee = new();
            ITarget target = new Adapter(adaptee);
            Console.WriteLine(target.GetRequest());

            Console.ReadLine();
        }
    }
}