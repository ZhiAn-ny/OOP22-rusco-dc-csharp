using OOP22_rusco_dc_csharp.Bevilacqua;
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
        private readonly Direction _direction;

        /// <summary>
        /// The constructor of the Door class.
        /// </summary>
        /// <param name="pos">where spawn the door.</param>
        public Door(Tuple<Int32, Int32> pos, Direction direction) : base(pos)
        {
            _name = "Door";
            _direction = direction;
        }

        public Direction Direction => _direction;


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

