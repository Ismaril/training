using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax
{
    internal static class Dictionaries
    {
        internal static void Main__()
        {
            Utilities utility = new Utilities();
            utility.Title("DICTIONARIES"); 


            Dictionary<string, string> czechEnglishDict = new Dictionary<string, string>();

            czechEnglishDict.Add(key: "Ahoj", value: "Hello");
            czechEnglishDict.Add(key: "Ruka", value: "Hand");
            czechEnglishDict.Add(key: "Auto", value: "Car");

            Console.WriteLine(czechEnglishDict.Count); // Number of items in a dictionary.
            Console.WriteLine(czechEnglishDict.ContainsKey("Auto"));
            Console.WriteLine(czechEnglishDict.ContainsValue("Car"));
            czechEnglishDict.Remove(key: "Auto");

            utility.Separator();
            
            foreach (var keyvaluepair in czechEnglishDict)
            {
                Console.WriteLine(keyvaluepair.Key);
            }
            // Also possible to write the foreach loop like this:

            foreach (KeyValuePair<string, string> item in czechEnglishDict)
            {
                Console.WriteLine(item.Key);
            }
            utility.Separator();
               
            czechEnglishDict.Clear();
            Console.WriteLine(czechEnglishDict.Count == 0);
            
            // TODO: Complete all other methods for dictionary operations etc.
        }
    }
}
