using System;
using System.Collections.Generic;
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
    public override bool IsReady() => true;

    /**
     * 
     */
    public override bool Modify(GameControl input) {
        throw new NotSupportedException(this.getGlobalErrMess());
    }

    /**
     * 
     */
    public override IList<IEntity> GetEntities() {
        throw new NotSupportedException(this.getGlobalErrMess());
    }

    /**
     * 
     */
    public override bool IsTargetInRange(IActor target) {
        throw new NotSupportedException(this.getGlobalErrMess());
    }

    /**
     * 
     */
    public override int GetAPCost() {
        throw new NotSupportedException(this.getGlobalErrMess());
    }

    /**
     * 
     */
    public override void SetCursorPos(Tuple<Int32, Int32> toFocus) {
        throw new NotSupportedException(this.getGlobalErrMess());
    }

    /**
     * 
     */
    public override void SetTarget(IList<IActor> targettableActors) {
        throw new NotSupportedException(this.getGlobalErrMess());
    }

}
