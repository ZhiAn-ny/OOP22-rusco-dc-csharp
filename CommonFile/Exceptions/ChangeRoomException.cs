namespace OOP22_rusco_dc_csharp.CommonFile.Exceptions
{
    public class ChangeRoomException : ModelException
    {
        private readonly Tuple<Int32, Int32> _doorPos;
        public ChangeRoomException(Tuple<Int32, Int32> doorPos)
        {
            _doorPos = doorPos;
        }

        public Tuple<Int32, Int32> Door => _doorPos;
    }
}