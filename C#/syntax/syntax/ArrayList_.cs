﻿using System;

// Use these if you want to use an ArrayList
using System.Collections.Generic;
using System.Collections;

namespace syntax
{
    internal static class ArrayList_
    {


        internal static void Main__()
        {

            Utilities utility = new Utilities();
            utility.Title("ARRAY LIST"); 

            // ARRAYLIST acts the same as list in Python. You can add different datatypes to the same array.
            //  Also you can perform many operations on that list such as sort, revers and many others...

            ArrayList myArrayList = new ArrayList();
            
            // Add new items into list.
            myArrayList.Add(1);
            myArrayList.Add(3);
            myArrayList.Add(2); 
            myArrayList.Add("hello");
            myArrayList.Add(null);
            myArrayList.Add("Matador");
            myArrayList.Add(true);
            
            for (int i = 0; i < myArrayList.Count; i++)
            {
                Console.WriteLine($"Index: {i}, item: {myArrayList[i]}");    
            }
            
            myArrayList.Insert(index: 0, value: "Farks"); // Insert item at given index.
            myArrayList.RemoveAt(index: myArrayList.Count - 1); // Remove item at given index.

            utility.Separator();

            for (int i = 0; i < myArrayList.Count; i++)
            {
                Console.WriteLine($"Index: {i}, item: {myArrayList[i]}");    
            }          
            
            myArrayList.RemoveRange(index: 4, count: 3); // Remove number of items starting from some index.
            
            utility.Separator();

            for (int i = 0; i < myArrayList.Count; i++)
            {
                Console.WriteLine($"Index: {i}, item: {myArrayList[i]}");    
            }

            ArrayList myArrayList2 = new ArrayList();
            myArrayList2.Add(40);
            myArrayList2.Add(100);

            myArrayList.AddRange(myArrayList2); // Append list.
             for (int i = 0; i < myArrayList.Count; i++)
            {
                Console.WriteLine($"Index: {i}, item: {myArrayList[i]}");    
            }

            // There are many more functionalities when it comes to ArrayList. When you have time,
            //  complete this class, to have better overview of what it can all do.

            // It is possible to convert regular array into string array.
        }
    }
}