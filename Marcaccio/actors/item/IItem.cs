namespace OOP22_rusco_dc_csharp.Marcaccio.actors.item
{
    /**
           * Interface for the Items of the game.
           */
    public interface IItem
    {
        /**
         * Gets the name of the item.
         *
         * @return the name of the item
         */
        string GetName();

        /**
         * Gets the path to info related to the item.
         *
         * @return the path to info related to the item
         */
        string GetPath();

        /**
         * Checks if the item is wearable.
         *
         * @return true if the item is wearable, false otherwise
         */
        bool IsWearable();
    }
}