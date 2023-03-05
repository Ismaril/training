using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Automatically format a document in visual studio.
            // CTRL+K then press CTRL+D (no caps lock needed)


            // DRAWING A SHAPE
            //  See that the execution of code
            //  is line by line.
            Console.WriteLine("Hello world");
            Console.WriteLine("   /|");
            Console.WriteLine("  / |");
            Console.WriteLine(" /  |");
            Console.WriteLine("/___|\n");


            // VARIABLES
            string character_name = "Tom";
            int character_age;
            character_age = 30; // see that it is possible to asign value later
            Console.WriteLine($"There once was a {character_name}."); // fstrings
            Console.WriteLine($"And he was {character_age} years old."); // fstrings
            // it is possible to also concatenate strings with '+' sign.
            Console.WriteLine("The name is " + character_name + " and he's a human.");

            character_age = 31;
            Console.WriteLine($"A year has passed and now his age is {character_age}");

            // possible to assign in one row
            // todo: check if it is possible without brackets
            var (color, height, width) = ("red", "tall", "narrow");
            Console.WriteLine((color, width, height));

            // DATATYPES
            string some_phrase = "This is just some sentence";
            char some_character = 'a';  // single qoutes necessary for char type
            int some_integer = 1;
            float some_float = 3.4f; // have to append the f letter?
            double some_double = 4.5555555555;
            bool some_boolean = false;

            Console.WriteLine(some_phrase);
            Console.WriteLine(some_character);
            Console.WriteLine(some_integer);
            Console.WriteLine(some_float);
            Console.WriteLine(some_double);
            Console.WriteLine(some_boolean + "\n");


            // STRINGS
            // Escape characters:
            // \n - new line
            // \t - tab
            // \ - make the following character just string

            Console.WriteLine("Escape characters:\n" +
                "New line \n" +
                "Tab \t some text\n" +
                "Single qoute is possible without backslash'\n" +
                "Backslash has to be used with another backlash \\ \n" +
                "And so on...\n");

            // possible to concatenate during assignement to variable
            string some_sentence = "First sentence " + "Second sentence";
            Console.WriteLine(some_sentence);

            // check lenth of string
            Console.WriteLine($"String length: {some_sentence.Length}");

            // STRING METHODS
            string some_string = "Mazooon je veliky";
            Console.WriteLine(some_string.ToLower());
            Console.WriteLine(some_string.ToUpper());
            Console.WriteLine(some_string.EndsWith("iky"));
            Console.WriteLine(some_string.StartsWith("Mazoo"));
            Console.WriteLine(some_string.StartsWith("M"));
            Console.WriteLine(some_string.Contains("veliky"));
            Console.WriteLine(some_string[0]); // return first character of string
            Console.WriteLine(some_string[1]);

            // Returns a substring starting from the index position you specified.
            Console.WriteLine(some_string.Substring(8));

            // You can also specify a length of string which you want to return.
            // Here it means that it will return 2 charcaters starting from index 8.
            Console.WriteLine(some_string.Substring(8, 2));

            // Returns index of first occurence, if it does not find the letter, -1 will
            //  be returned.
            Console.WriteLine(some_string.IndexOf("o") + "\n");


            // NUMBERS
            Console.WriteLine(4);
            Console.WriteLine(4 * 2);
            Console.WriteLine(4 / 2);
            Console.WriteLine(4 + 3);
            Console.WriteLine(4 - 2);
            Console.WriteLine(4 % 2);
            Console.WriteLine((4 - 2) * 2);
            Console.WriteLine(4.0 + 2); // the type will be converted to float/double
            Console.WriteLine(5 / 2);  // this will not be converted to float/double
            Console.WriteLine(5 / 2.0); // this will give correct answer

            int number = 5;
            Console.WriteLine(number);
            number++;  // increment number by 1
            Console.WriteLine(number);
            number--;  // decrement number by 1
            Console.WriteLine(number);

            Console.WriteLine(Math.Abs(-3));
            Console.WriteLine(Math.Pow(2, 4));
            Console.WriteLine(Math.Sqrt(16) + "\n");

            /*
            // GETTING USER INPUT
            // Console.Write means that there is no "\n" at the end.
            Console.Write("Write your name: "); 
            string name = Console.ReadLine();
            Console.WriteLine($"Hello {name}");
            
            Console.Write("Enter the first number: ");
            int number1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the second number: ");
            int number2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(number1 + number2);
            */


            // ARRAYS
            // Create an array with int types.
            int[] lucky_numbers = { 1, 2, 3, 4, 5, 6 };
            Console.WriteLine(lucky_numbers[0]); // print first index
            Console.WriteLine(lucky_numbers[1]); // print second index

            lucky_numbers[2] = 300;  // asign new value to a specified index
            Console.WriteLine(lucky_numbers[2]);

            // Create an array where you do not assign variables right away but later.
            // Here we specify, that the array will get maximally 3 items.
            string[] names = new string[3];
            names[0] = "John";
            names[1] = "Don";
            names[2] = "Dylan";
            Console.WriteLine(names[0] + "\n");


            // FUNCTIONS (calling them)
            SayHi("Pepo", 40);
            SayHi(name: "Tomas", 30);
            SayHi("Mike", age: 23);
            SayHi(name: "Johnson", age: 31);

            Console.WriteLine(Cube(number: 4));

            int number_assignment = Cube(number: 3); // possible as a variable
            Console.WriteLine(number_assignment + "\n");


            // IF ELSE
            bool isMale = true;
            bool isTall = false; 

            // && means AND
            if (isMale && isTall)
            {
                Console.WriteLine("He is male and is tall.");
            }
            // "!" means NOT operator
            else if (isMale && !isTall)
            {
                Console.WriteLine("He is male but is not tall.");
            }
            else if (!isMale && isTall)
            {
                Console.WriteLine("She is female and is tall.");
            }
            else
            {
                Console.WriteLine("She is a small female.");
            }

            // || means OR operator
            if (isMale || isTall)
            {
                Console.WriteLine("You are either a man or you are tall.");    
            }

            int some_var = 2;
            if (some_var > 0)
            {
                Console.WriteLine("The number is positive\n");
            }


            // ------------
            // Without this line console window would just immediatelly close,
            //  after we executed the code.
            // It actually waits for user input, but when you just hit enter. The
            // program will terminate, if there is no other code, which follows this.
            Console.ReadLine();

        }

        // FUNCTIONS / METHODS (for some reason C# uses rather mehtods name, check if
        //  method means also that it is inside a class or if it is more general.
        // TODO: check method vs function in C#

        // Void means, that the function is not returning anything.
        static void SayHi(string name, int age)
        {
            Console.WriteLine($"Hello {name} you are {age} years old.");
        }

        // Return statement
        // Int means here, that the function is going to return int type.
        static int Cube(int number)
        {
            int result = number * number * number;
            return result;
        }

    }
}
