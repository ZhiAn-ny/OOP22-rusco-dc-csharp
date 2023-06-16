/**
 * Implementation of abstract class <code>MoveBuilder</code>, usefull to move up the actor.
 */
public class MoveUpCommand : MoveCommand {

    /**
     * 
     */
    protected Tuple<Int32, Int32> computeNewPos() {
        Tuple<Int32, Int32> newPos = this.getActor();
        return Pairs.computeUpPair(this.getActor().getPos());
    }

}
