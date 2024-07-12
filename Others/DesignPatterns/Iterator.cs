using System.Collections;

/*
Iterator is a behavioral design pattern that lets you traverse elements of a
collection without exposing its underlying representation (list, stack, tree, etc.).
The main idea of the Iterator pattern is to extract the traversal behavior of a
collection into a separate object called an iterator.
 */

namespace DesignPatterns
{
    abstract class MyAbstractIterator : IEnumerator
    {
        object IEnumerator.Current => GetCurrentElement();

        // Returns the key of the current element
        public abstract int GetCurrentKey();

        // Returns the current element
        public abstract object GetCurrentElement();

        // Move forward to next element
        public abstract bool MoveNext();

        // Rewinds the Iterator to the first element
        public abstract void Reset();
    }

    abstract class IteratorAggregate : IEnumerable
    {
        // Returns an Iterator or another IteratorAggregate to the implementing
        // object.
        public abstract IEnumerator GetEnumerator();
    }

    // Concrete Iterators implement various traversal algorithms. These classes
    // store the current traversal position at all times.
    // This is the actual "Iterator" when we talk about the iterator design pattern.
    class AlphabeticalOrderIterator : MyAbstractIterator
    {
        private WordsCollection _collection;

        // Stores the current traversal position. An iterator may have a lot of
        // other fields for storing iteration state, especially when it is
        // supposed to work with a particular kind of collection.
        private int _position = -1;

        private bool _isDirectionReversed = false;

        public AlphabeticalOrderIterator(
            WordsCollection collection, bool reverse = false)
        {
            _collection = collection;
            _isDirectionReversed = reverse;

            if (reverse)
                _position = collection.GetItems().Count;
        }

        public override object GetCurrentElement() => _collection.GetItems()[_position];

        public override int GetCurrentKey() => _position;

        public override bool MoveNext()
        {
            int updatedPosition = _position + (_isDirectionReversed ? -1 : 1);

            if (updatedPosition >= 0 && updatedPosition < _collection.GetItems().Count)
            {
                _position = updatedPosition;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Reset()
        {
            int lastIndexPosition = _collection.GetItems().Count - 1;
            int firstIndexPosition = 0;
            _position = _isDirectionReversed ? lastIndexPosition : firstIndexPosition;
        }
    }

    // Concrete Collections provide one or several methods for retrieving fresh
    // iterator instances, compatible with the collection class.
    class WordsCollection : IteratorAggregate
    {
        List<string> _collection = [];

        bool _isDirectionReversed = false;

        public void ReverseDirection() => _isDirectionReversed = !_isDirectionReversed;

        public List<string> GetItems() => _collection;

        public void AddItem(string item) => _collection.Add(item);

        public override IEnumerator GetEnumerator()
        {
            return new AlphabeticalOrderIterator(this, _isDirectionReversed);
        }
    }

    public class ProgramIterator
    {
        public static void Main__()
        {
            // The client code may or may not know about the Concrete Iterator
            // or Collection classes, depending on the level of indirection you
            // want to keep in your program.
            WordsCollection collection = new();
            collection.AddItem("First");
            collection.AddItem("Second");
            collection.AddItem("Third");

            Console.WriteLine("Straight traversal:");
            foreach (var element in collection)
                Console.WriteLine(element);

            ConsoleOutputSeparator.Separator();

            Console.WriteLine("\nReverse traversal:");
            collection.ReverseDirection();
            foreach (var element in collection)
                Console.WriteLine(element);
        }
    }
}