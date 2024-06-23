using AbstractFactory;

namespace AbstractFactory
{
    // 5. CLIENT CODE
    // ----------------------------------------------------------------    

    /// <summary>
    /// This is a code which will use a Client/User at his side.
    /// </summary>
    class Client
    {
        // Fields
        private IButton _button;
        private ICheckBox _checkbox;

        /// <summary>
        /// Constructor of the class.
        /// </summary>
        /// <param name="factory"></param>
        public Client(IGUIFactory factory)
        {
            _button = factory.CreateButton();
            _checkbox = factory.CreateCheckBox();
        }

        public void Paint()
        {
            _button.Paint();
            _checkbox.Paint();
        }
    }

    /// <summary>
    /// Main C# entry point
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Client client1 = new Client(new WindowsFactory());
            client1.Paint();

            Client client2 = new Client(new MacOSFactory());
            client2.Paint();

            Console.ReadLine();
        }
    }
}



