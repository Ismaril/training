using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
/*

OBJECT CLASS METHODS:

Equals(Object)	
Determines whether the specified object is equal to the current object.
   
Equals(Object, Object)	
Determines whether the specified object instances are considered equal.
   
Finalize()	
Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.
   
GetHashCode()	
Serves as the default hash function.
   
GetType()	
Gets the Type of the current instance.
   
MemberwiseClone()	
Creates a shallow copy of the current Object.
   
ReferenceEquals(Object, Object)	
Determines whether the specified Object instances are the same instance.
   
ToString()	
Returns a string that represents the current object.
*/ 



namespace syntax_NET_core
{

    // It is not necessary to explicitly inherit from Object, because it is the default base class for all types.
    // This also means that it's methods are available to all types.
    public class Object__: Object
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Object__(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        // This method is overriden to my needs.
        public override string ToString()
        {
            return $"{FirstName} {LastName}. This method is overriden.";
        }

        // This method is overriden to my needs.
        public override bool Equals(object? object_parameter)
        {
            var objectTemporary = object_parameter as Object__;

            return this.FirstName == objectTemporary.FirstName;
        }

        /// <summary>
        /// Main method in which is put all from this file.
        /// </summary>
        public static void Main__()
        {
            var utilities = new Utilities();

            var myObject1 = new Object__("Honza", "Zajeci");
            var myObject1_reference = myObject1;

            var myObject2 = new Object__("Honza", "Zajeci");

            Console.WriteLine(myObject1.ToString());

            Console.WriteLine(object.ReferenceEquals(myObject1, myObject1_reference));

            // == operator checks reference (it does the same as method reference equals),
            //  this means that even though the objects have the same values, they are not equal if
            //  the second object does not point to the first.
            Console.WriteLine(object.ReferenceEquals(myObject1, myObject2));
            Console.WriteLine(myObject1 == myObject2);

            utilities.PrintLine();

            // Equals also checks reference of two objects, but it can be overriden to check object's states.
            // This means that we can override Equals method to check if two objects have the same values.
            Console.WriteLine(myObject1.Equals(myObject2));

            // For equality check of two objects, always override both Equals and GetHashCode methods.
            var person1 = new Person("Honza", 20);
            var person2 = new Person("Honza", 20);

            Console.WriteLine(person1.Equals(person2));
            Console.WriteLine(
                $"Hash1: {person1.GetHashCode()}\n"
                + $"Hash2: {person2.GetHashCode()}\n"
                + $"Result: {person1.GetHashCode() == person2.GetHashCode()}"
            );

            utilities.PrintLine();
        }
    }

    public class Person
    {
        public string Name { get; }
        public int Age { get; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        // Overriding Equals method for custom equality comparison
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var p = (Person)obj;
            return (Name == p.Name) && (Age == p.Age);
        }

        // Overriding GetHashCode method for consistent hash code generation
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (Name != null ? Name.GetHashCode() : 0);
                hash = hash * 23 + Age.GetHashCode();
                return hash;
            }
        }
    }
}
