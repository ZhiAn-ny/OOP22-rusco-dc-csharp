namespace Interactable
{
    /// <summary>
    /// Abstract class that represent the Interactable object.
    /// </summary>
    public abstract class AbsInteractable : IInteractable
    {
        private readonly Tuple<Int32, Int32> pos;
        private static readonly int id = 2;

        /// <summary>
        /// Constructor of the abstract class.
        /// </summary>
        /// <param name="pos"></param>
        protected AbsInteractable(Tuple<Int32, Int32> pos)
        {
            this.pos = pos;
        }

        /// <inheritdoc/>
        public Tuple<Int32, Int32> GetPos()
        {
            return this.pos;
        }

        /// <inheritdoc/>
        public int GetID() => 2;

        /// <inheritdoc/>
        public abstract string GetName();

        /// <inheritdoc/>
        public abstract IGameCommand Interact();

        /// <inheritdoc/>
        public abstract bool isTransitable();

    }

}
