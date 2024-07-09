/*
COMPLEXITY OF PATTERN: MEDIUM

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
    public class House
    {
        public string Walls { get; set; }
        public string Roof { get; set; }
        public string Windows { get; set; }

        public override string ToString()
        {
            return $"House with {Walls}, {Roof} roof and {Windows} windows";
        }
    }

    // -----------------------------------------------------------------------
    // 2. DEFINE THE BUILDER INTERFACE
    public interface IHouseBuilder
    {
        void BuildWalls();
        void BuildRoof();
        void BuildWindows();
        House GetHouse();
    }

    // -----------------------------------------------------------------------
    // 3. IMPLEMENT CONCRETE BUILDER (Concrete meaning "beton")
    // Example 1 of builder.
    public class ConcreteHouseBuilder : IHouseBuilder
    {
        private House _house = new();

        public void BuildWalls() => _house.Walls = "Brick walls";
        public void BuildRoof() => _house.Roof = "Concrete";
        public void BuildWindows() => _house.Windows = "Double-glazed";
        public House GetHouse() => _house;
    }

    // Example 2 of builder.
    // Builder for wooden houses
    public class WoodenHouseBuilder : IHouseBuilder
    {
        private House _house = new();

        public void BuildWalls() => _house.Walls = "Wooden walls";
        public void BuildRoof() => _house.Roof = "Wooden";
        public void BuildWindows() => _house.Windows = "Single-glazed";
        public House GetHouse() => _house;
    }

    // -----------------------------------------------------------------------
    // 4. DEFINE THE DIRECTOR
    public class Director(IHouseBuilder houseBuilder)
    {
        public void ConstructHouse()
        {
            houseBuilder.BuildWalls();
            houseBuilder.BuildRoof();
            houseBuilder.BuildWindows();
        }

        public House GetHouse() => houseBuilder.GetHouse();
    }

    // -----------------------------------------------------------------------
    // 5. CLIENT CODE

    public class ProgramBuilder
    {
        public static void Main__()
        {
            // Construct a concrete house
            IHouseBuilder builder = new ConcreteHouseBuilder();
            Director director = new(builder);
            director.ConstructHouse();
            House house = director.GetHouse();
            Console.WriteLine(house.ToString());


            ConsoleOutputSeparator.Separator();


            // Construct a wooden house
            IHouseBuilder woodenBuilder = new WoodenHouseBuilder();
            Director woodenDirector = new(woodenBuilder);
            woodenDirector.ConstructHouse();
            House woodenHouse = woodenDirector.GetHouse();
            Console.WriteLine(woodenHouse.ToString());
        }
    }
}