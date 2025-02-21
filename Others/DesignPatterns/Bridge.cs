﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// COMPLEXITY OF PATTERN: HARD

namespace DesignPatterns
{
    // The Implementation defines the interface for all implementation classes.
    // It doesn't have to match the Abstraction's interface. In fact, the two
    // interfaces can be entirely different. Typically the Implementation
    // interface provides only primitive operations, while the Abstraction
    // defines higher- level operations based on those primitives.
    public interface IImplementation
    {
        string OperationImplementation();
    }

    // The Abstraction defines the interface for the "control" part of the two
    // class hierarchies. It maintains a reference to an object of the
    // Implementation hierarchy and delegates all of the real work to this
    // object.
    class Abstraction(IImplementation implementation)
    {
        protected IImplementation _implementation = implementation;

        public virtual string Operation()
        {
            return "Abstract: Base operation with:\n" + _implementation.OperationImplementation();
        }
    }

    // You can extend the Abstraction without changing the Implementation
    // classes.
    class ExtendedAbstraction(IImplementation implementation) : Abstraction(implementation)
    {
        public override string Operation()
        {
            return "ExtendedAbstraction: Extended operation with:\n"
                + base._implementation.OperationImplementation();
        }
    }

    // Each Concrete Implementation corresponds to a specific platform and
    // implements the Implementation interface using that platform's API.
    class ConcreteImplementationA : IImplementation
    {
        public string OperationImplementation()
        {
            return "ConcreteImplementationA: The result in platform A.\n";
        }
    }

    class ConcreteImplementationB : IImplementation
    {
        public string OperationImplementation()
        {
            return "ConcreteImplementationB: The result in platform B.\n";
        }
    }

    class ClientCode_
    {
        // Except for the initialization phase, where an Abstraction object gets
        // linked with a specific Implementation object, the client code should
        // only depend on the Abstraction class. This way the client code can
        // support any abstraction-implementation combination.
        public void ClientCode(Abstraction abstraction) => Console.Write(abstraction.Operation());
    }

    public class ProgramBridge
    {
        public static void Main__()
        {
            ClientCode_ client = new();

            Abstraction abstraction;
            // The client code should be able to work with any pre-configured
            // abstraction-implementation combination.
            abstraction = new Abstraction(new ConcreteImplementationA());
            client.ClientCode(abstraction);

            ConsoleOutputSeparator.Separator();

            abstraction = new ExtendedAbstraction(new ConcreteImplementationB());
            client.ClientCode(abstraction);
        }
    }
}
