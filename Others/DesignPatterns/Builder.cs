
/*
Builder is a creational design pattern that lets you construct complex 
objects step by step. The pattern allows you to produce different types and 
representations of an object using the same construction code.


1. PRODUCT (House): 
The House class represents the complex object that will be built. 
It has properties for walls, roof, and windows.

2. BUILDER INTERFACE (IHouseBuilder): 
This interface defines the methods necessary for building the different parts 
of the product (house).

3. BUILDER (ConcreteHouseBuilder, WoodenHouseBuilder): 
This class implements the IHouseBuilder interface and provides specific 
implementations for building the parts of the house. It also provides a 
method to return the constructed house.

4. DIRECTOR (Director): 
The Director class takes an IHouseBuilder object and constructs the house 
by calling the builder's methods in a specific order.

5. CLIENT CODE: 
The client creates a ConcreteHouseBuilder object and a Director object, 
then directs the Director to construct the house. Finally, 
it retrieves and prints the constructed house.


SUMMARY:
The Builder pattern is beneficial when you need to construct complex 
objects with various configurations, ensuring the construction process is
controlled and the final product is consistent.

*/
namespace DesignPatterns
{
    // -----------------------------------------------------------------------
    // 1. DEFINE THE PRODUCT

    internal class House
    {
        public string Walls { get; set; }
        public string Roof { get; set; }
        public string Windows { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public House() { }

        public override string ToString()
        {
            return $"House with {Walls}, {Roof} roof and {Windows} windows";
        }
    }

    // -----------------------------------------------------------------------
    // 2. DEFINE THE BUILDER INTERFACE
    internal interface IHouseBuilder
    {
        void BuildWalls();
        void BuildRoof();
        void BuildWindows();
        House GetHouse();
    }

    // -----------------------------------------------------------------------
    // 3. IMPLEMENT CONCRETE BUILDER (Concrete meaning "beton")
    // Example 1 of builder.

    internal class ConcreteHouseBuilder : IHouseBuilder
    {
        private House _house = new House();

        public void BuildWalls()
        {
            _house.Walls = "Brick walls";
        }

        public void BuildRoof()
        {
            _house.Roof = "Concrete";
        }

        public void BuildWindows()
        {
            _house.Windows = "Double-glazed";
        }

        public House GetHouse()
        {
            return _house;
        }
    }

    // Example 2 of builder.
    // Builder for wooden houses
    internal class WoodenHouseBuilder : IHouseBuilder
    {
        private House _house = new House();

        public void BuildWalls()
        {
            _house.Walls = "Wooden walls";
        }

        public void BuildRoof()
        {
            _house.Roof = "Wooden";
        }

        public void BuildWindows()
        {
            _house.Windows = "Single-glazed";
        }

        public House GetHouse()
        {
            return _house;
        }
    }

    // -----------------------------------------------------------------------
    // 4. DEFINE THE DIRECTOR

    internal class Director
    {
        private IHouseBuilder _houseBuilder;

        public Director(IHouseBuilder houseBuilder)
        {
            _houseBuilder = houseBuilder;
        }

        public void ConstructHouse()
        {
            _houseBuilder.BuildWalls();
            _houseBuilder.BuildRoof();
            _houseBuilder.BuildWindows();
        }

        public House GetHouse()
        {
            return _houseBuilder.GetHouse();
        }
    }

    // -----------------------------------------------------------------------
    // 5. CLIENT CODE

    public class ProgramBuilder
    {
        public static void Main__()
        {
            // Construct a concrete house
            IHouseBuilder builder = new ConcreteHouseBuilder();
            Director director = new Director(builder);
            director.ConstructHouse();
            House house = director.GetHouse();
            Console.WriteLine(house.ToString());

            Console.WriteLine("----------------------------------------");

            // Construct a wooden house
            IHouseBuilder woodenBuilder = new WoodenHouseBuilder();
            Director woodenDirector = new Director(woodenBuilder);
            woodenDirector.ConstructHouse();
            House woodenHouse = woodenDirector.GetHouse();
            Console.WriteLine(woodenHouse.ToString());

            Console.ReadLine();
        }
    }
}