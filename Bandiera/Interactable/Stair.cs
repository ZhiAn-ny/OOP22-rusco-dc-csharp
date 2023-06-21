using OOP22_rusco_dc_csharp.Pesaresi.Gamecommand;

namespace Interactable
{
    /// <summary>
    /// This class represent the Stair of the room.
    /// It is used to move from one floor to another.
    /// </summary>
    public class Stair : AbsInteractable
    {
        private readonly string _name;
        private readonly string _path;

        /// <summary>
        /// The constructor of the Stair class.
        /// </summary>
        /// <param name="pos">where spawn the stair.</param>
        public Stair(Tuple<Int32, Int32> pos) : base(pos)
        {
            _name = "Stair";
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
            return new ChangeFloor();
        }

        /// <inheritdoc/>
        public override bool IsTransitable()
        {
            return true;
        }
    }
}
