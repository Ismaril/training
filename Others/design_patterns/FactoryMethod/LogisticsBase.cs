using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    // 3. DEFINE THE CREATOR CLASS:

    public abstract class Logistics
    {
        // The factory method
        public abstract ITransport CreateTransport();

        public void PlanDelivery()
        {
            // Call the factory method to create a Product object.
            ITransport transport = CreateTransport();
            // Now use the product.
            transport.Deliver();
        }
    }
}
