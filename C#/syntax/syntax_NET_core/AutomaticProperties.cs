using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax_NET_core
{
    internal class AutomaticProperties
    {
        // Automatic properties are a shorthand syntax that allows you to write a property
        // much more concisely.
        public static void Main__()
        {
            Utilities utilities = new();
            utilities.PrintLine();

            var pigy = new Pig();
            pigy.Name = "Pigy";
            pigy.Age = 2;
            pigy.Color = "black";
            pigy.Id = 0001;
            pigy.WeightCategory = "light";
            // pigy.Breed = "domestic pigas"; // Does not work, because Breed "set" is private.
            Console.WriteLine(pigy.WeightCategory);

            utilities.PrintLine();

            var wildPig = new WildPig();
            wildPig.Name = "Wild Pig";
            wildPig.Age = 3;
            wildPig.Color = "brown";
            wildPig.Id = 0002;
            wildPig.WeightCategory = "heavy";
            Console.WriteLine(wildPig.WeightCategory);

            utilities.PrintLine();

            var weekDayNames = new WeekDayNames();
            Console.WriteLine(weekDayNames[1]);
            Console.WriteLine(weekDayNames["Tue"]);
        }


    }

    internal class Pig
    {
        // OLD WAY,
        // how to write properties
        // fields
        private string _name;
        private int _age;

        // properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        // AUTOMATIC PROPERTIES (new way)
        // There is no need to write fields, because they are automatically generated.
        // You can also assign a default value to the property.
        public string Color { get; set; } = "pink";
        public int Id { get; set; }


        // OVERRIDING PROPERTIES
        // You can override properties in derived classes.
        public virtual string WeightCategory { get; set; } = "normal";


        // RESTRICTING ACCESS TO PROPERTIES
        // You can see that we can set access modifier directly inside the property.
        public string Breed { get; private set; }

        // READ-ONLY PROPERTIES
        public string Producer { get; } = "Producer_Name";
    }

    internal class WildPig : Pig
    {
        // You can override properties in derived classes.
        public override string WeightCategory
        {
            get => base.WeightCategory.ToUpper();

            set => base.WeightCategory = value;
        }
    }

    internal class WeekDayNames
    {
        private readonly string[] _weekDayNames =
        {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"
        };

        private readonly string[] _weekDayShortNames =
        {
            "Mon",
            "Tue",
            "Wed",
            "Thu",
            "Fri",
            "Sat",
            "Sun"
        };

        // INDEXER PROPERTIES
        // You can use yourObject[index] to access elements in the collection.
        // By this is meant this class. In square brackets you put an index.
        // Then you specify what you want to return in the getter.
        public string this[int dayNumber] => _weekDayNames[dayNumber - 1];

        // OVERLOADING INDEXER PROPERTIES
        // You can overload indexer properties. We already define once indexer property above.
        // But here overload it. You can now access elements in the collection of this class both by index and by name.
        public string this[string dayName] => _weekDayNames[Array.IndexOf(_weekDayShortNames, dayName)];
    }
}
