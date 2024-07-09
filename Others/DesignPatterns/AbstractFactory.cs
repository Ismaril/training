/*
COMPLEXITY OF PATTERN: MEDIUM


Abstract Factory is a creational design pattern that lets you produce families
of related objects without specifying their concrete classes.


1. ABSTRACT PRODUCTS:
Button and Checkbox are interfaces (or could be abstract classes, I ugess...)
that define the interface for different types of GUI elements.

2. CONCRETE PRODUCTS:
WindowsButton, MacOSButton, WindowsCheckbox, and MacOSCheckbox are concrete
implementations of the abstract products.

3. ABSTRACT FACTORY:
GUIFactory is an interface (or I guess again, could be abstract class?)
that declares methods for creating abstract product objects.

4. CONCRETE FACTORIES:
WindowsFactory and MacOSFactory are concrete implementations of the
GUIFactory that create concrete products for Windows and MacOS respectively.

5. CLIENT CODE:
The Client class uses the factory interface to create and use products.
The Program class demonstrates how the client can work with different
factories to create products for different operating systems without
knowing their concrete implementations.
*/

namespace DesignPatterns
{
    // ------------------------------------------------------------------------
    // 1. DEFINE ABSTRACT PRODUCTS
    // Abstract product for Button
    public interface IButton
    {
        public void Paint();
    }

    // Abstract product for CheckBox
    public interface ICheckBox
    {
        public void Paint();
    }

    // ------------------------------------------------------------------------
    // 2. DEFINE CONCRETE PRODUCTS
    public class WindowsButton : IButton
    {
        public void Paint() => Console.WriteLine("Render a button in Windows style");
    }

    public class MacOSButton : IButton
    {
        public void Paint() => Console.WriteLine("Render a button in MacOS style");
    }

    public class WindowsCheckbox : ICheckBox
    {
        public void Paint() => Console.WriteLine("Render a checkbox in Windows style");
    }

    public class MacOSCheckbox : ICheckBox
    {
        public void Paint() => Console.WriteLine("Render a checkbox in MacOS style");
    }

    // ------------------------------------------------------------------------
    // 3. DEFINE ABSTRACT FACTORY
    public interface IGUIFactory
    {
        IButton CreateButton();
        ICheckBox CreateCheckBox();
    }

    // ------------------------------------------------------------------------
    // 4. DEFINE CONCRETE FACTORIES
    /// <summary>
    /// Concrete factory for creating Windows GUI elements
    /// </summary>
    public class WindowsFactory : IGUIFactory
    {
        public IButton CreateButton() => new WindowsButton();
        public ICheckBox CreateCheckBox() => new WindowsCheckbox();
    }

    /// <summary>
    /// Concrete factory for creating MAC GUI elements
    /// </summary>
    public class MacOSFactory : IGUIFactory
    {
        public IButton CreateButton() => new MacOSButton();
        public ICheckBox CreateCheckBox() => new MacOSCheckbox();
    }

    // ------------------------------------------------------------------------
    // 5. CLIENT CODE
    /// <summary>
    /// This is a code which will use a Client/User at his side.
    /// </summary>
    /// <param name="factory"></param>
    class Client_(IGUIFactory factory)
    {
        // Fields
        private IButton _button = factory.CreateButton();
        private ICheckBox _checkbox = factory.CreateCheckBox();

        public void Paint()
        {
            _button.Paint();
            _checkbox.Paint();
        }
    }

    /// <summary>
    /// Main C# entry point
    /// </summary>
    public class ProgramAbstractFactory
    {
        public static void Main__()
        {
            Client_ client1 = new(new WindowsFactory());
            client1.Paint();


            ConsoleOutputSeparator.Separator();


            Client_ client2 = new(new MacOSFactory());
            client2.Paint();
        }
    }
}
