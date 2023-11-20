/*
RECORDS

A record in C# is a class or struct that provides special 
    syntax and behavior for working with data models. 
The record modifier instructs the compiler to synthesize members 
    that are useful for types whose primary role is storing data. 
These members include an overload of ToString() and members that 
    support value equality.

WHEN TO USE RECORDS
Use a record in place of a class or struct in the following scenarios:
You want to define a data model that depends on value equality.
You want to define a type for which objects are immutable.

VALUE EQUALITY
For records, value equality means that two variables of a 
    record type are equal if the types match and all property 
    and field values match. 
For other reference types such as classes, equality means reference equality. 
That is, two variables of a class type are equal if they refer to the same object. 
Methods and operators that determine equality of two record instances use 
    value equality.

Not all data models work well with value equality. 
For example, Entity Framework Core depends on reference equality 
    to ensure that it uses only one instance of an entity type for 
    what is conceptually one entity. For this reason, 
    record types aren't appropriate for use as entity types in 
    Entity Framework Core.
*/

namespace syntax_NET_core
{
    internal static class Records
    {
        // In my own words, it seems that it makes sense to use records
        //  when you want to compare two objects that have same
        //  immutable parametes and you do not care about the
        //  reference equality.
        public static void Main__()
        {
            var car1 = new Car("Toyota", "Corolla", 2020);
            var car2 = new Car("Toyota", "Corolla", 2020);
            var car3 = new Car("Corolla", "Toyota", 2020);

            Console.WriteLine(car1 == car2); // Outputs: True
            Console.WriteLine(car1 == car3); // Outputs: False

            Console.WriteLine(car1.Make); // Outputs: Toyota

            // In C#, the with keyword is used with records to create a new
            //  instance that is a copy of an existing instance with some properties modified.
            // This is known as non-destructive mutation.
            // The with keyword is part of the record's syntax that supports immutability.
            var car4 = car1 with { Year = 2021 };
            Console.WriteLine(car4.Year); // Outputs: 2021
        }

    }
    public record Car(string Make, string Model, int Year);

}
