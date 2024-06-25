using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    // 4. DEFINE CONCRETE FACTORIES
    // ----------------------------------------------------------------

    /// <summary>
    /// Concrete factory for creating Windows GUI elements
    /// </summary>
    internal class WindowsFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new WindowsButton();
        }

        public ICheckBox CreateCheckBox()
        {
            return new WindowsCheckbox();
        }
    }

    /// <summary>
    /// Concrete factory for creating MAC GUI elements
    /// </summary>
    public class MacOSFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new MacOSButton();
        }

        public ICheckBox CreateCheckBox()
        {
            return new MacOSCheckbox();
        }
    }
}
