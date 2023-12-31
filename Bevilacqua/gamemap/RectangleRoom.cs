﻿using Interactable;
using OOP22_rusco_dc_csharp.Marcaccio.actors;
using IEntity = OOP22_rusco_dc_csharp.Marcaccio.IEntity;
using System.Collections.Immutable;

namespace OOP22_rusco_dc_csharp.Bevilacqua.GameMap
{
    public class RectangleRoom : IRoom
    {
        private readonly int minRoomSide = 3;
        private readonly Random random = new Random();

        private List<ITile> tiles;
        private List<IActor> monsters;

        public Tuple<int, int> Size { get; }
        public ImmutableList<IActor> Monsters => this.monsters.ToImmutableList();
        public Dictionary<Direction, IRoom?> ConnectedRooms { get; }
        public ImmutableList<IEntity> GetTilesAsEntities => this.tiles
            .Select(tile => (IEntity) tile)
            .ToImmutableList();

        public ImmutableList<IInteractable> ObjectsInRoom => this.tiles
            .Where(tile => tile.Get() != null)
            .Select(tile => tile.Get())
            .ToImmutableList();

        public RectangleRoom(int width, int height)
        {
            if (width < this.minRoomSide || height < minRoomSide)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.Size = new Tuple<int, int>(width, height);
            this.tiles = new List<ITile>();
            this.monsters = new List<IActor>();
            this.ConnectedRooms = new Dictionary<Direction, IRoom?>();
            this.setTiles(width, height);
        }

        public int GetArea()
        {
            return this.Size.Item1 * this.Size.Item2;
        }

        private void setTiles(int width, int height) 
        {
            for (int i = 0; i <= width + 1; i++)
            {
                for (int j = 0; j <= height + 1; j++)
                {
                    Tuple<int, int> pos = new Tuple<int, int>(i, j);
                    if (i == 0 || j == 0 || i == width + 1 || j == height + 1)
                    {
                        this.tiles.Add(new WallTile(
                            pos, this.GetWallType(pos, this.Size)
                        ));
                    }
                    else
                    {
                        this.tiles.Add(new FloorTile(pos, true));
                    }
                }
            }
        }

        private WallType GetWallType(Tuple<int, int> pos, Tuple<int, int> size)
        {
            if (pos.Item2 == 0)
            {
                if (pos.Item1 == 0)
                    return WallType.TOP_LEFT;
                if (pos.Item1 == size.Item1 + 1)
                    return WallType.TOP_RIGHT;
                return WallType.TOP;
            }
            if (pos.Item2 == size.Item2 + 1)
            {
                if (pos.Item1 == 0)
                    return WallType.BOTTOM_LEFT;
                if (pos.Item1 == size.Item1 + 1)
                    return WallType.BOTTOM_RIGHT;
                return WallType.BOTTOM;
            }
            if (pos.Item1 == size.Item1 + 1)
                return WallType.RIGHT;
            if (pos.Item1 == 0)
                return WallType.LEFT;
            return WallType.UNDEFINED;
        }

        public bool AddDoor(Direction dir)
        {
            List<ITile> onSide = this.tiles
                .Where((ITile t) => this.OnSide(dir).Invoke(t))
                .Where((ITile t) => this.IsNotCorner().Invoke(t)).ToList();
            if (!onSide.Any())
            {
                return false;
            }
            Random random = new Random();
            ITile toReplace = onSide[random.Next(onSide.Count)];
            ITile newTile = new FloorTile(toReplace.Position, true);
            newTile.Put(new Door(newTile.Position, dir));
            if (!this.ConnectedRooms.ContainsKey(dir))
            {
                this.ConnectedRooms.Add(dir, null);
                return this.ReplaceTile(toReplace.Position, newTile);
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

        public ITile? Get(Tuple<int, int> pos)
        {
            return this.tiles.Find(tile => tile.Position.Equals(pos));
        }

        public bool IsAccessible(Tuple<int, int> pos)
        {
            ITile? tile = this.Get(pos);
            return tile != null && tile.IsAccessible;
        }

        public bool IsInRoom(Tuple<int, int> pos)
        {
            return this.Get(pos) != null;
        }

        public bool ReplaceTile(Tuple<int, int> pos, ITile newTile)
        {
            ITile? old = this.Get(pos);
            if (old != null && this.tiles.Remove(old))
            {
                this.tiles.Add(newTile);
                return true;
            }
            return false;
        }

        public void ClearArea(Tuple<int, int> pos, int rad)
        {
            ImmutableList<Tuple<int, int>> positions = this.GetCircle(pos, rad);
            this.tiles.Where(tile => positions.Contains(tile.Position))
                .Where(tile => !(tile.Get() is Door) && !(tile.Get() is Stair))
                .ToList().ForEach(tile => tile.Empty());
            this.monsters.RemoveAll(mst => positions.Contains(mst.GetPos()));
        }

        private ImmutableList<Tuple<int, int>> GetCircle(Tuple<int, int> pos, int rad)
        {
            List<Tuple<int, int>> list = new List<Tuple<int, int>>();
            for (int i = -rad; i <= rad; i++)
            {
                for (int j = -rad; j <= rad; j++)
                {
                    list.Add(new Tuple<int, int>(pos.Item1 + i, pos.Item2 + j));
                }

            }
            return list.ToImmutableList();
        }

        public bool AddMonster(IActor monster)
        {
            IActor? enemy = this.monsters.Find(mst => 
                mst.GetPos().Equals(monster.GetPos())
            );
            ITile? tile = this.Get(monster.GetPos());
            if (enemy == null && tile != null && tile.IsAccessible)
            {
                if (tile.Get() != null && !tile.Get().IsTransitable())
                {
                    return false;
                }
                this.monsters.Add(monster);
                return true;
            }
            return false;
        }

        public void EliminateMonster(IActor monster)
        {
            IActor? mst = this.monsters.Find(mst => 
                mst.GetPos().Equals(monster.GetPos())
            );
            if (mst != null && mst.GetName().Equals(monster.GetName()))
            {
                this.monsters.Remove(mst);
            }
        }

        public bool AddStair(Direction dir)
        {
            ITile? tile = null;
            IInteractable? door = this.GetDoorOnSide(dir);
            if (door != null)
            {
                //TODO: manca GetPos in door
                //tile = this.Get(door.GetPos());
            }
            else
            {
                List<WallTile> onSide = this.tiles
                    .OfType<WallTile>()
                    .Where(tile => this.OnSide(dir).Invoke(tile))
                    .Where(tile => this.IsNotCorner().Invoke(tile))
                    .ToList();
                if (onSide.Any()) 
                {
                    tile = onSide.ElementAt(this.random.Next(onSide.Count));
                    tile = new FloorTile(tile.Position, true);
                    this.ReplaceTile(tile.Position, tile);
                }
            }
            if (tile != null) 
            {
                tile.Empty();
                tile.Put(new Stair(tile.Position));
                return true;
            }
            return false;
        }

        public IRoom? GetConnectedRoom(Direction dir)
        {
            return this.ConnectedRooms[dir];
        }

        public IInteractable? GetDoorOnSide(Direction dir)
        {
            return this.tiles.Where(tile => this.OnSide(dir).Invoke(tile))
                .Where(tile => tile.Get() != null)
                .Select(tile => tile.Get())
                .OfType<Door>()
                .Cast<IInteractable>().FirstOrDefault();
        }

        public bool Put(Tuple<int, int> pos, IInteractable obj)
        {
            ITile? tile = this.Get(pos);
            if (tile != null)
            {
                return tile.Put(obj);
            }
            return false;
        }
    }
}
