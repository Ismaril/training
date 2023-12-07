using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Write a program that will calculate the number of trailing zeros in a factorial of a given number.

N! = 1 * 2 * 3 *  ... * N

Be careful 1000! has 2568 digits...

zeros(6) = 1
# 6! = 1 * 2 * 3 * 4 * 5 * 6 = 720 --> 1 trailing zero

zeros(12) = 2
# 12! = 479001600 --> 2 trailing zeros

Hint: You're not meant to calculate the factorial. Find another way to find the number of zeros.
*/


namespace code_wars
{
    public static class _5_kyu_number_of_trailing_zeroes_of_N_factorial
    {
        public static int TrailingZeros(int n)
        {
            // Formula:
            // Each other Floor(n/x) applies only if the x <= n.
            // result = Floor(n/5)+Floor(n/25)+Floor(n/125)....Floor(n/x)

            double numberOfDivisors = 30;
            double[] divisors = new double[(int)numberOfDivisors];
            decimal result = 0;
            
            // Create an array of divisors. Each is a multiply of 5.
            for (double i = 0; i < numberOfDivisors; i++)
            {
                divisors[(int)i] = Math.Pow(5, i+1);
            }
            
            // Compute the result
            foreach (decimal divisor in divisors)
            {
                if (divisor <= n) result += Math.Floor(n / divisor);
                else break;
            }
            return (int)result;
        }


        // Best practise:
        /*
        using System;

        public static class Kata 
        {
          public static int TrailingZeros(int n)
          { 
            int fives = 0;
            for (int i = 5; i <= n; i *= 5)
                fives += n/i;
            
            return fives;
          }
        }
        */
    }
}
