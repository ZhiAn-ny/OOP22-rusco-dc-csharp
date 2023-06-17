namespace Interactable
{
    public class ChangeRoom : IGameCommand
    {
        //dummy implementation
        private Tuple<Int32, Int32> pos;

        public ChangeRoom(Tuple<Int32, Int32> pos)
        {
            this.pos = pos;
        }

        public void ChangeFloor()
        {
            throw new NotImplementedException();
        }

        void IGameCommand.ChangeRoom()
        {
            throw new NotImplementedException();
        }
    }
}