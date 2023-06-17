using Interactable;

namespace Interactable
{
    /// <summary>
    /// This class represent the Stair of the room.
    /// It is used to move from one floor to another.
    /// </summary>
    public class Stair : AbsInteractable
    {
        private readonly string name;

        /// <summary>
        /// The constructor of the Stair class.
        /// </summary>
        /// <param name="pos">where spawn the stair.</param>
        public Stair(Tuple<Int32, Int32> pos) : base(pos)
        {
            this.name = "Stair";
        }

        /// <inheritdoc/>
        public override string GetName()
        {
            return this.name;
        }

        /// <inheritdoc/>
        public override IGameCommand Interact()
        {
            return new ChangeFloor();
        }

        /// <inheritdoc/>
        public override bool isTransitable()
        {
            return true;
        }
    }
}
