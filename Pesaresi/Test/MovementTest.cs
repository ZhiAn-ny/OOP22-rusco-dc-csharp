
using NUnit.Framework;

using OOP22_rusco_dc_csharp.Bevilacqua.gamemap;
using OOP22_rusco_dc_csharp.CommonFile;
using OOP22_rusco_dc_csharp.Marcaccio.actors;
using OOP22_rusco_dc_csharp.Pesaresi.Gamecommand;

namespace OOP22_rusco_dc_csharp.Pesaresi.Test
{
    [TestFixture]
    public class MovementTest
    {
        private void SetCommand(IGameCommand gamecommand, IActor who, IRoom where)
        {
            gamecommand.SetActor(who);
            gamecommand.SetRoom(where);
        }

        [Test]
        public void TestMoveUp()
        {
            int size = 20;
            Tuple<int, int> actHeroPos = new(size/2, size/2);
            IActor hero; //= new Hero("");
            IRoom room; //= new Room(hero);
            MoveUpCommand moveUp = new();
            //SetCommand(moveUp, hero, room);
            Tuple<int,int> newHeroPos = MovementCalc.ComputeUpPos(actHeroPos);
            Assert.IsTrue(moveUp.IsReady());
            Assert.DoesNotThrow(() => { moveUp.Execute(); });
            //Assert.AreEqual(hero.GetPos(), newHeroPos);
        }

    }

}