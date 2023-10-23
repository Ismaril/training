using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax_NET_core
{
    internal class Generics
    {
        public static void Main__()
        {
            var utilities = new Utilities();
            utilities.PrintLine();

            Stack<int> stack = new();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());

            utilities.PrintLine();

            Stack<string> stack2 = new();
            stack2.Push("Hello");
            stack2.Push("World");
            stack2.Push("You filthy sounwahbitch");
            Console.WriteLine(stack2.Pop());
            Console.WriteLine(stack2.Pop());
            Console.WriteLine(stack2.Pop());

            utilities.PrintLine();

            Stack<int> stack3 = new();
            Console.WriteLine(stack3.GetDefaultValue());
        }

        // This is a generic class. "YourDataType", in practise called "T" is a type parameter.
        // This allows you to use the same code for different data types.
        // Just insert a datatype into Class<here> when you create an instance of the class.
        public class Stack<YourDataType>
        {
            YourDataType[] _items;
            YourDataType _item;
            readonly int _size;
            int _index = 0;

            public Stack(int size)
            {
                _size = size;
                _items = new YourDataType[size];
            }

            // Constructor which will assign default value to the size, if you call thisone (constructor without
            //  parameter).
            public Stack() : this(size: 100) { }


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


    }
}
