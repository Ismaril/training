using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// This file is only used for just testing of code and shit.


namespace syntax
{
    internal static class ZTesting
    {
        internal static void Main__()
        {
            Utilities utility = new Utilities();
            utility.Title("TESTING"); 
            string[] cars = new string[4];

            
            object a = 1;
            int b = 2;
            Console.WriteLine(a.GetType());
            Console.WriteLine(b.GetType());
        }
    }
}
