namespace Interactable
{
    public class ChangeFloor : IGameCommand
    {
        //dummy implementation
        public void ChangeRoom()
        {
            throw new NotImplementedException();
        }

        void IGameCommand.ChangeFloor()
        {
            throw new NotImplementedException();
        }
    }
}