using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Find a next bigger number:
// 12 -> 21
// 414 -> 441

// During submission of this kata, there was a bug on their website. I had a try/catch block at the
//  end of this code and kata was evaluated as passes even thoug the tests were not passed.

namespace code_wars
{
    public static class _4_kyu_next_bigger_number_with_the_same_digits
    {
        public static long NextBiggerNumber(long number)
        {
            string numberS = Convert.ToString(number);
            string result = string.Empty;

            if (numberS.Length == 1) return -1;

            for (int i = numberS.Length - 1; i > 0; i--)
            {
                int numberAtCurrentIndex = int.Parse(numberS[i].ToString());
                int numberAtNextIndex = int.Parse(numberS[i - 1].ToString());

                if (numberAtCurrentIndex <= numberAtNextIndex) continue;
                else if (numberAtCurrentIndex > numberAtNextIndex)
                {
                    string nextBiggerNumbber = string.Empty;
                    char[] end = numberS.Substring(i-1, numberS.Length-i+1).ToCharArray();
                    Array.Sort(end);
                    string end_ = new string(end);

                    for (int j = 0; j < end.Length; j++)
                    {
                        int digit = int.Parse(end[j].ToString());
                        if (digit > numberAtNextIndex)
                        {
                            nextBiggerNumbber += digit.ToString();
                            end_ = end_.Remove(j, 1);
                            break;
                        }
                    }
                    numberS = numberS.Insert(startIndex: i - 1, value: nextBiggerNumbber);
                    numberS = numberS.Remove(startIndex: i);
                    result += numberS + end_;

                    break;
                }
            }
            if (result == "") return -1;
            return long.Parse(result);

        }
    }
}

