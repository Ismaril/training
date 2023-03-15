using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax
{
    internal static class MathModule
    {
        internal static void Main__()

        {
            Utilities utility = new Utilities();
            utility.Title("MATH MODULE");

            Math.Max(5, 10);
            Math.Min(5, 10);
            Math.Sqrt(64);
            Math.Abs(-4.7);
            Math.Round(9.99);

            utility.Separator();

        }
    }
}
