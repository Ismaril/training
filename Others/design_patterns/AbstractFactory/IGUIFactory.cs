using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    // 3. DEFINE ABSTRACT FACTORY
    // ----------------------------------------------------------------

    internal interface IGUIFactory
    {
        IButton CreateButton();
        ICheckBox CreateCheckBox();

    }
}
