using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace syntax_NET_core
{
    internal static class XMLSerialization
    {
        // SERIALIZATION
        // Into serialization are included only public properties and fields. But since it is good
        //  practise to have fileds private and properties public, then only public properties
        //  will be (and should be) serialized.

        public static void Main__()
        {
            Utilities utilities = new Utilities();
            utilities.PrintLine();
            string fileDirectory = @"..\..\..\Files";

            var game1 = new ComputerGame("Doom", "FPS", 1993);
            var game2 = new ComputerGame("Doom 2", "FPS", 1994);
            var game3 = new ComputerGame("Doom 3", "FPS", 2004);

            var studio = new GameStudio(
                "id Software",
                new List<ComputerGame> { game1, game2, game3 }
                );
            Console.WriteLine(game1.ToString() + "\n");
            Console.WriteLine(studio.ToString());

            utilities.PrintLine();

            // SERIALIZE
            // Serialize object's properties into game.xml file.
            using (var stream = new System.IO.FileStream(
                $"{fileDirectory}\\game.xml",
                FileMode.Create,
                FileAccess.Write))
            {
                var serializer = new XmlSerializer(typeof(GameStudio));
                serializer.Serialize(stream, studio);
            }

            Thread.Sleep(2000);

            // DESERIALIZE
            // Deserialize object's properties from game.xml file.
            using (var stream = new System.IO.FileStream(
                $"{fileDirectory}\\game.xml",
                FileMode.Open,
                FileAccess.Read))
            {
                var serializer = new XmlSerializer(typeof(GameStudio));
                var studio2 = (GameStudio)serializer.Deserialize(stream);

                // Now you extracted data from xml file and you can use it.
                // You how now available all properties and fields of the object.
                // Just as if you were working with that instance in normal runtime.
                // Only this time you had it previously saved in xml file, which
                //  kept its data even after the program had been closed.
                Console.WriteLine(studio2.ToString());
                Console.WriteLine(studio2.Name);
            }
        }
    }

    public class ComputerGame
    {
        // --------------------------------------------------------------------------------
        // PROPERTIES
        public string Name { get; set; }
        public string Genre { get; set; }

        // Add attribute to change name of the property in xml file.
        [XmlElement(ElementName = "Year_Released")]
        public int Year { get; set; }

        // Will not be serialized.
        private string PrivateProperty { get; set; } = "PrivateProperty";

        // Use [XmlIgnore] attribute to ignore property in serializtion.
        [XmlIgnore]
        public string IgnoredProperty { get; set; } = "IgnoredProperty";

        // --------------------------------------------------------------------------------
        // FIELDS

        // Will not be serialized.
        string _privateField = "PrivateField";

        // --------------------------------------------------------------------------------
        // CONSTRUCTORS

        // Empty constructor is a condition for xml serialization.
        public ComputerGame() { }

        public ComputerGame(string name, string genre, int year)
        {
            Name = name;
            Genre = genre;
            Year = year;
        }

        // --------------------------------------------------------------------------------
        // METHODS
        public override string ToString()
        {
            return $"Name: {Name}, Genre: {Genre}, Year: {Year}";
        }

        // Remark:
        // This class is enough for serilization and deserialization. But we will show that
        //  serialization and deserialization can work with whole object tree.
        // Therefore, below is created next class which will have association with this class.
    }

    // With Serializable attribute you indicate that this class can be serialized.
    // But it is not mandatory to use this attribute. You can also serialize a class
    //  without this attribute.
    [Serializable]
    public class GameStudio
    {
        public string Name { get; set; }
        public List<ComputerGame> Games { get; set; }

        // Empty constructor is a condition for xml serialization.
        public GameStudio() { }

        public GameStudio(string name, List<ComputerGame> games)
        {
            Name = name;
            Games = games;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Games: {string.Join(", ", Games)}";
        }
    }
}
