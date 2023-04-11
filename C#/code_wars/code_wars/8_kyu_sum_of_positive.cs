using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TASK:
// Sum all numbers in an array that are positive.

namespace code_wars
{
    public static class _8_kyu_sum_of_positive
    {
        public static int PositiveSum(int[] arr)
        {
            int sum = 0;
            foreach (int number in arr) if (number > 0) sum += number;
            return sum;
        }
    }
}
