namespace Marcaccio
{
    public interface IEntity
    {
        int GetID();
        string GetPath();
        Tuple<int, int> GetPos();
    }
}