using NUnit.Framework;

using OOP22_rusco_dc_csharp.Bevilacqua.GameMap;
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
        private Tuple<int, int> _actHeroPos;
        private void SetCommand(IGameCommand gamecommand, IActor who, IRoom where)
        {
            gamecommand.SetActor(who);
            gamecommand.SetRoom(where);
        }

        [SetUp]
        public void Start()
        {
            _actHeroPos = new(size / 2, size / 2);
        }

        private void CheckMov(
            IGameCommand movementToTest,
            Tuple<int, int> actHeroPos,
            Tuple<int, int> resultPos)
        {
            IActor hero = new Hero("test", actHeroPos, null, null);
            IRoom room = new RectangleRoom(size, size);
            SetCommand(movementToTest, hero, room);
            Assert.Multiple(() =>
            {
                Assert.That(actHeroPos, Is.EqualTo(hero.GetPos()));
                Assert.That(resultPos, Is.Not.EqualTo(hero.GetPos()));

                Assert.That(movementToTest.IsReady(), Is.True);
                Assert.DoesNotThrow(() => { movementToTest.Execute(); });

                Assert.That(resultPos, Is.EqualTo(hero.GetPos()));
                Assert.That(actHeroPos, Is.Not.EqualTo(hero.GetPos()));
            });
        }

        /**
        * Test moving up.
        * Credit: Pesaresi Jacopo.
        */
        [Test]
        public void CheckMoveUp()
        {
            CheckMov(new MoveUpCommand(), _actHeroPos, MovementCalc.ComputeUpPos(_actHeroPos));
        }

        /**
        * Test moving down.
        * Credit: Pesaresi Jacopo.
        */
        [Test]
        public void CheckMoveDown()
        {
            CheckMov(new MoveDownCommand(), _actHeroPos, MovementCalc.ComputeDownPos(_actHeroPos));
        }

        /**
        * Test moving left.
        * Credit: Pesaresi Jacopo.
        */
        [Test]
        public void CheckMovLeft()
        {
            CheckMov(new MoveLeftCommand(), _actHeroPos, MovementCalc.ComputeLeftPos(_actHeroPos));
        }

        /**
        * Test moving right.
        * Credit: Pesaresi Jacopo.
        */
        [Test]
        public void CheckMoveRight()
        {
            CheckMov(new MoveRightCommand(), _actHeroPos, MovementCalc.ComputeRightPos(_actHeroPos));
        }

    }
}