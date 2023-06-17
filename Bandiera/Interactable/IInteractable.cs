namespace Interactable
{
    /// <summary>
    /// This class represent the Interactable object.
    /// </summary>
    public interface IInteractable : IEntity
    {
        /// <summary>
        /// This method return the name of the Interactable entity.
        /// </summary>
        /// <returns>the name of the interactable thing.</returns>
        string GetName();
        /// <summary>
        /// This method is used to interact with the Interactable entity.
        /// </summary>
        /// <returns>the command wrapped into Interactable entity.</returns>
        IGameCommand Interact();
        /// <summary>
        /// Specific if this interactable could be transitable.
        /// </summary>
        /// <returns>true if actors can pass over, false otherwise</returns>
        bool isTransitable();
    }
    
}

