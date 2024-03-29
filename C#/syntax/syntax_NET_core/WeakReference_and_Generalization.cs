﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// GENERATED BY GITHUB COPILOT
/*
In .NET, the garbage collector (GC) provides automatic memory management by reclaiming 
    the memory occupied by objects that are no longer in use. 
The GC organizes the managed heap into generations to handle long-lived and short-lived 
    objects separately. 
This approach can significantly improve performance.
There are three generations of objects in the heap:
•	Generation 0: 
        This is the youngest generation and contains short-lived objects. 
        An example of a short-lived object is a temporary variable. 
        Garbage collection occurs most frequently in this generation.
•	Generation 1: 
        This is the buffer generation between short-lived objects and long-lived objects.
•	Generation 2: 
        This generation contains long-lived objects. 
        An example of a long-lived object could be an object in a server application 
            that contains static data that's live for the duration of the process.

When the garbage collector performs a collection, it checks the objects in the generations 
    to see if they are still being referenced. 
If they are not, it frees the memory used by these objects.
The garbage collector performs collections on Generation 0 separately from Generations 1 and 2. 
If a Generation 0 collection does not reclaim enough memory, then the garbage collector can 
    perform a Generation 1 or even Generation 2 collection.
The idea behind this generational approach is that newer objects tend to have a shorter lifespan, 
    so by focusing on them, the garbage collector can free up memory more efficiently.
*/


// In this exercise, we will create a class that will be able to reuse a created
//  object if the Garbage Collector does not clean up the object.
// If the object is cleaned up, a new object will be made. This is and example
//  of how we can reuse an object even when you offer it to the Garbage Collector 
//  to clean up in case of a memory shortage.

namespace syntax_NET_core
{
    internal static class WeakReference_and_Generalization
    {
        public static void Main__()
        {
            Utilities utilities = new();
            utilities.PrintLine();

            Helper helper = new();

            // YOU WILL SEE IN THE CONSOLE THAT EVERY TIME WE CALL
            //  THE USEOBJECT METHOD, A NEW INSTANCE OF THE STRINGBUILDER
            //  IF THERE IS NO WEAK REFERENCE & GARBAGE COLLECTOR COLLECTED
            //  THE OBJECT.


            // Note that with all these method calls,
            //  we create a new instance of the StringBuilder.
            // This is obviously done on purpose to show and to
            //  alocate more and more memory for no reason.
            helper.UseObject();
            helper.UseObject();
            helper.UseObject();

            utilities.PrintLine();

            // This time we will use the WeakReference class
            //  to check if the object is still alive.
            // If it is, we will reuse it, if not, we will
            //  create a new one.
            helper.UseObjectWithWeakReference();
            helper.UseObjectWithWeakReference();
            helper.UseObjectWithWeakReference();

            utilities.PrintLine();

            // HOW TO ALLOW THE GARBAGE COLLECTOR TO CLEAN UP OBJECTS
            //  WITH THE WEAKREFERENCE CLASS:
            helper.UseObjectWithWeakReference();
            // This would normally force the Garbage Collector
            //  to clean up the object. But since we still hold
            //  a weak reference to it, the object will not be
            //  cleaned up.
            GC.Collect();
            helper.UseObjectWithWeakReference();
            // Here we will remove the weak reference to the object
            //  and allow the Garbage Collector to clean it up.
            //  Therefore new object will be created.
            helper.AllowGarbageCollectorToCleanUp();
            GC.Collect();
            helper.UseObjectWithWeakReference();

            utilities.PrintLine();

            Helper helper1 = new();
            helper1.UseObjectWithWeakReference();
            helper1.ShowGenratationsInfo();

            // See that object is gradually moved to the next (higher) generation.
            // Its because the object is reused and the Garbage Collector
            //  will not clean it up.
            GC.Collect();
            helper1.ShowGenratationsInfo();
            GC.Collect();
            helper1.ShowGenratationsInfo();

            utilities.PrintLine();

            // Since the object in helper1 was moved to higher generation in the block
            //  above, even if we now allow the Garbage Collector to clean up it will not
            //  be cleaned up if we just call GC.Collect() with intention to clean
            //  only the 0th or 1st generation.
            helper1.AllowGarbageCollectorToCleanUp();
            // Will not clean it up.
            GC.Collect(0);
            helper1.ShowGenratationsInfo();
            // Will not clean it up.
            GC.Collect(1);
            helper1.ShowGenratationsInfo();
            // Will clean it up.
            GC.Collect(2);
            helper1.ShowGenratationsInfo();
        }
    }

    class Helper
    {
        // The StringBuilder data type will serve as an
        //  example of an object we want to reuse, but
        //  we also want to allow the Garbage Collector
        //  to clean up this object. This whole idea will
        //  become more important when we have an object
        //  that will take up a lot of memory, which can
        //  be a StringBuilder for example, but of course
        //  we can use any reference type.
        StringBuilder stringBuilder;

        // This reference is not seend by the Garbage Collector,
        //   so only if this weak reference exists, the object
        //   will be cleand up.
        WeakReference<StringBuilder> weakReference;

        /// <summary>
        /// Create new objects of the StringBuilder class.
        /// </summary>
        public void UseObject()
        {
            stringBuilder = new StringBuilder("Just String");
            Console.WriteLine("Created New instance of StringBuilder");
            Console.WriteLine($"Used: {stringBuilder.ToString()}");
        }

        /// <summary>
        /// Create new objects of the StringBuilder class only
        /// if the Garbage Collector has cleaned up the object.
        /// </summary>
        public void UseObjectWithWeakReference()
        {
            // TryGetTarget method returns true if the target has been
            //  garbage collected.
            if (weakReference == null
                || !weakReference.TryGetTarget(out stringBuilder))
            {
                stringBuilder = new StringBuilder("Just String");
                weakReference = new WeakReference<StringBuilder>(stringBuilder);
                Console.WriteLine("Created New instance of StringBuilder");
            }
            Console.WriteLine($"Used: {stringBuilder.ToString()}");
        }

        public void AllowGarbageCollectorToCleanUp()
        {
            stringBuilder = null;
        }

        /// <summary>
        /// Return true if object has been garbage collected.
        /// </summary>
        /// <returns></returns>
        public bool IsAlive()
        {
            return weakReference.TryGetTarget(target: out _);
        }

        public void ShowGenratationsInfo()
        {
            if (IsAlive())
            {
                if (stringBuilder != null)
                {
                    Console.WriteLine(
                        $"MaxGeneration: {GC.MaxGeneration}, " +
                        $"ObjectGeneration: {GC.GetGeneration(stringBuilder)}"
                        );
                }
                else
                {
                    Console.WriteLine("Still alive.");
                }
            }
            else
            {
                Console.WriteLine("Not alive");
            }
        }
    }
}
