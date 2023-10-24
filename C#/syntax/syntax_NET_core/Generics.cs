using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax_NET_core
{
    // ALIASES FOR GENERIC TYPES
    // You can create aliases for generic types, to make the code more readable.
    // Seems you could also use this for build in classes.
    using BasicStack = Generics.Stack_<int>;
    using AdvancedStack = Generics.Stack_<int, string>;

    internal class Generics
    {
        public static void Main__()
        {
            var utilities = new Utilities();
            utilities.PrintLine();

            Stack_<int> stack = new();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());

            utilities.PrintLine();

            Stack_<string> stack2 = new();
            stack2.Push("Hello");
            stack2.Push("World");
            stack2.Push("You filthy sounwahbitch");
            Console.WriteLine(stack2.Pop());
            Console.WriteLine(stack2.Pop());
            Console.WriteLine(stack2.Pop());

            utilities.PrintLine();

            Stack_<int> stack3 = new();
            Console.WriteLine(stack3.GetDefaultValue());

            utilities.PrintLine();

            // When you are going to create here new instance of Stack class,
            //  You will see that Stack<> class has two constructors. (Is overloaded.)
            Stack_<string, int> stackOverloaded = new("hovnajz", 500);
            Console.WriteLine(stackOverloaded.AdditionalData);

            utilities.PrintLine();

            // Using aliases for generic types, which were created at the top of this file.
            Console.WriteLine($"Default value: {new AdvancedStack(999, "Yee").GetDefaultValue()}");

            utilities.PrintLine();

            // Using generic method.
            BasicStack stack4 = new(654);
            Console.WriteLine(MyClass.MyMethod(stack4));

        }

        // This is a generic class. "YourDataType", in practise called "T" is a type parameter.
        // This allows you to use the same code for different data types.
        // Just insert a datatype into Class<here> when you create an instance of the class.
        public class Stack_<YourDataType>
        {
            YourDataType[] _items;
            YourDataType _item;
            readonly int _size;
            int _index = 0;

            public Stack_(int size)
            {
                _size = size;
                _items = new YourDataType[size];
            }

            // Constructor which will assign default value to the size, if you call thisone (constructor without
            //  parameter).
            public Stack_() : this(size: 100) { }


            public void Push(YourDataType item)
            {
                if(_index >= _size)
                    throw new StackOverflowException();
                _items[_index] = item;
                _index++;
            }

            public YourDataType Pop()
            {
                 _index--;
                if(_index < 0)
                {
                    _index = 0;
                    throw new InvalidOperationException("The stack is empty.");
                }
                return _items[_index];
            }

            public override string ToString()
            {
                return "Just overriden ToString() method.";
            }

            /// <summary>
            /// Default value for the datatype.
            /// </summary>
            /// <returns></returns>
            public YourDataType GetDefaultValue()
            {
                // Constructor does not initialize local variables to default values.
                // Therefore you need to make a field first.
                return _item;
            }
        }

        // OVERLOADING GENERIC CLASS
        // If for some reason you need to overload a generic class, inherit from
        //   base class (including its generic type parameter) and add additional
        //   type parameters into the derived class you are creating.
        // Then use the generic type parameters by your will.
        public class Stack_<YourDataType, AdditionalDataType> : Stack_<YourDataType>
        {
            public Stack_(YourDataType basicData, AdditionalDataType additionalData)
            {
                BasicData = basicData;
                AdditionalData = additionalData;
            }

            public YourDataType BasicData { get; set; }

            public AdditionalDataType AdditionalData { get; set; }
        }

        public static class MyClass
        {
            // This is a generic method. "Method<T>" expects a type parameter,
            //  meaning expected datatype "T".
            // "T yourclass", means Expected datatype and name of object.
            // "where T: class" means that the type parameter must be a reference type class.
            public static string MyMethod<T>(T yourClass) where T: class
            {
                if (yourClass == null)
                    return "null";
                return yourClass.ToString();

            }
        }

    }
}
