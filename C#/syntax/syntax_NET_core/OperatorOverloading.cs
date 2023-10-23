using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax_NET_core
{
    internal class OperatorOverloading
    {
        public static void Main__()
        {
            Utilities utilities = new();
            utilities.PrintLine();

            Date date1 = new(2044, 12, 24);
            Console.WriteLine(date1 + 2);
            Console.WriteLine(date1++);


            utilities.PrintLine();


            Date date2 = new(2044, 12, 28);
            Date date3 = new(2044, 12, 28);

            // == operator by default compares references, not values. But since we got it overloaded,
            //  to compare actual values, these two objects are equal.
            Console.WriteLine(date2 == date3);


            utilities.PrintLine();


            Console.WriteLine((string)date1);

        }

        class Date
        {
            public int Year, Month, Day;

            public Date(int year, int month, int day)
            {
                Year = year;
                Month = month;
                Day = day;
            }

            public override string ToString()
            {
                return $"{Year}-{Month}-{Day}";
            }

            // Operator overloading.
            // Specify what happens when you use the + operator on this class.
            public static Date operator +(Date date, int days)
            {
                // It is necessary to create a new instace.
                return new Date(date.Year, date.Month, date.Day + days);
            }

            // Operator overloading.
            // Specify what happens when you use the ++ operator on this class.
            public static Date operator ++(Date date)
            {
                // It is necessary to create a new instace.
                return new Date(date.Year, date.Month, date.Day + 1);
            }

            // Operator overloading.
            // Specify what happens when you use the == operator on this class.
            // When you overload == operator, you should also overload != operator.
            // It is usually better to override this method when working with immutable types,
            //  rahter then reference types.
            public static bool operator ==(Date date1, Date date2)
            {
                return date1.ToString() == date2.ToString();
            }

            // Operator overloading.
            // Specify what happens when you use the != operator on this class.
            // When you overload != operator, you should also overload == operator.
            // It is usually better to override this method when working with immutable types,
            //  rahter then reference types.
            public static bool operator !=(Date date1, Date date2)
            {
                return date1.ToString() != date2.ToString();
            }

            // Cast operator overloading.
            // Specify what happens when you explicitly cast this class to string.
            public static explicit operator string(Date date)
            {
                return "Date: " + date.ToString();
            }

        }
    }
}
