/*
The Singleton design pattern is a creational pattern that ensures a class has
only one instance and provides a global point of access to that instance.
This pattern is useful when exactly one instance of a class is needed to
coordinate actions across the system.


EXPLANATION
Private Constructor: The constructor is private to prevent direct instantiation.
Static Instance: A static variable holds the single instance of the class.
Global Access Point: A static property (Instance) provides a global point of access to the instance.
Thread Safety: The implementation using Lazy<T> or the lock keyword ensures that the Singleton instance is created in a thread-safe manner.

BENEFITS OF SINGLETON PATTERN
Controlled Access to the Single Instance: The Singleton class controls the instantiation of its single instance, ensuring that there is no more than one instance at any time.
Reduced Global Variables: It provides a single point of access, reducing the need for global variables that can be modified from any part of the program.
Lazy Initialization: The instance is created only when it is needed, which can improve performance and resource utilization.

DRAWBACKS OF SINGLETON PATTERN
Global State: Singletons can introduce global state into an application, making it harder to understand and test.
Hidden Dependencies: It can be easy to overuse Singletons, leading to hidden dependencies between classes.
Difficulty in Unit Testing: Singletons can make unit testing difficult because they carry state between tests. Using dependency injection can mitigate this issue.
The Singleton pattern is widely used and can be very effective when used appropriately. However, it should be used judiciously to avoid the pitfalls associated with global state and hidden dependencies.
 */

namespace DesignPatterns
{

    public class Singleton
    {
        private static Singleton _instance;

        // Private constructor to prevent instantiation
        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                // if instance is null, create a new instance
                _instance ??= new Singleton();
                return _instance;
            }
        }

        public void DoSomething()
        {
            Console.WriteLine("Singleton instance method called.");
        }
    }

    public class ProgramSingleton
    {
        public static void Main__()
        {
            Singleton singleton1 = Singleton.Instance;
            Singleton singleton2 = Singleton.Instance;

            singleton1.DoSomething();

            if (singleton1.GetHashCode() == singleton2.GetHashCode())
                Console.WriteLine("Both instances are the same.");
            else
                Console.WriteLine("Instances are different.");
        }
    }
}

