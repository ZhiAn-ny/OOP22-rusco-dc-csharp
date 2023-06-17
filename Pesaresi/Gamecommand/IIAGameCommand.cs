using System;
using System.Collections.Generic;

    /**
    * Defines a set of method usefull to manage automatically a specific situation.
    * With these the game can manage mobs
    */
    public interface IIAGameCommand
    {
        /**
        * Focus the attack to a specific actor.
        * @param toFocus where the attack start
        */
        void SetCursorPos(Tuple<Int32, Int32> toFocus);

        /**
        * Specifies possible actors that can be afflicted by the attack.
        * @param targettableActors the list of actor as described before
        */
        void SetTarget(IList<IActor> targettableActors);

        /**
        * Check if an actor is targetable.
        * @param target who desire to attack
        * @return if it is possible
        */
        bool IsTargetInRange(IActor target);

        /**
        * Get the cost of this action.
        * @return the AP cost
        */
        int GetAPCost();
    }