namespace Interactable
{
    /// <summary>
    /// This class represent the Door of the room.
    /// It is used to move from one room to another.
    /// </summary>
    public class Door : AbsInteractable
    {
        private readonly string name;

        /// <summary>
        /// The constructor of the Door class.
        /// </summary>
        /// <param name="pos">where spawn the door.</param>
        public Door(Tuple<Int32, Int32> pos) : base(pos)
        {
            this.name = "Door";
        }

        /// <inheritdoc/>
        public override string GetName()
        {
            return this.name;
        }
        /// <inheritdoc/>
        public override IGameCommand Interact()
        {
            return new ChangeRoom(GetPos());
        }
        /// <inheritdoc/>
        public override bool isTransitable()
        {
            return true;
        }
    }
}

