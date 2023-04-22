using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace syntax
{
    internal static class Generics
    {
        internal static void Main__()
        {
            Utilities utility = new Utilities();
            utility.Title("GENERICS");

            // Anytime you need many overloaded methods that differ only in parameters, use "generics".

            // Example 1
            SomeClassWithoutPurpouse.SumTwoNumbers<int>(50, 60);
            SomeClassWithoutPurpouse.SumTwoNumbers<string>("50", "60");

            // Example 2
            decimal x = 100;
            decimal y = 400;
            SomeClassWithoutPurpouse.SumTwoNumbers_<decimal>(ref x, ref y);

            // Example 3 (My question below)
            SomeClassWithoutPurpouse.SumTwoNumbers__(5000, "6000");

            utility.Separator();

            // Example 4 at class
            Square<int> square1 = new Square<int>(5); // Classname<datatype>(classParameter)
            Console.WriteLine(square1.ComputeArea());
            Square<string> square2 = new Square<string>("50");
            Console.WriteLine(square2.ComputeArea());
        }

    }
    public static class SomeClassWithoutPurpouse
    {
        // 'T' represents here an unknown type, which will be known
        //  once the user of this function specifies it.
        public static void SumTwoNumbers<T>(T value1, T value2)
        {
            double value1Converted = Convert.ToDouble(value1);
            double value2Converted = Convert.ToDouble(value2);

            Console.WriteLine($"Result: {value1Converted + value2Converted}");
        }

        // With "ref" keyword, you will have to insert for example some variable, not number directly, because ref keyword means "reference".
        public static void SumTwoNumbers_<T>(ref T value1, ref T value2)
        {
            double value1Converted = Convert.ToDouble(value1);
            double value2Converted = Convert.ToDouble(value2);

            Console.WriteLine($"Result: {value1Converted + value2Converted}");
        }


        // TODO: How much different are atcually these two methods? Is it really necessary to use <T>, when we can just specifiy "object" before parameter?
        public static void SumTwoNumbers__(object value1, object value2)
        {
            double value1Converted = Convert.ToDouble(value1);
            double value2Converted = Convert.ToDouble(value2);
            Console.WriteLine($"Result: {value1Converted + value2Converted}");
        }
    }

    // Here "<T>" is again some place holder for datatype, that is going to be specified once the class is going to be used in practise. At this moment of declaration we do not know the datatype.
    public class Square<T> // The "<T>" hase to be there.
    {
        private T lengthOfOneSide;
        public T LengtOfOneSide
        {
            get { return lengthOfOneSide; }
            set { lengthOfOneSide = value; } 
        }
        public Square(T lengthOfOneSide) // The "T" has to be there also.
        {
            this.LengtOfOneSide = lengthOfOneSide;
        }
        public string ComputeArea()
        {
            double lengthConverted = Convert.ToDouble(lengthOfOneSide);

            return $"The area of square is: {lengthConverted * lengthConverted}";
        }
    } 
}
