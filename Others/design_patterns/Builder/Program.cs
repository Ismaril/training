using Builder;


namespace Builder
{
    // 5. CLIENT CODE
    // -----------------------------------------------------------------

    class Program
    {
        static void Main(string[] args)
        {
            IHouseBuilder builder = new ConcreteHouseBuilder();
            Director director = new Director(builder);

            director.ConstructHouse();
            House house = director.GetHouse();

            Console.WriteLine(house.ToString());
            Console.ReadLine();
        }
    }
}