using Interactable;
using Marcaccio.actors;
using OOP22_rusco_dc_csharp.Marcaccio.actors;


namespace OOP22_rusco_dc_csharp.Bevilacqua.gamemap
{
    public interface ITile
    {
        /// <summary>
        /// The position in which the tile was placed.
        /// </summary>
        Tuple<int, int> Position { get; }

        /// <summary>
        /// Whether an actor can access the tile or not.
        /// </summary>
        bool IsAccessible { get; }

        /// <summary>
        /// Places an interabtable object on the tile.
        /// </summary>
        /// <param name="obj">The object to place on the tile</param>
        /// <returns>True if the object was placed successfully, 
        /// False otherwise</returns>
        bool Put(IInteractable obj);

        /// <summary>
        /// Returns the interactable object placed on the tile.
        /// </summary>
        /// <returns>a nullable of the object on the tile</returns>
        IInteractable? Get();

        /// <summary>
        /// Empties the tile.
        /// </summary>
        /// <returns>a nullable of the object placed on the tile, if any</returns>
        IInteractable? Empty();

        /// <summary>
        /// Returns the effect produced on an actor when stepping on the tile.
        /// </summary>
        /// <returns>the action execute on the actor when stepping on
        /// the tile</returns>
        Action<IActor> GetEffect();


    }
}
