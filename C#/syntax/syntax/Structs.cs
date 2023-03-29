using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax
{
    internal static class Structs
    {
        internal static void Main__()
        {
            Utilities utility = new Utilities();

            utility.Title("STRUCTS");

            Rectangle someRectangle = new Rectangle(length: 30, width: 4);
            Console.WriteLine(someRectangle.Area());

            // this does the same as above
            Rectangle someRectangle2;
            someRectangle2.length = 30;
            someRectangle2.width = 4;
            Console.WriteLine(someRectangle2.Area());

            utility.Separator();

        }

    }
    struct Rectangle
    {
        public double length;
        public double width;

        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }

        public double Area()
        {
            return this.length * this.width;
        }

    }
}
