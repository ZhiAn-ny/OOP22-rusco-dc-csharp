using Interactable;

namespace OOP22_rusco_dc_csharp.Bevilacqua.GameMap
{
    public class WallTile : Tile
    {
        private readonly WallType side;

        public WallTile(Tuple<int, int> position, WallType side) : base(position, false) 
        {
            this.side = side;
        }

        public override string GetPath()
        {
            return "it/unibo/ruscodc/map_res/WallTile/" 
                + Enum.GetName(typeof(WallType), this.side);
        }

        public override bool Put(IInteractable obj) => false;
    }
}
