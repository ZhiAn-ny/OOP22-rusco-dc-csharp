using Interactable;
using OOP22_rusco_dc_csharp.Bevilacqua.GameMap;
using OOP22_rusco_dc_csharp.Marcaccio.actors;
using OOP22_rusco_dc_csharp.Marcaccio.actors.hero;

namespace OOP22_rusco_dc_csharp.Bevilacqua.Test
{
    public class RoomTest
    {
        private IRoom newRoom => new RectangleRoom(3, 3);
        private IActor testActor => new Hero("test", new Tuple<int, int>(2, 3), null, null);

        [Test]
        public void TestFailConstructor()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new RectangleRoom(1, 3));
            Assert.Throws<ArgumentOutOfRangeException>(() => new RectangleRoom(3, 1));
            Assert.Throws<ArgumentOutOfRangeException>(() => new RectangleRoom(1, 1));
        }

        [Test]
        public void TestConstructor()
        {
            IRoom room = this.newRoom;
            Assert.IsNotNull(room);
            Assert.AreEqual(3, room.Size.Item1);
            Assert.AreEqual(3, room.Size.Item2);
            Assert.AreEqual(25, room.GetTilesAsEntities.Count);
            Assert.IsFalse(room.Monsters.Any());
            Assert.IsFalse(room.ObjectsInRoom.Any());
            Assert.AreEqual(9, room.GetTilesAsEntities
                                   .Where(tile => tile is FloorTile)
                                   .Count());
        }

        [Test]
        public void TestIsInRoom()
        {
            IRoom room = this.newRoom;
            Assert.IsTrue(room.IsInRoom(new Tuple<int, int>(2, 3)));
            Assert.IsTrue(room.IsInRoom(new Tuple<int, int>(0, 0)));
            Assert.IsFalse(room.IsInRoom(new Tuple<int, int>(5, 3)));
        }

        [Test]
        public void TestAddMonsterEmptySlot()
        {
            IRoom room = this.newRoom;
            IActor mst = this.testActor;
            Assert.IsTrue(room.AddMonster(mst));
            Assert.AreEqual(1, room.Monsters.Count);
        }

        [Test]
        public void TestAddMonsterAlreadyPresent()
        {
            IRoom room = this.newRoom;
            IActor mst = this.testActor;
            room.AddMonster(mst);
            Assert.IsFalse(room.AddMonster(mst));
            Assert.AreEqual(1, room.Monsters.Count);
        }

        [Test]
        public void TestAddMonsterOccupiedByItem()
        {
            IRoom room = this.newRoom;
            IActor mst = this.testActor;
            room.Put(mst.GetPos(), new Door(mst.GetPos()));
            Assert.IsTrue(room.AddMonster(mst));
        }

        [Test]
        public void TestAddMonsterOutsideRoom()
        {
            IRoom room = this.newRoom;
            IActor mst = this.testActor;
            mst.SetPos(new Tuple<int, int>(5, 3));
            Assert.IsFalse(room.AddMonster(mst));
        }

        [Test]
        public void TestAddDoor()
        {
            IRoom room = this.newRoom;
            Assert.IsTrue(room.AddDoor(Direction.Up));
            Assert.IsFalse(room.AddDoor(Direction.Undefined));
        }

        [Test]
        public void TestGetDoorOnSide()
        {
            IRoom room = this.newRoom;
            room.AddDoor(Direction.Up);
            Assert.IsNotNull(room.GetDoorOnSide(Direction.Up));
        }

        [Test]
        public void TestAddConnectedRoom()
        {
            IRoom room = this.newRoom;
            room.AddDoor(Direction.Up);
            room.AddDoor(Direction.Down);
            room.AddDoor(Direction.Left);
            room.AddDoor(Direction.Right);
            room.AddDoor(Direction.Undefined);
            Assert.IsTrue(room.AddConnectedRoom(Direction.Up, this.newRoom));
            Assert.IsTrue(room.AddConnectedRoom(Direction.Down, this.newRoom));
            Assert.IsTrue(room.AddConnectedRoom(Direction.Left, this.newRoom));
            Assert.IsTrue(room.AddConnectedRoom(Direction.Right, this.newRoom));
            Assert.IsFalse(room.AddConnectedRoom(Direction.Undefined, this.newRoom));
        }

        [Test]
        public void TestAddConnectedRoomNoDoor()
        {
            IRoom room = this.newRoom;
            Assert.IsFalse(room.AddConnectedRoom(Direction.Up, this.newRoom));
            Assert.IsFalse(room.AddConnectedRoom(Direction.Down, this.newRoom));
            Assert.IsFalse(room.AddConnectedRoom(Direction.Left, this.newRoom));
            Assert.IsFalse(room.AddConnectedRoom(Direction.Right, this.newRoom));
            Assert.IsFalse(room.AddConnectedRoom(Direction.Undefined, this.newRoom));
        }

        [Test]
        public void TestAddConnectedRoomAlreadyPresent()
        {
            IRoom room = this.newRoom;
            room.AddDoor(Direction.Up);
            Assert.IsTrue(room.AddConnectedRoom(Direction.Up, this.newRoom));
            Assert.IsFalse(room.AddConnectedRoom(Direction.Up, this.newRoom));
        }
    }
}
