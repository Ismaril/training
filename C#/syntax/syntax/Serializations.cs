using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace syntax
{
    public static class Serializations
    {
        public static void Main__()
        {
            Utilities utility = new Utilities();
            utility.Title("SERIALIZATION");
            // Serialization is a process where you can store a state of some object in a filestream (meaning just have it saved in file outside of program) and later when you need that state you can read it from that file.

            // SERIALIZATION TO .DAT FORMAT
            string path1 = @"C:\users\lazni\desktop\PhoneData.dat";
            // Write serialized data to a file.
            Telephone telephone1 = new Telephone(604400539, "Nokia", "Lojza");
            using (FileStream fileStream = File.Open(path: path1, mode: FileMode.Create))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, telephone1); 
            }


            telephone1 = null; // This will basically make the instance and all its properties empty.
            

            // Read serialized data. 
            using (Stream fileStream = File.Open(path: path1, mode: FileMode.Open ))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                telephone1 = (Telephone)binaryFormatter.Deserialize(fileStream);

            }

            Console.WriteLine(telephone1.ToString());

            utility.Separator();
            telephone1.Owner = "Curda";

            // SERIALIZATION TO .XML FORMAT
            // Write down data.
            string path2 = @"C:\users\lazni\desktop\PhoneData.xml";
            using (TextWriter  writer = new StreamWriter(path: path2))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Telephone));
                xmlSerializer.Serialize(writer, telephone1);
            }
            telephone1 = null;
            
            // Read data
            using (TextReader  reader = new StreamReader(path: path2))
            {
                XmlSerializer xmlDeSerializer = new XmlSerializer(typeof(Telephone));
                telephone1 = (Telephone)xmlDeSerializer.Deserialize(reader);
            }
            Console.WriteLine(telephone1.ToString());

            utility.Separator() ;


            // SERIALIZATION OF COLLECTION OF DATA

            string path3 = @"C:\users\lazni\desktop\Telephones.xml";
            List<Telephone> list = new List<Telephone>
            {
                new Telephone(600_509_300, "LG", "Pepa z Depa"),
                new Telephone(500_509_149, "Sony", "Murin"),
                new Telephone(069_359_599, "Siemens", "Feruna")
            };
            
            // Write data down - serialize.
            using (FileStream fileStream = new FileStream(path: path3,
                                                          mode: FileMode.Create,
                                                          access: FileAccess.Write,
                                                          share: FileShare.None))
            {
                XmlSerializer xmlSerializer = new XmlSerializer (typeof(List<Telephone>));
                xmlSerializer.Serialize(fileStream, list);
            }
            list = null;

            // Read data - deserialize
            using (FileStream fileStream = File.OpenRead(path: path3))
            {
                XmlSerializer xmlSerializer = new XmlSerializer (typeof(List<Telephone>));
                list = (List<Telephone>)xmlSerializer.Deserialize(fileStream); 
            }
            foreach (Telephone telephone in list)
            {
                Console.WriteLine(telephone.ToString());    
            }
 
        }

       
    }

    [Serializable()]
    public class Telephone : ISerializable
    {
        public int Number { get; set; }
        public string Brand { get; set; }
        public string Owner { get; set; } 
        
        public Telephone() { } 

        public Telephone(int number, string brand, string owner)
        {
            this.Number = number;
            this.Brand = brand;
            this.Owner = owner;
        }

        // Just override ToString method to specify by our means what should it do, when the instance of Telephone is converted to string.
        public override string ToString()
        {
            return $"Number: {this.Number}\nBrand: {this.Brand}\nOwner: {this.Owner}";

        }

        // This is a method that has to be implemented from ISerializable
        // This method is the one that retrieves the current state of that object and keeps it in that SerializationInfo class.
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Number", this.Number);
            info.AddValue("Brand", this.Brand);
            info.AddValue("Owner", this.Owner);
        }
        
        // This is a constructor to deserialize data to properties.
        public Telephone(SerializationInfo info, StreamingContext context)
        {
            this.Number = info.GetInt32("Number");
            this.Brand = info.GetString("Brand");
            this.Owner = info.GetString("Owner");

            // Or you could wirte it like this:
            // this.Number = (string)info.GetValue("Number", typeof(string));
        }
    }
}
