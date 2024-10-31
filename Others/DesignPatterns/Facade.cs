using System;

namespace DesignPatterns
{
#if false

    // COMPLEXITY OF PATTERN: EASY
    // Facade is a structural design pattern that provides
    // a simplified interface to a library, a framework, or any other complex set of classes.

    // The Facade class provides a simple interface to the complex logic of one
    // or several subsystems. The Facade delegates the client requests to the
    // appropriate objects within the subsystem. The Facade is also responsible
    // for managing their lifecycle. All of this shields the client from the
    // undesired complexity of the subsystem.
    public class Facade(Subsystem1 subsystem1, Subsystem2 subsystem2)
    {
        protected Subsystem1 _subsystem1 = subsystem1;
        protected Subsystem2 _subsystem2 = subsystem2;

        // The Facade's methods are convenient shortcuts to the sophisticated
        // functionality of the subsystems. However, clients get only to a
        // fraction of a subsystem's capabilities.
        public string Operation()
        {
            string result = "Facade initializes subsystems:\n";
            result += _subsystem1.Operation1();
            result += _subsystem2.Operation1();
            result += "Facade orders subsystems to perform the action:\n";
            result += _subsystem1.OperationN();
            result += _subsystem2.OperationZ();
            return result;
        }
    }

    // The Subsystem can accept requests either from the facade or client
    // directly. In any case, to the Subsystem, the Facade is yet another
    // client, and it's not a part of the Subsystem.
    public class Subsystem1
    {
        public string Operation1() => "Subsystem1: Ready!\n";
        public string OperationN() => "Subsystem1: Go!\n";
    }

    // Some facades can work with multiple subsystems at the same time.
    public class Subsystem2
    {
        public string Operation1() => "Subsystem2: Get ready!\n";
        public string OperationZ() => "Subsystem2: Fire!\n";
    }

    public class Client___
    {
        // The client code works with complex subsystems through a simple
        // interface provided by the Facade. When a facade manages the lifecycle
        // of the subsystem, the client might not even know about the existence
        // of the subsystem. This approach lets you keep the complexity under
        // control.
        public static void ClientCode(Facade facade)
        {
            Console.Write(facade.Operation());
        }
    }

    public class ProgramFacade
    {
        public static void Main__()
        {
            // The client code may have some of the subsystem's objects already
            // created. In this case, it might be worthwhile to initialize the
            // Facade with these objects instead of letting the Facade create
            // new instances.
            Facade facade = new(new Subsystem1(), new Subsystem2());
            Client___.ClientCode(facade);
        }
    }
#endif

    // COMPLEXITY OF PATTERN: EASY
    // THE FACADE DESIGN PATTERN IS A STRUCTURAL DESIGN PATTERN THAT PROVIDES A SIMPLIFIED INTERFACE TO A COMPLEX SUBSYSTEM.

    // KEY CONCEPTS
    // Simplification: Offers a simple interface to complex subsystems.
    //  - Facade provides a limited functionality of the subsystem but
    //    thats ok, it contains only enough to meet the client's needs.
    // Decoupling: Reduces dependencies between clients and subsystems.
    //  - Meaning you no longer have to take care about all the initializations,
    //    configurations, dependencies, executing methods in correct order, ...
    //  - Advantages of decoupling - you are working with a simple facade instead of
    //    the complex subsystem -> therefore easier to maintain, test, and understand.

    // FLEXIBILITY:
    // Changes in subsystems do not affect client code as long as the facade's interface remains the same.

    // ANALOGY
    // Imagine a home entertainment system with multiple devices:
    // a TV, a sound system, a DVD player, and gaming consoles.
    // Instead of turning on each device individually and setting them up, you
    // use a universal remote control (the facade) that simplifies the process
    // into pressing a single button.
    //
    // Or it can be just as simple as importing a library/libraries, and stuffing inside your Facade class some
    // of the library's methods, and having a simple facade method which solve some client problem.

    // C# Example
    // Let's consider an example where we have a complex system for processing orders
    // in an online store. The system includes several subsystems:
    // inventory management, payment processing, and shipping.

    // ------------------------------------------------------------------------------------------------
    // 1.
    //SUBSYSTEM CLASSES ("the complex logic")

    //Inventory System
    public class InventorySystem
    {
        public bool CheckInventory(string productId)
        {
            Console.WriteLine($"Checking inventory for product {productId}.");
            // Logic to check inventory
            return true; // Assume the product is available
        }

        public void UpdateInventory(string productId)
        {
            Console.WriteLine($"Updating inventory for product {productId}.");
            // Logic to update inventory
        }

        // ...
        //
        // Another methods and complex logic
        //
        // ...
    }

    // Payment System
    public class PaymentSystem
    {
        public bool ProcessPayment(string customerId, double amount)
        {
            Console.WriteLine($"Processing payment of ${amount} for customer {customerId}.");
            // Logic to process payment
            return true; // Assume payment is successful
        }

        // ...
        //
        // Another methods and complex logic
        //
        // ...
    }

    // Shipping System
    public class ShippingSystem
    {
        public void ShipProduct(string productId, string customerId)
        {
            Console.WriteLine($"Shipping product {productId} to customer {customerId}.");
            // Logic to ship product
        }

        // ...
        //
        // Another methods and complex logic
        //
        // ...
    }

    // ------------------------------------------------------------------------------------------------
    // 2.
    // FACADE CLASS
    public class OrderFacade
    {
        private InventorySystem _inventory;
        private PaymentSystem _payment;
        private ShippingSystem _shipping;

        public OrderFacade()
        {
            _inventory = new InventorySystem();
            _payment = new PaymentSystem();
            _shipping = new ShippingSystem();
        }

        public void PlaceOrder(string productId, string customerId, double amount)
        {
            if (_inventory.CheckInventory(productId))
            {
                if (_payment.ProcessPayment(customerId, amount))
                {
                    _shipping.ShipProduct(productId, customerId);
                    _inventory.UpdateInventory(productId);
                    Console.WriteLine("Order processed successfully.");
                }
                else
                {
                    Console.WriteLine("Payment failed. Order not processed.");
                }
            }
            else
            {
                Console.WriteLine("Product is out of stock. Order cannot be processed.");
            }
        }
    }

    // ------------------------------------------------------------------------------------------------
    // 3.
    // CLIENT CODE
    public class ProgramFacade
    {
        public static void Main__()
        {
            // Client interacts with the facade instead of subsystems
            OrderFacade orderFacade = new();

            string productId = "P123";
            string customerId = "C456";
            double amount = 99.99;

            orderFacade.PlaceOrder(productId, customerId, amount);

            // Output:
            // Checking inventory for product P123.
            // Processing payment of $99.99 for customer C456.
            // Shipping product P123 to customer C456.
            // Updating inventory for product P123.
            // Order processed successfully.
        }
    }
    // ------------------------------------------------------------------------------------------------

    // EXTRAS:
    // 1. You are not limited to a single facade. You can have multiple facades for different subsystems.
    //  - You can have for example a different facades where each accesses a different layer of the system.
    // 2. If the facade becomes too big, you can create a facade for the facade.
    // 3. Unfortunatelly the facade can become A God object = in programming refers to an anti-pattern
    //  where a single object or class is overloaded with excessive responsibilities,
    //  violating the Single Responsibility Principle (SRP).

    // HOW IS FACADE DESIGN PATTERN DIFFERENT TO ADAPTER OR DECORATOR?
    // 1. Adapter pattern - allows objects with incompatible interfaces to work together.
    // 2. Decorator pattern - allows adding new functionality to an object without altering its structure.
    // 3. Facade pattern - provides a simplified interface to a complex system of classes.


}