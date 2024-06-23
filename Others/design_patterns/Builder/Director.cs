using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    // 4. DEFINE THE DIRECTOR
    // -----------------------------------------------------------------

    internal class Director
    {
        private IHouseBuilder _houseBuilder;

        public Director(IHouseBuilder houseBuilder)
        {
            _houseBuilder = houseBuilder;
        }

        public void ConstructHouse()
        {
            _houseBuilder.BuildWalls();
            _houseBuilder.BuildRoof();
            _houseBuilder.BuildWindows();
        }

        public House GetHouse()
        {
            return _houseBuilder.GetHouse();
        }
    }
}
