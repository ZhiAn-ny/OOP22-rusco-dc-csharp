using System;
using System.Collections.Generic;

namespace OOP22_rusco_dc_csharp.Pesaresi.Gamecommand
{

    /**
    * Defines a set of method usefull to manage manually a specific situation
    * With these the player can manage a specific situation.
*/
    public interface IHandlableGameCommand
    {
        /**
        * Modify the internal state of the command, after getting an input.
        * For example, with this method, the player can:
        * <ul>
        * <li>move the cursor</li>
        * <li>abort the command</li>
        * <li>execute the command</li>
        * </ul>
        * 
        * @param input that modify the command
        * @return true if input have effectly change the command state, false otherwise
        */
        bool Modify(GameControl input);

        /**
        * An iterable collection of thing to be printed, updated at the actual moment.
        * @return an Iterator of some {@code}Entity{@code}
        */
        IList<IEntity> GetEntities();

    }
}