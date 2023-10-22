using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax_NET_core
{
    // We will try to create our own collection by implementing IEnumerable interface and using
    //  the ArrayList collection.

    internal class Collections_IEnumerable
    {
        public static void Main__()
        {
            Utilities utilities = new();
            utilities.PrintLine();

            // THIS IS ONLY DEMONSTRATION HOW TO DO ALL MANUALLY.
            // You can of course you the ArrayList collection directly, which has already implemented IEnumerable.
            // This will work only if the Trainings class implements IEnumerable interface.
            Trainings trainings = new();
            foreach (Training training in trainings)
            {
                Console.WriteLine(training.Name);
            }

            utilities.PrintLine();

            // This is the same as above, but using ArrayList collection.
            // You just use the ArrayList collection directly, which has already implemented IEnumerable.
            // There is no need to implement all by yourself as in the Trainings class. (Example above.)
            ArrayList trainings2 = new()
            {
                new Training("C#"),
                new Training("ASP.NET"),
                new Training("SQL"),
                new Training("JavaScript")
            };

            foreach (Training training in trainings2)
            {
                Console.WriteLine(training.Name);
            }

        }
    }

    class Training
    {
        public string Name { get; set; }
        public Training(string name)
        {
            Name = name;
        }
    }

    // Create a class that has a collection of trainings.
    class Trainings: IEnumerable
    {
        Training[] _trainings =
        {
            new("C#"),
            new("ASP.NET"),
            new("SQL"),
            new("JavaScript")
        };

        // When you inherit from IEnumerable, you must implement GetEnumerator, which here returns
        //  your custom class inheriting from IEnumerator.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new TrainingsEnumerator(_trainings);
        }
    }

    /// <summary>
    /// My custom class that inherits from IEnumerator. This class is then used in the place
    ///  where is expected implementation of "GetEnumerator" method.
    /// </summary>
    class TrainingsEnumerator: IEnumerator
    {
        Training[] _trainings;
        int _index = -1;

        public TrainingsEnumerator(Training[] trainings)
        {
            _trainings = trainings;
        }

        object IEnumerator.Current => _trainings[_index];

        bool IEnumerator.MoveNext()
        {
            _index++;
            return _index < _trainings.Length;
        }

        void IEnumerator.Reset()
        {
            _index = -1;
        }
    }
}
