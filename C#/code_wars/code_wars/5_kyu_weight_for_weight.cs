using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
My friend John and I are members of the "Fat to Fit Club (FFC)". John is worried because each month a list with the weights of members is published and each month he is the last on the list which means he is the heaviest.

I am the one who establishes the list so I told him: "Don't worry any more, I will modify the order of the list". It was decided to attribute a "weight" to numbers. The weight of a number will be from now on the sum of its digits.

For example 99 will have "weight" 18, 100 will have "weight" 1 so in the list 100 will come before 99.

Given a string with the weights of FFC members in normal order can you give this string ordered by "weights" of these numbers?

"56 65 74 100 99 68 86 180 90" ordered by numbers weights becomes: 

"100 180 90 56 65 74 68 86 99"

When two numbers have the same "weight", let us class them as if they were strings (alphabetical ordering) and not numbers:

180 is before 90 since, having the same "weight" (9), it comes before as a string.

All numbers in the list are positive numbers and the list can be empty.
*/

namespace code_wars
{
    public static class _5_kyu_weight_for_weight
    {
        public static string orderWeight(string usersInput)
        {
            // Trim all leading and traling whitespaces and split into string array.
            string[] userInputSplitted = usersInput.Trim(' ').Split(' ');
            List<(int, string)> matrix = new List<(int, string)>(); // List with nested tuple.
           
            // Add tuples with weight and corresponding original number.
            foreach (string item in userInputSplitted)
            {
                int weight = new int();
                foreach (char digit in item)
                {
                    weight += Convert.ToInt32(digit.ToString());
                }
                matrix.Add((weight, item));
            }
            
            // Sort accross both dimensions.
            matrix.Sort();
            
            // Create an result array from 2nd dimension.
            string[] result = new string[matrix.Count];
            int i = 0;
            foreach ((int, string) pair in matrix)
            {
                result[i] = pair.Item2;
                i++;
            }

            return String.Join(separator: " ", result);
        }
    }
}
