using NUnit.Framework;

using OOP22_rusco_dc_csharp.Bevilacqua.gamemap;
using OOP22_rusco_dc_csharp.CommonFile;
using OOP22_rusco_dc_csharp.Marcaccio.actors;
using OOP22_rusco_dc_csharp.Marcaccio.actors.hero;
using OOP22_rusco_dc_csharp.Pesaresi.Gamecommand;

namespace OOP22_rusco_dc_csharp.Pesaresi.Test
{
    [TestFixture]
    public class MovementTest
    {
        private readonly int size = 21;
        Tuple<int, int> actHeroPos;
        private void SetCommand(IGameCommand gamecommand, IActor who, IRoom where)
        {
            gamecommand.SetActor(who);
            gamecommand.SetRoom(where);
        }

        [SetUp]
        private void start()
        {
            actHeroPos = new(size / 2, size / 2);
        }

        private void CheckMov(
            IGameCommand movementToTest,
            Tuple<int, int> actHeroPos,
            Tuple<int, int> resultPos)
        {
            IActor hero = new Hero("test", actHeroPos, null, null);
            IRoom room = new RectangleRoom(size, size);
            SetCommand(movementToTest, hero, room);

            Assert.AreEqual(hero.GetPos(), actHeroPos);
            Assert.AreNotEqual(hero.GetPos(), resultPos);

            Assert.IsTrue(movementToTest.IsReady());
            Assert.DoesNotThrow(() => { movementToTest.Execute(); });

            Assert.AreEqual(hero.GetPos(), resultPos);
            Assert.AreNotEqual(hero.GetPos(), actHeroPos);
            //assertEquals(resultPos, hero.getPos(), "ERR: wrong movement!");
        }

        /**
        * Test moving up.
        * Credit: Pesaresi Jacopo.
        */
        [Test]
        void CheckMoveUp()
        {
            CheckMov(new MoveUpCommand(), actHeroPos, MovementCalc.ComputeUpPos(actHeroPos));
        }

        /**
        * Test moving down.
        * Credit: Pesaresi Jacopo.
        */
        [Test]
        void CheckMoveDown()
        {
            CheckMov(new MoveDownCommand(), actHeroPos, MovementCalc.ComputeDownPos(actHeroPos));
        }

        /**
        * Test moving left.
        * Credit: Pesaresi Jacopo.
        */
        [Test]
        void CheckMovLeft()
        {
            CheckMov(new MoveLeftCommand(), actHeroPos, MovementCalc.ComputeLeftPos(actHeroPos));
        }

        /**
        * Test moving right.
        * Credit: Pesaresi Jacopo.
        */
        [Test]
        void CheckMoveRight()
        {
            CheckMov(new MoveRightCommand(), actHeroPos, MovementCalc.ComputeRightPos(actHeroPos));
        }

    }
}