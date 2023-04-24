using System;
using System.ComponentModel.Design;
using System.Xml.Linq;
using System.Linq;
using System.Net.Cache;
using System.Collections.Generic;

namespace syntax
{
    public class LINQ
    {
        public static void Main__()
        {
            // LINQ - Language Integrated Query
            // Used for working with arrays of data with syntax similar to SQL.
            Utilities utility = new Utilities();
            utility.Title("LINQ");

            string[] names = { "Jarda Mrcas", "Pepik Hnatek", "Cenda", "Lojza Kapr" };
            
            // Seems like I have to have "var" instead of some exact datatype.
            // Filter out all names which have space in them + order them.
            var filteredNames = from name in names
                                where name.Contains(" ")
                                orderby name descending
                                select name;

            foreach ( var name in filteredNames )
            {
                Console.WriteLine( name );
            }

            utility.Separator();

            // Also possible to filter out objects in array
            List<Human> humans = new List<Human>()
            {
                new Human(age: 50, name: "Johnos"),
                new Human(age: 30, name: "Ferin"),
                new Human(age: 60, name: "Boris"),
                new Human(age: 40, name: "Zelin")
            };
            
            var filteredHumans = from human in humans
                                 where human.Age >= 40
                                 orderby human.Name
                                 select human;

            foreach ( var human in filteredHumans)
            {
                Console.WriteLine( human.Name );
            }

            utility.Separator();

            // Create new object array from existing one.
            var ages = from human in humans
                       select new
                       {
                           human.Age
                       };
            foreach ( var age in ages )
            {
                Console.WriteLine( age );
            }

            // This is houw you wold access a value from that newly created column of that anonymous array
            Console.WriteLine($"Accessing first item: {ages.ToArray()[0].Age}");
            
            utility.Separator();

            // INNER JOIN TWO ARRAYS
            List<Cat> cats = new List<Cat>()
            {
                new Cat(nickName: "KittyCat", owner: "Johnos"),
                new Cat(nickName: "BillyCat", owner: "Ferin"),
                new Cat(nickName: "JohnyCat", owner: "Ferin"),
                new Cat(nickName: "DillyCat", owner: "Zelin")
            };

            var innerJoin = from cat in cats
                            join human in humans
                            on cat.Owner equals human.Name
                            select new
                            {
                                CatName = cat.NickName,
                                HumanName = human.Name,
                                HumanAge = human.Age,
                            };
            foreach( var item in  innerJoin)
            {
                Console.WriteLine( item);
            }
            
            // Group join.
            /*
            The "INTO" contextual keyword can be used to create a temporary identifier to store the results of a group, join or select clause into a new identifier. This identifier can itself be a generator for additional query commands. When used in a group or select clause, the use of the new identifier is sometimes referred to as a continuation.
            */
            var groupJoin = from human in humans
                            orderby human.Name // Order humans
                            join cat in cats
                            on human.Name equals cat.Owner
                            into Ownergroup  // Store results temporarily in this variable.
                            select new
                            {
                                Owner = human.Name,
                                Animals = from owner in Ownergroup
                                          // Order this new group by cat nickname.
                                          orderby owner.NickName descending 
                                          select owner
                            };

            utility.Separator();

            foreach( var item in groupJoin)
            {
                Console.WriteLine(item.Owner);
                foreach(var animal in item.Animals)
                {
                    Console.WriteLine($" - {animal.NickName}");
                }
            }
        }
        
    }

    class Human
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public Human(int age, string name)
        {
            this.Age = age;
            this.Name = name;
        }
    }

    class Cat
    {
        public string NickName { get; set; }
        public string Owner { get; set; }
        
        public Cat(string nickName, string owner)
        {
            this.NickName = nickName;
            this.Owner = owner;
        }

    }
}
