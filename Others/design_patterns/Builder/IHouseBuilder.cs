using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    // 2. DEFINE THE BUILDER INTERFACE
    // -----------------------------------------------------------------
    internal interface IHouseBuilder
    {
        void BuildWalls();
        void BuildRoof();
        void BuildWindows();
        House GetHouse();
    }
}
