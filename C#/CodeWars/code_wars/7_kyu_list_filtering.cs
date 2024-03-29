﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* In this kata you will create a function that takes a list of non-negative 
 *  integers and strings and returns a new list with the strings filtered out.
 * ListFilterer.GetIntegersFromList(new List<object>(){1, 2, "a", "b"}) => {1, 2}
 * ListFilterer.GetIntegersFromList(new List<object>(){1, 2, "a", "b", 0, 15}) => {1, 2, 0, 15}
 * ListFilterer.GetIntegersFromList(new List<object>(){1, 2, "a", "b", "aasf", "1", "123", 231}) => {1, 2, 231} 
 * 
 */


namespace code_wars
{
    public static class _7_kyu_list_filtering
    {
        public static IEnumerable<int> GetIntegersFromList(List<object> listOfItems)
        {
            List<int> list = new List<int>();

            foreach (object item in listOfItems)
            {
                if (item is int) list.Add((int)item);
            }
            return list;
        }
    }
}
