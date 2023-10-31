using System;

// Define a delegate type
public delegate void MessageDelegate(string message);

// Class that contains a delegate
public class Messenger
{
    // Delegate field
    private MessageDelegate messageHandler;

    // Method to register the delegate
    public void RegisterMessageHandler(MessageDelegate handler)
    {
        messageHandler = handler;
    }

    // Method that triggers the delegate
    // This is a wrapper method that allows the delegate to be triggered from outside of
    //  the class. Basically you can now through RegisterMessageHandler() assign any method
    //  from the outside to the delegate as long as it matches the signature of the delegate.
    //  This is good for us because we don't have to change the class itself.
    public void SendMessage(string message)
    {
        // Check if the delegate is assigned
        if (messageHandler != null)
        {
            // Invoke the delegate
            messageHandler(message);
        }
    }
}

// UNCOMMENT THIS IF YOU WANT TO SEE THE EXAMPLE IN ACTION
//  (Dont forget co comment out the main function in Program.cs)
/*
// Example usage
public class Program
{
    static void Main(string[] args)
    {
        Messenger messenger = new Messenger();

        // Register the delegate
        messenger.RegisterMessageHandler(DisplayMessage);

        // Send a message, triggering the delegate
        messenger.SendMessage("Hello, World!");
    }

    // Method that matches the signature of the delegate
    static void DisplayMessage(string message)
    {
        Console.WriteLine($"Received message: {message}");
    }
}
*/