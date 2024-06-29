using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public static class ConsoleOutputSeparator
    {
        const string text = "----------------------------------------------------";

        public static void Separator()
        {
            Console.WriteLine(text);
        }
    }
}
