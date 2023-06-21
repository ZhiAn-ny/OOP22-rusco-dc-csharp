using System;
using Interactable;
using Marcaccio.actors;
using OOP22_rusco_dc_csharp.Marcaccio.actors;


namespace OOP22_rusco_dc_csharp.Bevilacqua.gamemap
{
    public class RectangleRoom : IRoom
    {
        public Tuple<int, int> Size { get; }
        public List<IActor> Monsters { get; }
        public Dictionary<Direction, IRoom?> ConnectedRooms { get; }
        public List<ITile> Tiles { get; }

        public RectangleRoom(int width, int height)
        {
            this.Size = new Tuple<int, int>(width, height);
            this.Tiles = new List<ITile>();
            this.Monsters = new List<IActor>();
            this.ConnectedRooms = new Dictionary<Direction, IRoom?>();
            this.setTiles(width, height);
        }

        public int GetArea()
        {
            return this.Size.Item1 * this.Size.Item2;
        }

        private void setTiles(int width, int height) 
        {
            for (int i = 0; i < width + 1; i++)
            {
                for (int j = 0; j < height + 1; j++)
                {
                    if (i == 0 || j == 0 || i == width || j == height + 1)
                    {
                        this.Tiles.Add(new WallTile(new Tuple<int, int>(i, j)));
                    }
                    else
                    {
                        this.Tiles.Add(new FloorTile(new Tuple<int, int>(i, j)));
                    }
                }
            }
        }

        public bool AddDoor(Direction dir)
        {
            List<ITile> onSide = this.Tiles
                .Where((ITile t) => this.OnSide(dir).Invoke(t))
                .Where((ITile t) => this.IsNotCorner().Invoke(t)).ToList();
            Random random = new Random();
            ITile toReplace = onSide[random.Next(onSide.Count)];
            ITile newTile = new FloorTile(toReplace.Position);
            newTile.Put(new Door(newTile.Position));
            if (!this.ConnectedRooms.ContainsKey(dir))
            {
                this.ConnectedRooms.Add(dir, null);
                return this.ReplaceTile(toReplace.Position, newTile);
            }
            return false;
        }

        private bool ReplaceTile(Tuple<int, int> position, ITile newTile)
        {
            ITile? old = this.Tiles
                .Where((ITile t) => t.Position.Equals(position))
                .FirstOrDefault();
            if (old != null && old.Get() == null)
            {
                this.Tiles.Remove(old);
                this.Tiles.Add(newTile);
                return true;
            }
            return false;
        }

        private Predicate<ITile> OnSide(Direction dir)
        {
            switch(dir)
            {
                case Direction.Up:
                    return (ITile t) => t.Position.Item2 == 0;
                case Direction.Down:
                    return (ITile t) => t.Position.Item2 == this.Size.Item2 + 1;
                case Direction.Left:
                    return (ITile t) => t.Position.Item1 == 0;
                case Direction.Right:
                    return (ITile t) => t.Position.Item1 == this.Size.Item1 + 1;
                default:
                    return (ITile t) => false;
            }
        }

        private Predicate<ITile> IsNotCorner() => (ITile t) => !(
            (t.Position.Item1 == 0 && t.Position.Item2 == 0)
            || (t.Position.Item1 == 0 && t.Position.Item2 == this.Size.Item2 + 1)
            || (t.Position.Item1 == this.Size.Item1 + 1 && t.Position.Item2 == 0)
            || (t.Position.Item1 == this.Size.Item1 + 1 && t.Position.Item2 == this.Size.Item2 + 1)
        );

        public bool AddConnectedRoom(Direction dir, IRoom other)
        {
            if (this.ConnectedRooms.ContainsKey(dir) 
                && this.ConnectedRooms[dir] == null)
            {
                this.ConnectedRooms[dir] = other;
                other.AddConnectedRoom(Directions.GetOpposite(dir), this);
                return true;
            }
            return false;
        }
    }
}
