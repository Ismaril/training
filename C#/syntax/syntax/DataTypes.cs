using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace syntax
{
    internal static class DataTypes
    {
        internal static void Main__()
        {
            Utilities utility = new Utilities();

            utility.Title("DATATYPES");

            // Most basic ones
            string some_phrase = "This is just some sentence";
            char some_character = 'a';  // single qoutes necessary for char type
            int some_integer = 1;
            float some_float = 3.4F; // Have to append a F letter (float)
            double some_double = 4.5555555555;
            bool some_boolean = false;

            Console.WriteLine(some_phrase);
            Console.WriteLine(some_character);
            Console.WriteLine(some_integer);
            Console.WriteLine(some_float);
            Console.WriteLine(some_double);
            Console.WriteLine(some_boolean);


            utility.Separator();


            // Explained in detail:
            // Todo: update this section

            // Scientific 'e', to indicate the power of 10.
            float f1 = 35e3F;
            double d1 = 12E4D;
            Console.WriteLine(f1);
            Console.WriteLine(d1);


            utility.Separator();


            // Type casting
            // Type casting is when you assign a value of one data type to another type. 
            //
            // Implicit Casting (automatically) - converting a smaller type to a larger type size
            // char -> int -> long -> float -> double 
            //
            // Explicit Casting (manually) - converting a larger type to a smaller size type
            // double -> float -> long -> int -> char

            
            int myInt = 9;
            double myDouble = myInt;       // Automatic casting: int to double
            Console.WriteLine(myInt);      // Outputs 9
            Console.WriteLine(myDouble);   // Outputs 9 (TL: seems like it does not output 9.*)


            double myDouble_2 = 9.78;
            int myInt_2 = (int)myDouble_2;    // Manual casting: double to int
            Console.WriteLine(myDouble_2);   // Outputs 9.78
            Console.WriteLine(myInt_2);      // Outputs 9


            // Some explicit type conversion methods:
            int myInt_3 = 10;
            double myDouble_3 = 5.25;
            bool myBool = true;

            Console.WriteLine(Convert.ToString(myInt_3));    // convert int to string
            Console.WriteLine(Convert.ToDouble(myInt_3));    // convert int to double
            Console.WriteLine(Convert.ToInt32(myDouble_3));  // convert double to int
            Console.WriteLine(Convert.ToString(myBool));   // convert bool to string


            utility.Separator();


        }
    }
}
