using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax
{
    internal static class s_DateTime
    {
        internal static void Main__()
        {
            Utilities utility = new Utilities();
            utility.Title("FILES");

            DateTime birthYear = new DateTime(year: 1997, month: 1, day: 20);
            Console.WriteLine(birthYear.DayOfWeek);

            DateTime newDate = birthYear.AddYears(26);
            newDate = newDate.AddMonths(2);
            newDate = newDate.AddDays(3);
            Console.WriteLine(newDate.Date);

            utility.Separator();

            TimeSpan myTimeSpan = new TimeSpan(
                days: 31, hours: 23, minutes: 59, seconds: 10, milliseconds: 70
                );
            Console.WriteLine(myTimeSpan.ToString());



            Console.WriteLine(myTimeSpan.ToString());
        }
    }
}
