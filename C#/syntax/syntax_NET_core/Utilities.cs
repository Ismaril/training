
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax_NET_core
{
    internal class Utilities
    {
        private int _numberOfLines;
        private readonly string _separator = "----------------------------------------";

        public void PrintLine()
        {
            Console.WriteLine($"[{_numberOfLines}] {_separator}");
            _numberOfLines++;
        }
    }
}
