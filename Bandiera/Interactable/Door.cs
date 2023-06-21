using OOP22_rusco_dc_csharp.Pesaresi.Gamecommand;


namespace Interactable
{
    /// <summary>
    /// This class represent the Door of the room.
    /// It is used to move from one room to another.
    /// </summary>
    public class Door : AbsInteractable
    {
        private readonly string _name;
        private readonly string _path;

        /// <summary>
        /// The constructor of the Door class.
        /// </summary>
        /// <param name="pos">where spawn the door.</param>
        public Door(Tuple<Int32, Int32> pos) : base(pos)
        {
            _name = "Door";
        }

        /// <inheritdoc/>
        public override string GetName()
        {
            return _name;
        }

        public override string GetPath() => _path;

        /// <inheritdoc/>
        public override IGameCommand Interact()
        {
            return new ChangeRoom(GetPos());
        }
        /// <inheritdoc/>
        public override bool IsTransitable()
        {
            return true;
        }
    }
}

