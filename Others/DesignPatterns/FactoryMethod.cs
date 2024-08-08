
/*
COMPLEXITY OF PATTERN: EASY

The Factory Method design pattern is a creational pattern that provides an interface
for creating objects in a superclass, but allows subclasses to alter the type of
objects that will be created. This pattern lets a class defer instantiation to
subclasses.


KEY COMPONENTS
1. PRODUCT:
The interface or abstract class defining the objects that the factory method creates.

2. CREATOR:
The abstract class or interface that declares the factory method,
which returns an object of type Product. The Creator may also provide
some default implementation of the factory method.

3. CONCRETEPRODUCT:
Concrete implementations of the Product interface.

4. CONCRETECREATOR:
Subclasses of the Creator that override the factory method to return an
instance of a ConcreteProduct.

5. CLIENT
...

 */

namespace DesignPatterns
{
    // --------------------------------------------------------------------------
    // 1. DEFINE THE PRODUCT INTERFACE
    // An interface for objects the factory method creates.
    public interface ITransport
    {
        void Deliver();
    }

    // --------------------------------------------------------------------------
    // 2. DEFINE THE CREATOR CLASS
    // Declares the factory method.
    public abstract class Logistics
    {
        // The actual FACTORY method
        public abstract ITransport CreateTransport();

        public void PlanDelivery()
        {
            // Call the factory method to create a Product object.
            ITransport transport = CreateTransport();
            // Now use the product.
            transport.Deliver();
        }
    }

    // --------------------------------------------------------------------------
    // 3. IMPLEMENT CONCRETE PRODUCTS
    // Implements the Product interface.
    public class Truck : ITransport
    {
        public void Deliver() => Console.WriteLine("Deliver by land in a truck.");
    }

    public class Ship : ITransport
    {
        public void Deliver() => Console.WriteLine("Deliver by sea in a ship.");
    }

    public class SpaceShip : ITransport
    {
        public void Deliver() => Console.WriteLine("Deliver in space in a spaceship.");
    }

    // --------------------------------------------------------------------------
    // 4. IMPLEMENT CONCRETE CREATORS:
    // Implements the factory method to produce an instance of ConcreteProduct.
    public class RoadLogistics : Logistics
    {
        public override ITransport CreateTransport() => new Truck();
    }

    public class SeaLogistics : Logistics
    {
        public override ITransport CreateTransport() => new Ship();
    }

    public class SpaceLogistics : Logistics
    {
        public override ITransport CreateTransport() => new SpaceShip();
    }

    // --------------------------------------------------------------------------
    // 5. CLIENT CODE:
    public class ProgramFactoryMethod
    {
        // The client code creates instances of RoadLogistics and SeaLogistics
        // and calls the PlanDelivery method to demonstrate the use of the
        // Factory Method pattern.
        public static void Main__()
        {
            Logistics logistics;

            // Plan road delivery
            logistics = new RoadLogistics();
            logistics.PlanDelivery();

            // Plan sea delivery
            logistics = new SeaLogistics();
            logistics.PlanDelivery();

            // Plan space delivery
            logistics = new SpaceLogistics();
            logistics.PlanDelivery();
        }
    }

    /*
    BENEFITS OF THE FACTORY METHOD PATTERN
    Flexibility:
    The factory method pattern allows the code to be more flexible and reusable
    by decoupling the code that uses the product from the code that creates
    the product.

    Scalability:
    Adding new products or creators requires minimal changes to existing code,
    making the system scalable and easier to maintain.
    Single Responsibility Principle: The pattern adheres to the single responsibility
    principle by delegating the responsibility of instantiating products to specific
    creator classes.


    DRAWBACKS OF THE FACTORY METHOD PATTERN
    Complexity:
    The pattern can increase the overall complexity of the code by requiring
    additional classes and interfaces.

     */
}
