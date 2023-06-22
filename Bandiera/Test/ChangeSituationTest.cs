using NUnit.Framework;
using OOP22_rusco_dc_csharp.Pesaresi.Gamecommand;
using OOP22_rusco_dc_csharp.CommonFile.Exceptions;

namespace OOP22_rusco_dc_csharp.Bandiera.Test
{
    [TestFixture]
    public class ChangeFloorTest
    {
        public void Execute_ChangeFloorException()
        {
            ChangeFloor changeFloor = new ChangeFloor();
            Assert.Throws<ChangeFloorException>(() => changeFloor.Execute());
        }
    }

    [TestFixture]
    public class ChangeRoomTest
    {
        public void Execute_ChangeRoomException()
        {
            ChangeRoom changeRoom = new ChangeRoom(new Tuple<int, int>(0, 5));
            Assert.Throws<ChangeRoomException>(() => changeRoom.Execute());
        }
    }
}