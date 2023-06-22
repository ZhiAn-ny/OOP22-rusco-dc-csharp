using NUnit.Framework;
using static OOP22_rusco_dc_csharp.CommonFile.GameControl.GameControl;
using OOP22_rusco_dc_csharp.Pesaresi.Gamecommand;

namespace OOP22_rusco_dc_csharp.Pesaresi.Test
{
    public class CommandDesingTest
    {
        [Test]
        public void QuickIsNotHandlable()
        {
            IGameCommand gc = new MoveUpCommand();
            Assert.Throws<NotSupportedException>(() => gc.Modify(MOVEUP), "ERR");
        }

    }
    
}