using System.Text.Json;
using System.Text.Json.Serialization;

namespace syntax_NET_core
{
    internal static class JSONSerialization
    {
        // More about serialization is explained in syntax_NET_core/XMLSerialization.cs
        // I see that there is a difference between XML and JSON serialization - in json
        //  serialization there is no need for default constructor in serialized classes.

        public static void Main__()
        {
            Utilities utilities = new();
            utilities.PrintLine();
            string fileDirectory = @"..\..\..\Files";

            Planet mercury = new("Mercury", 4879, 57909227, 0, false);
            Planet venus = new("Venus", 12104, 108209475, 0, false);
            Planet earth = new("Earth", 12756, 149598262, 1, true);
            Planet mars = new("Mars", 6792, 227943824, 2, false);
            Planet jupiter = new("Jupiter", 142984, 778340821, 79, false);
            Planet saturn = new("Saturn", 120536, 1426666422, 82, false);
            Planet uranus = new("Uranus", 51118, 2870658186L, 27, false);
            Planet neptune = new("Neptune", 49528, 4498396441L, 14, false);
            Star sun = new("Sun", "G", 1392684);

            Galaxy milkyWay = new(
                name: "Milky Way", 
                size: 105700, 
                age: 13500000000L,
                stars: new List<Star> { sun },
                planets: new List<Planet> { mercury, venus, earth, mars, jupiter, saturn, uranus, neptune }
                );
              

            // SERIALIZE
            using (var streamwriter = File.CreateText(path: fileDirectory + "\\space.json"))
            {
                string planetSerialized = JsonSerializer.Serialize(milkyWay);
                streamwriter.WriteLine(planetSerialized);
                Console.WriteLine("Serialization done.");
            }

            utilities.PrintLine();

            // DESERIALIZE
            using (var streamreader = File.OpenText(path: fileDirectory + "\\space.json"))
            {
                string completeStream = streamreader.ReadToEnd();
                Galaxy milkyWayDeserialized = JsonSerializer.Deserialize<Galaxy>(completeStream);
                Console.WriteLine("Deserialization done.");

                Console.WriteLine(milkyWayDeserialized.Name);
                Console.WriteLine(milkyWayDeserialized.Planets[4].Name);
            }

        }

        class Planet
        {
            // Give an attribute which will be called "PlanetName" in serialized file.
            [JsonPropertyName("PlanetName")]
            public string Name { get; set; }
            public int Size { get; set; }
            public long DistanceFromSun { get; set; }
            public int Satellites { get; set; }
            public bool IsHabitable { get; set; }

            public Planet(string name,
                          int size,
                          long distanceFromSun,
                          int satellites,
                          bool isHabitable)
            {
                Name = name;
                Size = size;
                DistanceFromSun = distanceFromSun;
                Satellites = satellites;
                IsHabitable = isHabitable;
            }
        }

        class Star
        {
            [JsonPropertyName("StarName")]
            public string Name { get; set; }
            public string Type { get; set; }
            public int Size { get; set; }

            public Star(string name,
                        string type,
                        int size)
            {
                Name = name;
                Type = type;
                Size = size;
            }
        }

        class Galaxy
        {
            [JsonPropertyName("GalaxyName")]
            public string Name { get; set; }
            public int Size { get; set; }
            public long Age { get; set; }
            public List<Star> Stars { get; set; }
            public List<Planet> Planets { get; set; }


            public Galaxy(string name,
                          int size,
                          long age,
                          List<Star> stars,
                          List<Planet> planets)
            {
                Name = name;
                Size = size;
                Age = age;
                Stars = stars;
                Planets = planets;
            }
        }
    }
}
