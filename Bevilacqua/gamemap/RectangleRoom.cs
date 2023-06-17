using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP22_rusco_dc_csharp.Bevilacqua.gamemap
{
    public class RectangleRoom : IRoom
    {
        public Tuple<int, int> Size { get; }
        public List<IActor> Monsters { get; }
        public Dictionary<Direction, IRoom> ConnectedRooms { get; }
        public List<ITile> Tiles { get; }

        public RectangleRoom(int width, int height)
        {
            this.Size = new Tuple<int, int>(width, height);
            this.Tiles = new List<ITile>();
            this.Monsters = new List<IActor>();
            this.ConnectedRooms = new Dictionary<Direction, IRoom>();
        }

        public int GetArea()
        {
            return this.Size.Item1 * this.Size.Item2;
        }

        private void setTiles(int width, int height) 
        {
        
        }

    }
}
