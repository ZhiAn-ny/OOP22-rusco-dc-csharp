using OOP22_rusco_dc_csharp.CommonFile.Exceptions;

namespace OOP22_rusco_dc_csharp.Pesaresi.Gamecommand
{
    public class ChangeFloor : QuickActionAbs
    {
        public override void Execute()
        {
            //throw new ChangeFloorException("");
            throw new ChangeFloorException();
        }
    }
}