using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AbstractFactory
{
    // 2. DEFINE CONCRETE PRODUCTS
    // ----------------------------------------------------------------

    // Concrete product for Windows Button
    public class WindowsButton : IButton
    {
        public void Paint()
        {
            Console.WriteLine("Render a button in Windows style");
        }
    }

    // Concrete product for MacOS Button
    public class MacOSButton : IButton
    {
        public void Paint()
        {
            Console.WriteLine("Render a button in MacOS style");
        }
    }

    // Concrete product for Windows Checkbox
    public class WindowsCheckbox : ICheckBox
    {
        public void Paint()
        {
            Console.WriteLine("Render a checkbox in Windows style");
        }
    }

    // Concrete product for MacOS Checkbox
    public class MacOSCheckbox : ICheckBox
    {
        public void Paint()
        {
            Console.WriteLine("Render a checkbox in MacOS style");
        }
    }

}
