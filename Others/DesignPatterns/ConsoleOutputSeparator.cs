using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public static class ConsoleOutputSeparator
    {
        static readonly string text = new string('-', 52);

        public static void Separator()
        {
            Console.WriteLine(text);
        }
    }
}
