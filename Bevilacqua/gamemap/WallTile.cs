using Interactable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP22_rusco_dc_csharp.Bevilacqua.gamemap
{
    public class WallTile : Tile
    {
        public WallTile(Tuple<int, int> position) : base(position, false) { }

        public override bool Put(IInteractable obj) => false;
    }
}
