using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP22_rusco_dc_csharp.Bevilacqua.gamemap
{
    public class FloorTile : Tile
    {

        public FloorTile(Tuple<int, int> position) : base(position, true) { }

    }
}
