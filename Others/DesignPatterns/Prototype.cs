
/*
The Prototype design pattern is a creational pattern that allows you to create new
objects by copying an existing object, known as the prototype.
This pattern is particularly useful when the process of creating an object is
resource-intensive, and you can gain performance by copying an existing instance
rather than creating a new one from scratch.


KEY COMPONENTS
1. PROTOTYPE:
An interface that declares the Clone method.

2. CONCRETE PROTOTYPE:
A class that implements the Clone method from the Prototype interface.

3. CLIENT:
A client that uses the prototype to create new objects.


IN MY OWN WORDS
If you expect to create copies of an object which already holds some data,
use the Prototype with shallow copy.

Benefits of using the prototype are that you do not have to go through this process
of creating a new object from scratch, setting many and many properties,
states or configurations.

Disadvantages of using the prototype are that you have to be careful with the
properties which are reference types. There is a possibility to have unwanted
side effects with those references. For that better use deep copy, which creates
independent objects.

Benefits of shallow copy are that you create a copy of the object much faster
compared to deep copy. Deep copy creates a new object and copies all the
properties and states of the original object.

Do not be confused by the word "prototype". It is not the same as the prototype
in factory production before series. Think of a prototype more like a cell division
in body.

Final remark, in the end you might not need to be limited only to shallow copy.
Use deep copy, or shallow copy with some custom logic, which can utilise deep copy
of some properties and shallow copy of the rest.
*/

namespace DesignPatterns
{

    // ------------------------------------------------------------------------------
    // 1. DEFINE THE PROTOTYPE INTERFACE:
    // Prototype Interface: The ICloneablePrototype interface declares the Clone
    // method, which returns a copy of the object.
    public interface ICloneablePrototype
    {
        ICloneablePrototype Clone();
    }

    // ------------------------------------------------------------------------------
    // 2. IMPLEMENT VARIOUS DIFFERENT PROTOTYPES:
    // Concrete Prototypes: The Circle and Rectangle classes implement the
    // ICloneablePrototype interface and provide the Clone method.
    // The MemberwiseClone method creates a shallow copy of the object.
    public class Circle(int radius) : ICloneablePrototype
    {
        public int Radius { get; set; } = radius;

        public MyHelperClass MyHelper { get; set; } = new();

        // Create a shallow copy of this Circle
        // Microsoft docs: The MemberwiseClone method creates a shallow copy by
        // creating a new object, and then copying the nonstatic fields of the
        // current object to the new object. If a field is a value type, a
        // bit-by-bit copy of the field is performed. If a field is a reference
        // type, the reference is copied but the referred object is not; therefore,
        // the original object and its clone refer to the same object.
        public ICloneablePrototype Clone() => (Circle)MemberwiseClone();

        public override string ToString() => $"Circle with radius {Radius}";
    }

    public class Rectangle(int width, int height) : ICloneablePrototype
    {
        public int Width { get; set; } = width;
        public int Height { get; set; } = height;

        // Create a shallow copy of this Rectangle
        // The same as for Circle
        public ICloneablePrototype Clone() => (Rectangle)MemberwiseClone();

        public override string ToString()
        {
            return $"Rectangle with width {Width} and height {Height}";
        }
    }

    // ------------------------------------------------------------------------------
    // 3. CLIENT CODE:
    // The client creates instances of Circle and Rectangle, clones them,
    // and modifies the clones to demonstrate that they are separate instances.
    public class ProgramPrototype
    {
        public static void Main__()
        {
            // Create an instance of Circle
            Circle circle1 = new(10);
            Console.WriteLine(circle1);

            // Clone the Circle
            Circle circle2 = (Circle)circle1.Clone();
            Console.WriteLine(circle2);

            // Modify the clone
            circle2.Radius = 20;
            Console.WriteLine(circle1);
            Console.WriteLine(circle2);

            // Demonstrate the properties with reference type are the same, when
            // shallow copy was used.
            Console.WriteLine(circle1.MyHelper.GetHashCode() == circle2.MyHelper.GetHashCode());

            // Demonstrate that if you explicitly create new instances, the hash
            // codes will be different.
            MyHelperClass myHelper1 = new();
            MyHelperClass myHelper2 = new();
            Console.WriteLine(myHelper1.GetHashCode()==myHelper2.GetHashCode());


            ConsoleOutputSeparator.Separator();


            // Create an instance of Rectangle
            Rectangle rect1 = new(7, 9);
            Console.WriteLine(rect1);

            // Clone the Rectangle
            Rectangle rect2 = (Rectangle)rect1.Clone();
            Console.WriteLine(rect2);

            // Modify the clone
            rect2.Width = 30;
            Console.WriteLine(rect1);
            Console.WriteLine(rect2);

            /*
            This output which goes into console shows that the original objects and their clones
            are separate instances. Modifying the clone does not affect the original object,
            demonstrating that the Clone method successfully creates a new instance.
            The Prototype pattern is useful when creating objects is resource-intensive,
            as it allows for creating new objects by copying existing ones.
             */
        }
    }

    /// <summary>
    /// This class is just used above do demonstrate if the referenced objects are the same
    /// when using shallow copy on object.
    /// </summary>
    public class MyHelperClass
    {
        public MyHelperClass(){}
    }
}
