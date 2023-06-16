/**
 * This abstract class defines that all the other class that extend this class will wrap an
 * action that tipically can execute without any type of other controls (neither by player or IA).
 * So logically the wrapped command can be executed
 */
public abstract class QuickActionAbs : BasicGameCommand  {

    /**
     * Client must not create this object directily.
     */
    protected QuickActionAbs() {
    }

    /**
     * 
     */
    public bool isReady() => true;

    /**
     * 
     */
    public bool modify(GameControl input) {
        throw new NotSupportedException(this.getGlobalErrMess());
    }

    /**
     * 
     */
    public List<IEntity> getEntities() {
        throw new NotSupportedException(this.getGlobalErrMess());
    }

    /**
     * 
     */
    public bool isTargetInRange(IActor target) {
        throw new NotSupportedException(this.getGlobalErrMess());
    }

    /**
     * 
     */
    public int getAPCost() {
        throw new NotSupportedException(this.getGlobalErrMess());
    }

    /**
     * 
     */
    public void setCursorPos(Tuple<Int32, Int32> toFocus) {
        throw new NotSupportedException(this.getGlobalErrMess());
    }

    /**
     * 
     */
    public void setTarget(List<IActor> targettableActors) {
        throw new NotSupportedException(this.getGlobalErrMess());
    }

}
