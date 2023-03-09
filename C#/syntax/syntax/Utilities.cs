using System;

namespace syntax
{
    internal class Utilities
    {
        int counter = 0;

        public Utilities() {
        }

        internal void Title(string title)
        // Make some nice frame from asterisks around the string which was inputed
        //  as a parameter into this function.
        {
            int titleLength = title.Length;
            for (int i = 0; i < titleLength; i++) { Console.Write('*'); }
            Console.WriteLine($"\n{title}");
            for (int i = 0; i < titleLength; i++) { Console.Write('*'); }
            Console.WriteLine('\n');
        }

        internal void Separator()
        // Make a line which will separate text into blocks in console.
        {
            Console.Write($"\n{counter} ");
            for (int i = 0; i < 60; i++) { Console.Write('_'); }
            Console.WriteLine("\n");
            counter++;
        }
    }
}
