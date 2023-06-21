using Interactable;
using NUnit.Framework;
using OOP22_rusco_dc_csharp.Bevilacqua;

namespace OOP22_rusco_dc_csharp.Bandiera.Test
{
    [TestFixture]
    public class InteractableTest
    {
        [Test]
        public void IsTransitableDoor()
        {
            IInteractable door = new Door(new Tuple<int, int>(0, 5), Direction.Up);
            Assert.IsTrue(door.IsTransitable());
        }

        [Test]
        public void IsTransitableStair()
        {
            IInteractable stair = new Stair(new Tuple<int, int>(0, 2));
            Assert.IsTrue(stair.IsTransitable());
        }
    }
}