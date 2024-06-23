using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    // 3. IMPLEMENT CONCRETE BUILDER
    // -----------------------------------------------------------------

    internal class ConcreteHouseBuilder: IHouseBuilder
    {
        private House _house = new House();

        public void BuildWalls()
        {
            _house.Walls = "Brick walls";
        }

        public void BuildRoof()
        {
            _house.Roof = "Concrete";
        }

        public void BuildWindows()
        {
            _house.Windows = "Double-glazed";
        }

        public House GetHouse()
        {
            return _house;
        }
    }
}
