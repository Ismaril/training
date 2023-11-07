using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax_NET_core
{
    internal static class ObjectInitializers
    {
        public static void Main__()
        {
            // OBJECT INITIALIZERS
            // This is object initializer. You can use it to initialize the object in the
            //  {} brackets. You can use this syntax if you do not have prepared constructor.
            // See however, that we created the constructor with parameter id. It was done
            //  because you cannot use the initializer on the properties that are private,
            //  like the Id property.
            AirPlaine airPlaine = new(id: 747)
            {
                Name = "Boeing",
                Description = "A big plane.",
                AirSpace = new(){Name = "North West"} // See, you can even initialize the nested object.
            };

            // COLLECTION INITIALIZERS
            int[] list1 = new int[] { 1, 2, 3, 4, 5 };
            int[] list2 = new int[5] { 1, 2, 3, 4, 5 };
            int[] list3 = { 1, 2, 3, 4, 5 };

            List<int> list5 = new List<int>(new int[] { 1, 2, 3, 4, 5 });
            List<int> list4 = new List<int> { 1, 2, 3, 4, 5 };
            List<int> list6 = new() { 1, 2, 3, 4, 5 };
            // List<int> list7 = { 1, 2, 3, 4, 5 }; // Not possible.

            List<AirPlaine> airPlaines = new() { 
                airPlaine,
                new(123) { Name = "Airbus", Description="The biggy" } 
            };

            // INDEX INITIALIZERS
            string[] letters = new string[] { "a", "b", "c", "d", "e" };
            Console.WriteLine(string.Join("", letters));

            List<string> letters2 = new List<string> (letters);
            Console.WriteLine(string.Join("", letters2));
            List<string> letters3 = new List<string> (letters)
                {
                    [0] = "A",
                    [1] = "B",
                    [2] = "C",
                    [3] = "D",
                    [4] = "E"
                };
            Console.WriteLine(string.Join("", letters3));

            Dictionary<int, string> dictionary = new()
            {
                [1] = "one",
                [2] = "two",
                [3] = "three"
            };
        }
    }

    class AirPlaine
    {
        private int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public AirSpace AirSpace { get; set; }

        public AirPlaine(int? id)
        {
            Id = id;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Description: {Description}, AirSpace {AirSpace}";
        }
    }

    class AirSpace
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}";
        }
    }
}
