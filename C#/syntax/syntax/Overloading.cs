using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax
{
    public class Overloading
    {
        // You can overload these operators:
        // +, -, *, /, %, !, ==, !=, >, <, >=, <=, ++, --
        public static void Main__()
        {
            Utilities utility = new Utilities();
            utility.Title("OVERLOADING"); 

            Box box1 = new Box(length: 1, width: 1, height: 1);
            Box box2 = new Box(length: 5, width: 10, height: 10);

            // Add two boxes together (Add corresponding sides togheter)
            Box box3 = box1 + box2;
            Console.WriteLine($"Length: {box3.Length}");
            
            // Subtract sides of boxes.
            Box box4 = box2 - box1;
            Console.WriteLine($"Height: {box4.Height}");

            // Compare boxes.
            Console.WriteLine(box2==box3);

            utility.Separator();
            
            // Convert implicitly to "int".
            int box5 = box1;
            Console.WriteLine(box5);
            // Explicit conversion.
            Console.WriteLine((int)box1);

            // Convert integer to Box.
            // Todo: Seems like it explicitly converts it right, according to my "overload" method, but instead of returning "Box" object, it returns value according to overloaded int. I tested to comment out the overloaded int method, but then it returns it based on overloaded "ToString" method. After commenting out overloaded "ToString" it finally returned just Box object.
            Box box6 = (Box)500;
            Console.WriteLine(box6);
            Console.WriteLine(box6.Width); // This is corret.

            // Convert object to string.
            Console.WriteLine(box4.ToString());
        }

    
    }

    class Box
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        // Assigin default parameter to each Property.
        public Box() : this(1, 1, 1) { }

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        // Overload '+' operator when it is used with Box.
        // This will now allow to "add" two Boxes together and it will do exactly what
        //   you gonna specify during that overloading.
        // If you did not specify/overload the '+' operator, addition of your custom objects
        //  would not be possible.
        
        public static Box operator +(Box box1, Box box2)
        {
            Box box = new Box()
            {
                Length = box1.Length + box2.Length,
                Width = box1.Width + box2.Width,
                Height = box1.Height + box2.Height
            }; 
            return box;
        }

        public static Box operator -(Box box1, Box box2)
        {
            Box box = new Box()
            {
                Length = box1.Length - box2.Length,
                Width = box1.Width - box2.Width,
                Height = box1.Height - box2.Height
            };
            return box;
        }
        
        // If you want to overload for eaxmple "==", you have to also then overload "!=" else it will throw and error.
        public static bool operator ==(Box box1, Box box2)
        {
            if (box1.Length == box2.Length
                 && box1.Width == box2.Width
                 && box1.Height == box2.Height)
            {
                return true;
            }
            return false;
        } 
        public static bool operator !=(Box box1, Box box2)
        {
            if (box1.Length != box2.Length
                 || box1.Width != box2.Width
                 || box1.Height != box2.Height)
            {
                return true;
            }
            return false;
        }

        // Do the same here as you did above with +, -, etc... operators, but here do it with actual data type like int.
        // Here "implicit" keyword means that this method is going to apply when there is an implicit conversion. (Actually "explicit" conversion also worked with this overload)
        // When I tested "explicit" keyword instead below, the conversion worked only when explicitely converting to int.
        public static implicit operator int(Box box)
        {
            return (int) (box.Length + box.Width + box.Height);
        }
        
        // Define whats gonna happend when you want to convert integer into Box.
        // Box(int i) is actually like (Box)someNumber in the Main__.
        public static explicit operator Box(int i)
        {
            // Just return new box object, with input integer parameter equal to each Property.
            return new Box(i, i, i);
        }

        // Define what is goind to happen when you convert the object ToString.
        // Just random shit below. You could override it with anything depengind what you want.
        public override string ToString()
        {
            return $"Box width: {this.Width}, height: {this.Height} and length: {this.Length}";
        }

    }
}
