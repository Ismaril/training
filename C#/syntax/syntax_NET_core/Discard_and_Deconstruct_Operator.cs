using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax_NET_core
{
    internal static class Discard_and_Deconstruct_Operator
    {
        public static void Main__()
        {
            Utilities utilities = new();
            utilities.PrintLine();

            Rectangle rectangle = new(10, 20);
            // Below we declare variables directly in the method call. You can then use them just as if
            //  you would declare them before the method call on their own.
            // Note that in older versions of C# you would have to declare the variables before the method call.
            //  It would not be possible to declare them directly in the method call just as we do below.
            rectangle.Stats_OutFunction(out double area, out double perimeter, out double width, out double height);
            Console.WriteLine($"Area: {area}, Perimeter: {perimeter}, Width: {width}, Height: {height}.");

            utilities.PrintLine();

            // DISCARD OPERATOR "_"
            // You can use discard operator  to discard values that you do not need.
            // You can use discard operator in the method call as well.
            rectangle.Stats_OutFunction(out double area2, out _, out double width2, out _);
            Console.WriteLine($"Area: {area2}, Width: {width2}.");

            utilities.PrintLine();

            // DECONSTRUCT OPERATOR
            // Possible to deconstut only tuples by default.
            // This basically means that from the function which returns multiple values (for example) you
            //  then deconstruct all those values into multiple variables at one line. Just like in python.
            Rectangle rectangle3 = new(30, 40);
            // You can use deconstruct operator to deconstruct the object into multiple variables.
            (double width3, double height3, double area3, double perimeter3) = rectangle3.Stats_ValueTuple();
            Console.WriteLine($"Width: {width3}, Height: {height3}, Area: {area3}, Perimeter: {perimeter3}.");

            utilities.PrintLine();

            // DISCARD OPERATOR IN DECONSTRUCT OPERATOR
            // Notice, that is is also possible to use "var" keyword in the deconstruct operator.
            Rectangle rectangle4 = new(50, 60);
            (double width4, _, var area4, _) = rectangle4.Stats_ValueTuple();
            Console.WriteLine($"Width: {width4}, Area: {area4}.");

            utilities.PrintLine();

            // DECONSTRUCT CUSTOM DATA TYPE
            // Code below is not possible, if you do not implement the deconstruct method in the Rectangle class.
            // Rectangle rectangle5 = new(70, 80);
            //var (width, height) = rectangle5;

            // Note since the we have implemented the deconstruct method in the Rectangle class, we can now
            //  deconstruct the constructor into multiple variables.
            // We also overloaded the deconstruct method in the Rectangle class, so we can deconstruct the
            //  constructor into either 2 or 4 variables.
            Rectangle rectangle6 = new(90, 100);
            var (width6, height6, area6, perimeter6) = rectangle6;
            Console.WriteLine($"Width: {width6}, Height: {height6}, Area: {area6}, Perimeter: {perimeter6}.");
            Rectangle rectangle7 = new(110, 120);
            var (width7, height7) = rectangle7;
            Console.WriteLine($"Width: {width7}, Height: {height7}.");

            // Also all still possible with the discard operator.
            Rectangle rectangle8 = new(130, 140);
            var (width8, _, area8, _) = rectangle8;
            Console.WriteLine($"Width: {width8}, Area: {area8}.");
        }
    }

    class Rectangle
    {
        double a, b;

        // Ctor.
        public Rectangle(double a, double b) { this.a = a; this.b = b; }

        // Out parameters will be used to return multiple values from a method. See example in the main method.
        public void Stats_OutFunction(
            out double area,
            out double perimeter,
            out double width,
            out double height
            )
        {
            area = a * b;
            perimeter = 2 * (a + b);
            width = a;
            height = b;
        }

        // Using value tuple fyi.
        public (double width, double height, double area, double perimeter) Stats_ValueTuple()
        {
            return (a, b, a * b, 2 * (a + b));
        }

        public void Deconstruct(out double width, out double height)
        {
            width = a;
            height = b;
        }

        // Overload the deconstruct method if you want to deconstruct the object into more variables for example.
        public void Deconstruct(out double width, out double height, out double area, out double perimeter)
        {
            width = a;
            height = b;
            area = a * b;
            perimeter = 2 * (a + b);
        }
    }
}
