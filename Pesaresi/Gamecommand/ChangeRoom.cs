using System.Diagnostics.CodeAnalysis;
using OOP22_rusco_dc_csharp.CommonFile.Exceptions;

namespace OOP22_rusco_dc_csharp.Pesaresi.Gamecommand
{
    public class ChangeRoom : QuickActionAbs
    {
        private readonly Tuple<int, int> _door;

        public Tuple<int, int> Door {get;}

        public ChangeRoom([NotNull] Tuple<int, int> doorPos)
        {
            _door = doorPos;
        }

        public override void Execute()
        {
            throw new ChangeRoomException(_door);
        }
    }
}