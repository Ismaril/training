
/*
The Prototype design pattern is a creational pattern that allows you to create new
objects by copying an existing object, known as the prototype.
This pattern is particularly useful when the process of creating an object is
resource-intensive, and you can gain performance by copying an existing instance rather
than creating a new one from scratch.


KEY COMPONENTS
1. PROTOTYPE:
An interface that declares the Clone method.

2. CONCRETE PROTOTYPE:
A class that implements the Clone method from the Prototype interface.

3. CLIENT:
A client that uses the prototype to create new objects.
*/

namespace DesignPatterns
{

    // --------------------------------------------------------------------------
    // 1. DEFINE THE PROTOTYPE INTERFACE:
    // Prototype Interface: The ICloneablePrototype interface declares the Clone method,
    // which returns a copy of the object.
    public interface ICloneablePrototype
    {
        ICloneablePrototype Clone();
    }

    // --------------------------------------------------------------------------
    // 2. IMPLEMENT VARIOUS DIFFERENT PROTOTYPES:
    // Concrete Prototypes: The Circle and Rectangle classes implement the
    // ICloneablePrototype interface and provide the Clone method.
    // The MemberwiseClone method creates a shallow copy of the object.
    public class Circle(int radius) : ICloneablePrototype
    {
        public int Radius { get; set; } = radius;

        // Create a shallow copy of this Circle
        public ICloneablePrototype Clone() => (Circle)MemberwiseClone();

        public override string ToString() => $"Circle with radius {Radius}";
    }

    public class Rectangle(int width, int height) : ICloneablePrototype
    {
        public int Width { get; set; } = width;
        public int Height { get; set; } = height;

        // Create a shallow copy of this Rectangle
        public ICloneablePrototype Clone() => (Rectangle)MemberwiseClone();

        public override string ToString()
        {
            return $"Rectangle with width {Width} and height {Height}";
        }
    }
    public class ProgramPrototype
    {
        // --------------------------------------------------------------------------
        // 3. CLIENT CODE:
        // The client creates instances of Circle and Rectangle, clones them,
        // and modifies the clones to demonstrate that they are separate instances.
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
}
