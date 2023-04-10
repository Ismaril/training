using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* Given an array of integers, find the one that appears an odd number of times.

There will always be only one integer that appears an odd number of times.

Examples
[7] should return 7, because it occurs 1 time (which is odd).
[0] should return 0, because it occurs 1 time (which is odd).
[1,1,2] should return 2, because it occurs 1 time (which is odd).
[0,1,0,1,0] should return 0, because it occurs 3 times (which is odd).
[1,2,2,3,3,3,4,3,3,3,2,2,1] should return 4, because it appears 1 time (which is odd).
*/

namespace code_wars
{
    internal static class _6_kyu_find_the_odd_int
    {
        internal static int find_it(int[] sequence)
        {
            List<int> list = sequence.ToList();
            list.Sort();

            Dictionary<int, int> countsOfEachNumber = new Dictionary<int, int>();

            foreach (int number in list)
            {
                if (!countsOfEachNumber.ContainsKey(number))
                {
                    countsOfEachNumber[number] = 1;
                }
                else
                {
                    countsOfEachNumber[number]++;
                }
            }

            int result = 0;

            foreach (KeyValuePair<int, int> keyValuePair in countsOfEachNumber)
            {
                if(keyValuePair.Value % 2 == 1)
                {
                    return keyValuePair.Key;
                }
            }

            return -1;
        }
    }
}
