using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    // 2. IMPLEMENT CONCRETE PRODUCTS:

    public class Truck : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("Deliver by land in a truck.");
        }
    }

    public class Ship : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("Deliver by sea in a ship.");
        }
    }
}
