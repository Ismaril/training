using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    // 3. IMPLEMENT CONCRETE BUILDER (Concrete meaning "beton")
    // Example 1 of builder.
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

    // Example 2 of builder.
    // Builder for wooden houses
    internal class WoodenHouseBuilder : IHouseBuilder
    {
        private House _house = new House();

        public void BuildWalls()
        {
            _house.Walls = "Wooden walls";
        }

        public void BuildRoof()
        {
            _house.Roof = "Wooden";
        }

        public void BuildWindows()
        {
            _house.Windows = "Single-glazed";
        }

        public House GetHouse()
        {
            return _house;
        }
    }
}
