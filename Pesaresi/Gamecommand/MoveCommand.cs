using System;

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
            /*
              IRoom where = this.getRoom();
              Tuple<Int32, Int32> newPos = this.computeNewPos();
              if (where.getMonsters().stream().map(a -> a.getPos()).anyMatch(p -> p.equals(newPos)) 
                  || !where.isAccessible(newPos)) {
                  return; // Optional.of(new InfoPayloadImpl(getErrTitle(), ERR));
                  //throw new UnreacheblePos(err);
              }

              IActor actActor = this.getActor();
            */
            //actActor.setPos(newPos); //TODO

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