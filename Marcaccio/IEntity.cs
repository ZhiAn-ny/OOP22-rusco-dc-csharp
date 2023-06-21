namespace OOP22_rusco_dc_csharp.Marcaccio
{
    public interface IEntity
    {
        int GetID();
        string GetPath();
        Tuple<int, int> GetPos();
    }
}