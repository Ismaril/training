using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax_NET_core
{
    // In this file are explained:
    // EVENT ACCESSORS
    // INHERITANCE OF DELEGATES

    // --------------------------------------------------------------------------------------------
    // EVENT ACCESSORS
    // Remember how we passed in previous DelegateXX.cs files the outside functions to delegate
    //  with += operator?
    // Now we can control this process with accessors. We can either subscribe or unsubscribe
    //  and remove the function from the delegate.
    public class Worker
    {
        // Just a reminder EventHandler is a built-in delegate.
        private EventHandler handler;

        // With add and remove accessors we can control the subscription and unsubscription
        //  from this delegate/event.
        // Similar to properties, we will use this event to subscribe and unsubscribe from
        //  the outside.
        // With the add/remove keywords we will then manipulate private delegate. (Just as
        //  with properties we manipulate private fields.)
        public event EventHandler WorkDone
        {
            // You can add some condition, for example if you want to subscribe only once.
            add
            {
                if (handler == null)
                    handler += value;
                else
                    throw new InvalidOperationException(
                        "It is possible to subscribe only once " +
                        "to this delegate."
                        );
            }
            remove
            {
                handler -= value;
            }
        }

        public virtual void DoWork()
        {
            Console.WriteLine("Working");
            OnWorkDone();
        }

        //q: What does protected keyword mean?
        //a: It means that the method is accessible only from the class itself and from the child
        // classes.
        /// <summary>
        /// We will call this method when the work is done (in DoWork method).
        /// </summary>
        protected virtual void OnWorkDone()
        {
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
    }

    // --------------------------------------------------------------------------------------------
    public class ExtendedWorker : Worker
    {
        public override void DoWork()
        {
            Console.WriteLine("Extended Working");
            OnWorkDone();
        }
    }

    // --------------------------------------------------------------------------------------------

    // UNCOMMENT THE CODE BELOW TO SEE THE EXAMPLE USAGE OF THE CLASSES ABOVE.
    //  (Dont forget co comment out the main function in Program.cs)
    /*
    public class Program
    {

        public static void Main()
        {
            Worker worker = new();
            Utilities utilities = new();

            // You can subscribe and unsubscribe from the event.
            // Since we got a condition in the add accessor, we can subscribe only once.
            //  Therefore as long as we have only subscribed once, there will be no error.
            worker.WorkDone += worker_WorkDone; // Subscribe
            worker.WorkDone -= worker_WorkDone; // Unsubscribe
            worker.WorkDone += worker_WorkDone; // Subscribe
            // Resulting subscibtion is only once.
            worker.DoWork();

            utilities.PrintLine();

            // Overriden method from the child class.
            // This child class and it's delegate is inherited from the parent class.
            //  But the function that is passed to the delegate of parent class is not inherited.
            //  You now have to pass the function to the delegate of child class.
            ExtendedWorker extendedWorker = new();
            extendedWorker.WorkDone += extendedWorker_WorkDone;
            extendedWorker.DoWork();

            Console.ReadLine();
        }

        // Outside function that is called when the event is triggered.
        // You pass this function as a parameter to the event/delegate.
        static void worker_WorkDone(object sender, EventArgs e)
        {
            Console.WriteLine("Work is Done");
        }

        static void extendedWorker_WorkDone(object sender, EventArgs e)
        {
            Console.WriteLine("Extended Work is Done");
        }
    }
    */
}
