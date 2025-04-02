// OBSERVER PATTERN
// Observer is a behavioral design pattern that allows some objects to notify other objects about changes in their state.

/*
Usage examples:
The Observer pattern is pretty common in the GUI components.
It provides a way to react to events happening in other objects without coupling to their classes.

Identification:
The pattern can be recognized by subscription methods,
that store objects in a list and by calls to the update method issued to objects in that list.

Pros:
Open/Closed Principle. You can introduce new subscriber classes without
having to change the publisher’s code (and vice versa if there’s a publisher interface).
 */

#if true
// Observer interface
public interface ISubscriber
{
    // We'll pass the product name and a message
    void NotifyViaMail(string productName, string message);
}

// Publisher (real life example Store/Shop here)
public class Store
{
    // Maps productName -> list of subscribers for that product
    private Dictionary<string, List<ISubscriber>> productSubscribers = [];

    // Tracks if a product is available
    private Dictionary<string, bool> productAvailability = [];

    // Subscribe a customer to a particular product
    public void SubscribeProductAvailability(ISubscriber subscriber, string productName)
    {
        // Ensure the product is in our dictionary
        if (!productSubscribers.ContainsKey(productName))
        {
            productSubscribers[productName] = new List<ISubscriber>();
            productAvailability[productName] = false; // Initialize not available
        }

        // Add the subscriber if they're not already in the list
        if (!productSubscribers[productName].Contains(subscriber))
        {
            productSubscribers[productName].Add(subscriber);
        }
    }

    // Unsubscribe a customer from a particular product
    public void UnsubscribeProductAvailability(ISubscriber subscriber, string productName)
    {
        if (productSubscribers.ContainsKey(productName))
        {
            if (productSubscribers[productName].Contains(subscriber))
            {
                productSubscribers[productName].Remove(subscriber);
            }
        }
    }

    // Mark a product as available, then notify all subscribers for that product
    public void MakeProductAvailable(string productName)
    {
        if (!productAvailability.ContainsKey(productName))
        {
            // Initialize product lists in case they're not already set up
            productSubscribers[productName] = new List<ISubscriber>();
            productAvailability[productName] = false;
        }

        // Set the product to available
        productAvailability[productName] = true;

        // Notify only the subscribers who care about this product
        NotifySubscribers(productName, $"The {productName} is now available!");
    }

    // Notify all subscribers for a given product
    private void NotifySubscribers(string productName, string message)
    {
        if (productSubscribers.ContainsKey(productName))
        {
            foreach (var subscriber in productSubscribers[productName])
            {
                subscriber.NotifyViaMail(productName, message);
            }
        }
    }
}

// Concrete Subscriber
public class Customer : ISubscriber
{
    private string _name;

    public Customer(string name)
    {
        _name = name;
    }

    // Called by the Store to notify this customer about product availability
    public void NotifyViaMail(string productName, string message)
    {
        Console.WriteLine($"{_name} has been notified about {productName}: {message}");
    }
}

// Example usage
public class ProgramObserver
{
    public static void Main__()
    {
        // Create the store (publisher)
        Store store = new();

        // Create customers (subscribers)
        Customer alice = new("Alice");
        Customer bob = new("Bob");
        Customer charlie = new("Charlie");

        // Alice cares about iPhones
        store.SubscribeProductAvailability(alice, "iPhone");

        // Bob cares about iPads
        store.SubscribeProductAvailability(bob, "iPad");

        // Charlie cares about both
        store.SubscribeProductAvailability(charlie, "iPhone");
        store.SubscribeProductAvailability(charlie, "iPad");

        // Now, store sets the iPhone as available
        Console.WriteLine("Store: Setting iPhone as available...");
        store.MakeProductAvailable("iPhone");

        Console.WriteLine("1----------------------------------------------");

        // Next, store sets the iPad as available
        Console.WriteLine("Store: Setting iPad as available...");
        store.MakeProductAvailable("iPad");

        Console.WriteLine("2----------------------------------------------");

        // Suppose Bob changes his mind about iPhones
        store.SubscribeProductAvailability(bob, "iPhone");

        // If the store restocks the iPhone again (or a new iPhone model),
        // now Alice, Bob, and Charlie get notifications for iPhone
        Console.WriteLine("Store: iPhone restocked (or new model)...");
        store.MakeProductAvailable("iPhone");
    }
}





#endif
#if false
using System;
using System.Collections.Generic;

// 1) Define the delegate type for product availability notifications
public delegate void ProductAvailableHandler(string productName, string message);

// 2) Store (Publisher) using delegates/events
public class Store
{
    // Maps productName -> a delegate that can have multiple subscribers
    private Dictionary<string, ProductAvailableHandler> productEvents = new();

    // Tracks whether each product is available
    private Dictionary<string, bool> productAvailability = new();

    // Method for customers to subscribe to a specific product
    public void Subscribe(string productName, ProductAvailableHandler handler)
    {
        // Ensure this product is initialized in our dictionary
        if (!productEvents.ContainsKey(productName))
        {
            productEvents[productName] = null;            // Initialize the delegate
            productAvailability[productName] = false;     // Default not available
        }

        // Attach the customer's event handler
        productEvents[productName] += handler;
    }

    // Method for customers to unsubscribe from a specific product
    public void Unsubscribe(string productName, ProductAvailableHandler handler)
    {
        if (productEvents.ContainsKey(productName))
        {
            productEvents[productName] -= handler;
        }
    }

    // Mark a product as available and notify subscribers
    public void SetProductAvailable(string productName)
    {
        // If the product isn't in our dictionaries yet, initialize it
        if (!productAvailability.ContainsKey(productName))
        {
            productAvailability[productName] = false;
            productEvents[productName] = null;
        }

        // Mark it as available
        productAvailability[productName] = true;

        // Notify only the subscribers for this product
        productEvents[productName]?.Invoke(productName: productName, message: $"The {productName} is now available!");
    }
}

// 3) Customer (Subscriber)
public class Customer
{
    private string _name;

    public Customer(string name)
    {
        _name = name;
    }

    // This method matches the delegate signature:
    // (string productName, string message)
    public void OnProductAvailable(string productName, string message)
    {
        Console.WriteLine($"{_name} has been notified about {productName}: {message}");
    }
}

// 4) Example usage
public class ProgramObserver
{
    public static void Main__()
    {
        // Create the store
        Store store = new Store();

        // Create some customers
        Customer alice = new Customer("Alice");
        Customer bob = new Customer("Bob");
        Customer charlie = new Customer("Charlie");

        // Alice only cares about iPhone
        store.Subscribe("iPhone", alice.OnProductAvailable);

        // Bob only cares about iPad
        store.Subscribe("iPad", bob.OnProductAvailable);

        // Charlie cares about both
        store.Subscribe("iPhone", charlie.OnProductAvailable);
        store.Subscribe("iPad", charlie.OnProductAvailable);

        // Make iPhone available
        Console.WriteLine("Store: Setting iPhone as available...");
        store.SetProductAvailable("iPhone");

        Console.WriteLine();

        // Make iPad available
        Console.WriteLine("Store: Setting iPad as available...");
        store.SetProductAvailable("iPad");

        Console.WriteLine();

        // Now Bob changes his mind: also wants iPhone updates
        store.Subscribe("iPhone", bob.OnProductAvailable);

        // Store restocks or gets a new iPhone model
        Console.WriteLine("Store: Another iPhone is now available...");
        store.SetProductAvailable("iPhone");
    }
}
#endif
