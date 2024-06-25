using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    // 1. DEFINE THE PROTOTYPE INTERFACE:
    // Prototype Interface: The ICloneablePrototype interface declares the Clone method,
    // which returns a copy of the object.
    public interface ICloneablePrototype
    {
        ICloneablePrototype Clone();
    }
}
