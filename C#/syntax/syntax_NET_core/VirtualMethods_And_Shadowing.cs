using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax_NET_core
{
    internal class VirtualMethods_And_Shadowing
    {
        public static void Main__()
        {
            Utilities utilities = new();
            utilities.PrintLine();

            Animal[] animals = { new Animal(), new Cat(), new Dog(), new Cat() };

            // This will call the overriden methods.
            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal.Sound());
            }

            utilities.PrintLine();

            // This will call the shadowed methods.
            // There will be no polymorphism, since we call Animal object.
            // If we however gonna create Cat or Dog object and call the Movement() method
            //  directly on the object, then you will see that the method will do 
            //  specifycally what was implemented in shadowed method.
            foreach (Animal animal in animals)
            {
                if (animal is Cat)
                {
                    Console.WriteLine(animal.Movement());
                }
                else if (animal is Dog)
                {
                    Console.WriteLine(animal.Movement());
                }
            }
            // Example of calling shadowed method directly on the object.
            // This will call the shadowed method, not the base class method.
            Cat cat = new Cat();
            Console.WriteLine(cat.Movement());

            utilities.PrintLine();

            // shadowing & virtual methods
            VirtualAnimal[] animals2 = { new VirtualAnimal(), new Cow() };
            foreach (VirtualAnimal animal in animals2)
            {
                Console.WriteLine(animal.Attack());
            }

        }
    }

    class Animal
    {
        public virtual string Sound()
        {
            return "generic animal sound";
        }

        public string Movement()
        {
            return "generic animal movement";
        }

        public virtual string Attack()
        {
            return "generic animal attack";
        }
    }

    class Cat : Animal
    {
        public override string Sound()
        {
            return "meow";
        }

        // Shadowing base class method.
        // Notice the "new" keyword.
        public new string Movement()
        {
            return "cat movement";
        }
    }

    class Dog : Animal
    {
        public override string Sound()
        {
            return "haf haf";
        }

        // Shadowing base class method.
        // Notice the "new" keyword.
        public new string Movement()
        {
            return "dog movement";
        }
    }

    // SHADOWING & VIRTUAL METHODS
    // Normally you would use virtual methods instead of shadowing. But if you for example use some library or
    //  some external code, it is better idea to use shadowing. Especially if the base library does not have
    //  the virtual keyword in its methods.
    // This means that you are going to use shadowing to be able to use the same method name as the base class,
    // but you also going to use virtual keyword to allow overriding of this shadowed method that you created.
    class VirtualAnimal : Animal
    {
        new public virtual string Attack()
        {
            return "virtual animal attack";
        }
    }

    class Cow : VirtualAnimal
    {
        public override string Attack()
        {
            return "cow attack";
        }
    }
}
