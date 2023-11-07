using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax_NET_core
{

    internal static class ExtensionMethods
    {
        public static void Main__()
        {
            Utilities utilities = new();
            utilities.PrintLine();

            string text = "this is a sentence";
            Console.WriteLine(text.ToSentenceCase());

            utilities.PrintLine();

            // Overloaded method.
            Console.WriteLine(text.ToSentenceCase(punctuation: false));

            utilities.PrintLine();

            Robot robot = new("1", "R2D2", "A robot from Star Wars");
            Console.WriteLine(robot.ToString(showId: false)); // This will call the extension method.
            Console.WriteLine(robot.ToString(showId: true)); // This will call the extension method.
            Console.WriteLine(robot.ToString());  // This will call overriden ToString() method.
        }
    }

    // Extension methods are useful when you want to add some functionality to a
    //  class but you don't have access to the source code of that class.
    // Extension methods always have to be static.
    // IF you run cursor over ToSentenceCase() method,
    //  you will see that it is a extension method for string class.
    // It is done by adding "this" keyword before the first parameter of the method.
    //  The "this string text" however does not expect from you to pass antyhing inside
    //  the parenthesis when you call the method.
    // It is just this simple. You just extended the existing string class,
    //  with your own custom Class with method, without even touching the base class.
    // Then all it takes is just to call the extension method on the object. (In
    //  this case string object)
    static class StringExtender
    {
        /// <summary>
        /// Make the first letter of the string uppercase. Add a dot at the end.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ToSentenceCase(this string text)
        {
            string punctuation;
            if (text[^1] != '.')
                punctuation = ".";
            else
                punctuation = "";
            return text[0].ToString().ToUpper()
                + text[1..].ToLower()
                + punctuation;
        }

        // Overload of the above extension method.
        /// <summary>
        /// Make the first letter of the string uppercase.
        /// Add a dot at the end based on parameter punctuation.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="punctuation"></param>
        /// <returns></returns>
        public static string ToSentenceCase(this string text, bool punctuation)
        {
            if (punctuation)
                // If punctuation is true, then call the above method. (The
                //  original extension method)
                return text.ToSentenceCase();
            else
                return text[0].ToString().ToUpper()
                    + text[1..].ToLower();
        }

        // You see now we have in this file 2x ToString() methods. One is the overriden
        //  ToString() method in Robot class which modifies the original ToString()
        //  method of the base object class. Another one is the extension method of
        //  Robot class which is called ToString() as well. This is not a problem. You
        //  can also give this extension method a different name if you want.
        // It will be possible to call both of these methods on the Robot object. It
        //  will give you the option to choose which one you want to call (based on
        //  the parameters you pass to the method).

        /// <summary>
        /// Extension method of Robot class. This extension method can be called 
        /// only on Robot objects.
        /// </summary>
        /// <param name="robot">Robot object</param>
        /// <param name="showId">Show Id of robot if True</param>
        /// <returns></returns>
        public static string ToString(this Robot robot, bool showId)
        {
            if (showId)
                return robot.ToString();
            else
                return $"Name: {robot.Name}, Description: {robot.Description}";
        }
    }

    public class Robot
    {
        private string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // constructor.
        public Robot(string id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        /// <summary>
        /// My custom overriden ToString() method.
        /// </summary>
        /// <returns>string Id, string Name, string Description</returns>
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Description: {Description}";
        }
    }
}

/*
EXPLANATION BY CHATGPT 3.5:

In C#, you can modify the behavior of a base class method in a derived class using method 
overriding, method shadowing, or method extension. Here's a brief explanation of when to 
use each approach:

METHOD OVERRIDING:
Use method overriding when you want to provide a specific implementation of a method in a 
derived class that is already defined in the base class.
Method overriding is often used in inheritance scenarios, where the derived class wants to 
provide its own implementation of a method defined in the base class.
By using the override keyword, you can provide a new implementation for a virtual or abstract 
method in the derived class, allowing polymorphic behavior during runtime.

METHOD SHADOWING:
Use method shadowing when you want to provide a new implementation of a method in a derived
class that has the same name as a method in the base class, but you don't intend to override 
the base class method.
Method shadowing is typically used when you want to hide the base class method with a new 
method in the derived class, but you still want to access the base class method using the 
base keyword.
By using the new keyword, you can declare a method in the derived class that has the same 
signature as a method in the base class, effectively hiding the base class method.

METHOD EXTENSION:
Use method extension when you want to add new functionality to existing classes without 
modifying their original implementation.
Method extension is useful when you want to extend the behavior of a class without creating 
a new derived class or changing the original class's source code.
You can define extension methods as static methods in a static class, enabling you to call 
these methods as if they were instance methods of the extended type.
Each approach serves a specific purpose, allowing you to customize the behavior of methods 
in different ways, depending on the requirements of your application and the design of your 
class hierarchy.
*/