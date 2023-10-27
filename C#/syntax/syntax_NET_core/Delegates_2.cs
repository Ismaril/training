using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax_NET_core
{
    internal class Delegates_2
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public enum ChangedEventState
    {
        Added,
        Cleared
    }

    public class ChangedEventArgs: EventArgs
    {
        public ChangedEventArgs(ChangedEventState changedState)
        {
            ChangedState = changedState;
        }

        public ChangedEventState ChangedState { get; set; }

    }


    // Goal is here to extend the functionality of the List<int> class by adding an event
    //  when the list is changed.
    public class IntegerListWithChangedEvent : List<int>
    {
        // The EventHandler delegate is predefined in the .NET Framework.
        // The first parameter is of type object and refers to the instance that raises the event.
        // The second parameter is derived from type EventArgs and holds the event data.
        // Default implementation of the EventHandler delegate:
        /*
        public delegate void EventHandler(object sender, EventArgs e);
        public event EventHandler Changed;
        */
        public delegate void ChangedEventHandler(object sender, ChangedEventArgs e);
        public event ChangedEventHandler Changed;

        new public void Add(int x)
        {
            base.Add(x);
            // Raise the Changed event.
            OnChanged(new ChangedEventArgs(ChangedEventState.Added));
        }

        new public void Clear()
        {
            base.Clear();
            // Raise the Changed event.
            OnChanged(new ChangedEventArgs(ChangedEventState.Cleared));

        }

        new public int this[int index]
        {
            set
            {
                base[index] = value;
            }
        }

        //void OnChanged(EventArgs e)
        void OnChanged(ChangedEventArgs e)
        {
            // Check if there are any methods assigned to the event.
            if (Changed != null)
                // The EventHandler delegate has two parameters. The first is of type object,
                //  and since there should be a reference to the object tha fires the event,
                //  there will always be "this" as the first parameter. The second parameter
                //  may have additional information about the event in it, so it may be 
                //  different for different events. Therefore, it is a good idea to make
                //  OnChanged method paramtetric and allow the value of the second parameter
                //  to be passed in externally.
                Changed(this, e);
        }
    }


    // Example usage
    public class Program
    {
        public static void Main()
        {
            IntegerListWithChangedEvent myList = new();
            myList.Changed += EventListener;

            myList.Add(1);
            myList.Add(2);

            Console.ReadLine();

        }

        static void EventListener(object sender, EventArgs e)
        {
            IntegerListWithChangedEvent list = (IntegerListWithChangedEvent)sender;
            if(list == null)
                return;
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("List has been changed. Current items are: ");
            foreach (int x in list)
                Console.WriteLine(x);
            if (list.Count == 0)
                Console.WriteLine("List is empty.");
            Console.WriteLine("------------------------------------------------");
        }
    }
}


