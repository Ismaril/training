using System.Collections;

// COMPLEXITY OF PATTERN: MEDIUM
/*
The main idea is to decouple a container which holds data from traversing algorithm.
Polymorphism, in this case it means that we can iterate over different collection types using the same interface.
Open/Closed principle - you can introduce new traversing algorithms without modifying the collection.
Thing/s to keep in mind - generally not a good idea to modify the collection while iterating over it.

 */

namespace DesignPatterns
{
    // -----------------------------------------------------------------------------------------------------------
    // 1. REQUIRED BUILT IN INTERFACES:
    //
    // IEnumerable:
    //  Exposes an enumerator, which supports a simple iteration over a collection.
    // IEnumerator:
    //  Supports an iteration over a collection.
    //
    // These interfaces allow us to iterate over a collection using the foreach loop, LINQ and other C# features.
    // That means that with that we standardize the way we iterate over collections in C#. (It would be still
    // possible to create workarounds, but it is not desired.)


    // -----------------------------------------------------------------------------------------------------------
    // 2. COLLECTION
    // The Collection class will be used as a container for data.
    // The collection also implements the IEnumerable interface.
    public class MyCollection<T> : IEnumerable<T>
    {
        private T[] _items;
        private int _count;

        public MyCollection()
        {
            _items = new T[10];
            _count = 0;
        }

        public void Add(T item)
        {
            if (_count >= _items.Length)
            {
                // Resize the array if needed
                Array.Resize(ref _items, _items.Length * 2);
            }
            _items[_count++] = item;
        }

        // Implement GetEnumerator for IEnumerable<T>
        public IEnumerator<T> GetEnumerator() => new MyEnumerator<T>(_items, _count);


        // This is required to implement based on need of IEnumerable interface.
        // Explicit interface implementation for non-generic IEnumerable
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    // -----------------------------------------------------------------------------------------------------------
    // 3. ITERATOR
    // The Iterator class provides the main functionality of the pattern.
    // It has fields for storing the current traversal position and a reference to a collection object.
    // Depending on the container and the traversal algorithm you access the data in a different way.
    // For simplicity we here access just an element at next index.
    // Possible ways of traversing: forward, backward, in order, etc.
    public class MyEnumerator<T> : IEnumerator<T>
    {
        private readonly T[] _items;
        private readonly int _count;
        private int _position = -1;

        public MyEnumerator(T[] items, int count)
        {
            _items = items;
            _count = count;
        }

        public T Current
        {
            get
            {
                if (_position < 0 || _position >= _count)
                    throw new InvalidOperationException();
                return _items[_position];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public bool MoveNext()
        {
            return ++_position < _count;
        }

        public void Reset()
        {
            _position = -1;
        }

        // Also required by IEnumerator<T>
        // Implement if necessary
        public void Dispose() { }
    }

    public static class ItemPrinter
    {
       public static void PrintItems<T>(IEnumerable<T> values)
        {
            foreach (var value in values)
            {
                Console.WriteLine(value);
            }
        }
    }
    // -----------------------------------------------------------------------------------------------------------
    public class ProgramIterator
    {
        public static void Main__()
        {
            // Syntax sugar for creating a collection. With the "Add" method and .NET 8 you can put data
            // directly into the collection using the square brackets. Else you would have to use the Add method
            // for each item.
            MyCollection<int> collection = [100, 200];

            //MyCollection<int> collection = new();
            //collection.Add(1);
            //collection.Add(2);

            // Iterate over the collection
            //foreach (int item in collection)
            //    Console.WriteLine(item);
            ItemPrinter.PrintItems(collection);
        }
    }
}