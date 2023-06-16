namespace Marcaccio
{
    public interface IGameCommand
    {
        int GetID();
        string GetPath();
        Tuple<int, int> GetPos();
    }
}