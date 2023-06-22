using NUnit.Framework;
using OOP22_rusco_dc_csharp.Pesaresi.Gamecommand;
using IGameCommand = OOP22_rusco_dc_csharp.Pesaresi.Gamecommand.IGameCommand;

namespace OOP22_rusco_dc_csharp.Pesaresi.Test
{
    public class CommandDesingTest
    {
        [Test]
        public void QuickIsNotHandlable()
        {
            IGameCommand gc = new MoveUpCommand();
            Assert.Throws<NotSupportedException>(() => gc.Modify(GameControl.MOVE), "ERR");
        }

    }
}