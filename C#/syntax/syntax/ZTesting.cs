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

            Hovno hovinecko = new Hovno() { vaha = 10, Barva = "Cerna" };
            Hovno vetsiHovno = new Hovno() { };

            
        }

     
    }

    public class Hovno
    {
        public int vaha = 0;
        public string Barva { get; set; }

        public Hovno() { }
    }
}
