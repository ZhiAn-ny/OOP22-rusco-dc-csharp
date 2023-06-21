using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP22_rusco_dc_csharp.Bevilacqua.GameMap
{
    public class FloorTile : Tile
    {

        public FloorTile(Tuple<int, int> position) : base(position, true) { }

        public override string GetPath()
        {
            return "it/unibo/ruscodc/map_res/FloorTile";
        }
    }
}
