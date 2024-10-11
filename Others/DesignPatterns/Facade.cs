using System;

// COMPLEXITY OF PATTERN: EASY
// Facade is a structural design pattern that provides
// a simplified interface to a library, a framework, or any other complex set of classes.

namespace DesignPatterns
{
    //// The Facade class provides a simple interface to the complex logic of one
    //// or several subsystems. The Facade delegates the client requests to the
    //// appropriate objects within the subsystem. The Facade is also responsible
    //// for managing their lifecycle. All of this shields the client from the
    //// undesired complexity of the subsystem.
    //public class Facade(Subsystem1 subsystem1, Subsystem2 subsystem2)
    //{
    //    protected Subsystem1 _subsystem1 = subsystem1;
    //    protected Subsystem2 _subsystem2 = subsystem2;

    //    // The Facade's methods are convenient shortcuts to the sophisticated
    //    // functionality of the subsystems. However, clients get only to a
    //    // fraction of a subsystem's capabilities.
    //    public string Operation()
    //    {
    //        string result = "Facade initializes subsystems:\n";
    //        result += _subsystem1.Operation1();
    //        result += _subsystem2.Operation1();
    //        result += "Facade orders subsystems to perform the action:\n";
    //        result += _subsystem1.OperationN();
    //        result += _subsystem2.OperationZ();
    //        return result;
    //    }
    //}

    //// The Subsystem can accept requests either from the facade or client
    //// directly. In any case, to the Subsystem, the Facade is yet another
    //// client, and it's not a part of the Subsystem.
    //public class Subsystem1
    //{
    //    public string Operation1() => "Subsystem1: Ready!\n";
    //    public string OperationN() => "Subsystem1: Go!\n";
    //}

    //// Some facades can work with multiple subsystems at the same time.
    //public class Subsystem2
    //{
    //    public string Operation1() => "Subsystem2: Get ready!\n";
    //    public string OperationZ() => "Subsystem2: Fire!\n";
    //}

    //public class Client___
    //{
    //    // The client code works with complex subsystems through a simple
    //    // interface provided by the Facade. When a facade manages the lifecycle
    //    // of the subsystem, the client might not even know about the existence
    //    // of the subsystem. This approach lets you keep the complexity under
    //    // control.
    //    public static void ClientCode(Facade facade)
    //    {
    //        Console.Write(facade.Operation());
    //    }
    //}

    //public class ProgramFacade
    //{
    //    public static void Main__()
    //    {
    //        // The client code may have some of the subsystem's objects already
    //        // created. In this case, it might be worthwhile to initialize the
    //        // Facade with these objects instead of letting the Facade create
    //        // new instances.
    //        Facade facade = new(new Subsystem1(), new Subsystem2());
    //        Client___.ClientCode(facade);
    //    }
    //}

    // The Facade Design Pattern is a structural design pattern that provides a simplified interface to a complex subsystem. It hides the complexities of the system and provides a unified interface that is easier to use. This pattern is particularly useful when dealing with complex libraries or APIs, where you want to expose only the necessary functionality to the client.

    // Key Concepts
    // Simplification: Offers a simple interface to complex subsystems.
    // Decoupling: Reduces dependencies between clients and subsystems.
    // Flexibility: Changes in subsystems do not affect client code as long as the facade's interface remains the same.

    // Analogy
    // Imagine a home entertainment system with multiple devices:
    // a TV, a sound system, a DVD player, and gaming consoles.
    // Instead of turning on each device individually and setting them up, you
    // use a universal remote (the facade) that simplifies the process into pressing a single button.

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
    }

    // Shipping System
    public class ShippingSystem
    {
        public void ShipProduct(string productId, string customerId)
        {
            Console.WriteLine($"Shipping product {productId} to customer {customerId}.");
            // Logic to ship product
        }
    }

    // ------------------------------------------------------------------------------------------------
    // 2.
    // FACADE CLASS
    // Facade
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
        static void Main__(string[] args)
        {
            // Client interacts with the facade instead of subsystems
            OrderFacade orderFacade = new OrderFacade();

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


}