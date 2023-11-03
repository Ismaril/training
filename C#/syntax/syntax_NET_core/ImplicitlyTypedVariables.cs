using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax_NET_core
{
    //q: What is the aim of implicitly typed variables?
    //a: It is used to avoid writing the type of the variable twice.
    //   In another words, shorten the program and simplify it.
    // The type of the variable is determined by the compiler.

    public static class ImplicitlyTypedVariables
    {
        public static void Main__()
        {
            int number = 10; //explicitly typed variable
            var number2 = 10; //implicitly typed variable
            var string1 = "abc"; //implicitly typed variable

            // var number3; // this is not possible, because it is not initialized.
            // number3 = 10;

            System.Text.StringBuilder sb = new System.Text.StringBuilder(); //explicitly typed variable
            var sb2 = new System.Text.StringBuilder(); //implicitly typed variable

            int[] numbers = { 1, 2, 3, 4, 5 }; //explicitly typed variable
            foreach (int item in numbers) //explicitly typed variable
                Console.WriteLine(item);
            foreach (var item in numbers) //implicitly typed variable
                Console.WriteLine(item);

            //var numbers2 = { 1, 2, 3, 4, 5 }; // this is not possible, because it is not initialized.
            var numbers2 = new[] { 1, 2, 3, 4, 5 }; // this is possible, because it is initialized.

            System.Text.StringBuilder sb3 = new System.Text.StringBuilder();
            StringBuilder sb4 = new(); // Syntactic sugar. It is the same as the previous line.
            StringBuilder sb5 = new(1000); // It is of course possible to pass in parmeters.
            var sb6 = new StringBuilder(); //implicitly typed variable
        }
    }
}
