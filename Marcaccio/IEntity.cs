namespace OOP22_rusco_dc_csharp.Marcaccio
{
    /**
    * Interface common for all object that must follow and stay on an orthogonal dominion.
    */
    public interface IEntity
    {
        /**
        * @return a string used as ID for the entity
        */
        int GetID();
        
        /**
        * @return the Path to the directory where you can find the associated files
        */
        string GetPath();
        
        /**
        * @return the current position of the entity
        */
        Tuple<int, int> GetPos();
    }
}