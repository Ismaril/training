﻿using Builder;
// The majority of the code in this solution was generated by GPT4.

/*
EXPLANATION
-----------------------------------------------------------------------------

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
namespace Builder
{
    // 5. CLIENT CODE
    // -----------------------------------------------------------------

    class Program
    {
        static void Main(string[] args)
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