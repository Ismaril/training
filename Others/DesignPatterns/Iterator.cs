using System.Collections;

// COMPLEXITY OF PATTERN: MEDIUM
/*
Iterator is a behavioral design pattern that lets you traverse elements of a
collection without exposing its underlying representation (list, stack, tree, etc.).
The main idea of the Iterator pattern is to extract the traversal behavior of a
collection into a separate object called an iterator.
 */

namespace DesignPatterns
{
    // -----------------------------------------------------------------------------------------------------------
    // 1. REQUIRED BUILT IN INTERFACES:
    // IEnumerable: Exposes an enumerator, which supports a simple iteration over a non-generic collection.
    // IEnumerator: Supports a simple iteration over a collection.

    // -----------------------------------------------------------------------------------------------------------
    // 2. COLLECTION
    // The Collection class contains some items and implements the IEnumerable interface.
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
        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator<T>(_items, _count);
        }

        // This is required to implement based on need of IEnumerable interface.
        // Explicit interface implementation for non-generic IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    // -----------------------------------------------------------------------------------------------------------
    // 3. ITERATOR
    // The Iterator class provides the main functionality of the pattern.
    // It has fields for storing the current traversal position and a reference to a collection object.
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

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            return ++_position < _count;
        }

        public void Reset()
        {
            _position = -1;
        }

        // Also required by IEnumerator<T>
        public void Dispose()
        {
            // Implement if needed
        }
    }

    // -----------------------------------------------------------------------------------------------------------
    public class ProgramIterator
    {
        public static void Main__()
        {
            MyCollection<int> collection = new();
            collection.Add(1);
            collection.Add(2);
            collection.Add(3);
        }
    }
}