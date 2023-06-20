using System;
using System.Collections.Generic;
using OOP22_rusco_dc_csharp.Marcaccio.actors;

namespace OOP22_rusco_dc_csharp.Pesaresi.Gamecommand
{

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
        void SetCursorPos(Tuple<int, int> toFocus);

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
}