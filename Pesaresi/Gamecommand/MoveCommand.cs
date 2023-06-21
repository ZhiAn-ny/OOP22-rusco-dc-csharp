using OOP22_rusco_dc_csharp.Bevilacqua.gamemap;
using OOP22_rusco_dc_csharp.Marcaccio.actors;
using OOP22_rusco_dc_csharp.CommonFile.Exceptions;

namespace OOP22_rusco_dc_csharp.Pesaresi.Gamecommand
{
    /**
    * Class that check the movement of a specific Actor in a specific Room.
    * Classes that extends this class must only define what will be the new position of the Actor
    */
    public abstract class MoveCommand : QuickActionAbs
    {

        private static readonly String ERR = "The position is already occupied or is out of the room";

        /**
         * Client must not create directly this object.
         */
        protected MoveCommand()
        {
        }

        /**
         * 
         */
        public override void Execute()
        {
            IRoom where = Where;
            Tuple<int, int> newPos = this.ComputeNewPos();
            if (where.Monsters.Any(a => a.GetPos().Equals(newPos))
                //  || !where.isAccessible(newPos)
                )
            {
                throw new ModelException();
            }

            IActor actActor = ActActor;
            
            actActor.SetPos(newPos); 
            // Tile? arrivedPos = where.get(newPos);
            // if (arrivedPos.isPresent()) {
            //     final SingleTargetEffect tmp = arrivedPos.get().getEffect();
            //     tmp.applyEffect(actActor);
            // }

            // Interactable? possibleInnerInteraction = arrivedPos.get().get();
            // if (possibleInnerInteraction.isPresent()) {
            //     GameCommand gc = possibleInnerInteraction.get().interact();
            //     gc.setActor(actActor);
            //     gc.setRoom(where);
            //     return gc.execute();
            // }

            return;
        }

        /**
         * Compute the new position.
         * This work must be defined in other dedicated classes.
         * @return the new position, to be checked
         */
        protected abstract Tuple<Int32, Int32> ComputeNewPos();

    }
}