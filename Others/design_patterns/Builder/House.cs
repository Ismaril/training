using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    // 1. DEFINE THE PRODUCT
    // -----------------------------------------------------------------

    internal class House
    {
        public string Walls { get; set; }
        public string Roof { get; set; }
        public string Windows { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public House() { }

        public override string ToString()
        {
            return $"House with {Walls}, {Roof} roof and {Windows} windows";
        }
    }
}
