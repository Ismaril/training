namespace Prototype
{
    // 2. IMPLEMENT VARIOUS DIFFERENT PROTOTYPES:
    /*
    Concrete Prototypes: The Circle and Rectangle classes implement the 
    ICloneablePrototype interface and provide the Clone method. 
    The MemberwiseClone method creates a shallow copy of the object.
     */

    public class Circle : ICloneablePrototype
    {
        public int Radius { get; set; }

        public Circle(int radius)
        {
            Radius = radius;
        }

        public ICloneablePrototype Clone()
        {
            // Create a shallow copy of this Circle
            return (Circle)this.MemberwiseClone();
        }

        public override string ToString()
        {
            return $"Circle with radius {Radius}";
        }
    }

    public class Rectangle : ICloneablePrototype
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public ICloneablePrototype Clone()
        {
            // Create a shallow copy of this Rectangle
            return (Rectangle)this.MemberwiseClone();
        }

        public override string ToString()
        {
            return $"Rectangle with width {Width} and height {Height}";
        }
    }
}
