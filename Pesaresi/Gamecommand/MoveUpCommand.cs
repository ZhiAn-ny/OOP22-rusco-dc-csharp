using System;
/**
 * Implementation of abstract class <code>MoveBuilder</code>, usefull to move up the actor.
 */
public class MoveUpCommand : MoveCommand {

    /**
     * 
     */
    protected override Tuple<Int32, Int32> ComputeNewPos() 
    {
      Tuple<Int32, Int32> tmp = Tuple.Create(0, 0);
      return tmp;
        //Tuple<Int32, Int32> newPos = this.getActor();
        
        //return Pairs.computeUpPair(this.getActor().getPos());
    }
}
