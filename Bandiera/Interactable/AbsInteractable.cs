using OOP22_rusco_dc_csharp.Pesaresi.Gamecommand;

namespace Interactable
{
    /// <summary>
    /// Abstract class that represent the Interactable object.
    /// </summary>
    public abstract class AbsInteractable : IInteractable
    {
        private readonly Tuple<Int32, Int32> _pos;
        private static readonly int _id = 2;

        /// <summary>
        /// Constructor of the abstract class.
        /// </summary>
        /// <param name="pos"></param>
        protected AbsInteractable(Tuple<Int32, Int32> pos)
        {
            _pos = pos;
        }

        /// <inheritdoc/>
        public Tuple<Int32, Int32> GetPos()
        {
            return _pos;
        }

        /// <inheritdoc/>
        public int GetID() => 2;

        /// <inheritdoc/>
        public abstract string GetName();

        /// <inheritdoc/>
        public abstract IGameCommand Interact();

        /// <inheritdoc/>
        public abstract bool IsTransitable();

        public abstract string GetPath();
    }

}
