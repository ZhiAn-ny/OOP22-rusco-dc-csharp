using Interactable;
using NUnit.Framework;
using OOP22_rusco_dc_csharp.Bevilacqua.gamemap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP22_rusco_dc_csharp.Bevilacqua.Test
{
    [TestFixture]
    public class TileTest
    {
        private readonly Tuple<int, int> defaultPos= new Tuple<int, int>(2, 2);

        [Test]
        public void TestConstructor()
        {
            List<ITile> tiles = new List<ITile>();
            tiles.Add(new FloorTile(this.defaultPos));
            tiles.Add(new WallTile(this.defaultPos));
            tiles.ForEach(tile =>
            {
                Assert.IsNotNull(tile);
                Assert.AreEqual(tile.Position, this.defaultPos);
                Assert.IsNull(tile.Get());
            });
            Assert.IsTrue(tiles[0].IsAccessible);
            Assert.IsFalse(tiles[1].IsAccessible);
        }

        [Test]
        public void TestFloorPlacement()
        {
            ITile tile = new FloorTile(this.defaultPos);
            IInteractable door = new Door(this.defaultPos);
            Assert.IsTrue(tile.Put(door));
            Assert.IsFalse(tile.Put(door));
            Assert.IsNotNull(tile.Get());
            Assert.AreEqual(door, tile.Empty());
            Assert.IsTrue(tile.Put(door));
        }

        [Test]
        public void TestWallPlacement()
        {
            ITile tile = new WallTile(this.defaultPos);
            IInteractable door = new Door(this.defaultPos);
            Assert.IsFalse(tile.Put(door));
            Assert.IsNull(tile.Get());
            Assert.IsNull(tile.Empty());
            Assert.IsFalse(tile.Put(door));
        }

    }
}
