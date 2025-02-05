using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Explained by GPT o1
namespace syntax_NET_core
{
    internal class OverridingOverloadingShadowingExtension
    {
    }

    // ------------------------------------------------------------------------------------------------
    // 1. Method Overriding
    // Definition:

    // Occurs when a derived (child) class redefines a method inherited from its base (parent) class.
    // Requires use of the virtual, abstract, or override keywords.
    // Key Points:

    // Base class declares a method as virtual or abstract.
    // Derived class overrides that method with the override keyword.
    // Overriding maintains the same method signature (name, parameter types, and order).
    // Allows polymorphic behavior — calling the same method on different derived types can produce different results.

    public class Animal_
    {
        public virtual void Speak()
        {
            Console.WriteLine("Animal makes a sound.");
        }
    }

    public class Dog_ : Animal_
    {
        public override void Speak()
        {
            Console.WriteLine("Dog barks.");
        }
    }

    //// Usage:
    //Animal myDog = new Dog();
    //myDog.Speak();  // Outputs: "Dog barks."


    // ------------------------------------------------------------------------------------------------
    // 2. Method Overloading
    // Definition:

    // Occurs when you have multiple methods with the same name but different parameter lists within the same scope/class.
    // Key Points:

    // The methods differ by number, type, or order of parameters.
    // Return type alone does not differentiate overloaded methods.
    // Used for convenience, allowing methods that perform similar tasks with different inputs.
    public class MathOperations
{
    // Overload #1: Takes two integers
    public int Add(int x, int y)
    {
        return x + y;
    }

    // Overload #2: Takes three integers
    public int Add(int x, int y, int z)
    {
        return x + y + z;
    }
}

    //// Usage:
    //MathOperations ops = new MathOperations();
    //int sum1 = ops.Add(2, 3);    // Calls Add(int, int)
    //int sum2 = ops.Add(2, 3, 4); // Calls Add(int, int, int)


    // ------------------------------------------------------------------------------------------------
    // 3. Method Shadowing (Method Hiding)
    // Definition:

    // Also called method hiding, occurs when a derived class defines a new method (with the same name/signature as a base class method) without using override. Instead, it uses the new keyword.
    // Key Points:

    // Hiding a base method does not provide runtime polymorphism (unlike overriding).
    // It can lead to confusion because calls to that method can bind differently depending on the reference type (base class vs. derived class reference).
    // Considered a design choice if you want completely independent implementations for methods that just happen to share the same name.
    public class BaseClass
    {
        public void Show()
        {
            Console.WriteLine("Base Class Show");
        }
    }

    public class DerivedClass : BaseClass
    {
        public new void Show()  // 'new' indicates method hiding
        {
            Console.WriteLine("Derived Class Show");
        }
    }

    //// Usage:
    //BaseClass baseRef = new DerivedClass();
    //baseRef.Show();
    //// Outputs: "Base Class Show" because the method is not overridden, but hidden.

    //DerivedClass derivedRef = new DerivedClass();
    //derivedRef.Show();
    //// Outputs: "Derived Class Show"


    // ------------------------------------------------------------------------------------------------
    // 4. Extension Methods
    // Definition:

    // Static methods in a static class, which appear to “add” new methods to an existing type (class, struct, or interface) without modifying its source code.
    // The first parameter of the method is prefixed by the this keyword, indicating which type is being extended.
    // Key Points:

    // Allows you to call the extension method as if it were an instance method on the extended type.
    // Does not actually change the type itself; it’s just syntactic sugar for a static method call.
    // Commonly used to add utility or helper methods to .NET or third-party classes you can’t modify directly.
    public static class StringExtensions
    {
        public static bool IsLongerThan(this string str, int length)
        {
            return str.Length > length;
        }
    }

    //// Usage:
    //string example = "Hello World!";
    //bool isLong = example.IsLongerThan(5);
    //// Equates to StringExtensions.IsLongerThan(example, 5)

}
