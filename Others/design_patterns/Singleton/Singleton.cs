namespace Singleton
{
    public class Singleton
    {
        private static Singleton _instance;

        // Private constructor to prevent instantiation
        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
                return _instance;
            }
        }

        public void DoSomething()
        {
            Console.WriteLine("Singleton instance method called.");
        }
    }
}
