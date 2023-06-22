using System.Collections.Generic;

namespace OOP22_rusco_dc_csharp.CommonFile.GameControl
{
    /// <summary>
    /// Enum that contains the actions that the player can do.
    /// </summary>
    public enum GameControl
    {
        /// <summary>
        /// Down direction.
        /// </summary>
        MOVEDOWN,
        /// <summary>
        /// Up direction.
        /// </summary>
        MOVEUP,
        /// <summary>
        /// Left direction.
        /// </summary>
        MOVELEFT,
        /// <summary>
        /// Right direction.
        /// </summary>
        MOVERIGHT,
        /// <summary>
        /// Inventory with the objects of user.
        /// </summary>
        INVENTORY,
        /// <summary>
        /// Pause game.
        /// </summary>
        PAUSE,
        /// <summary>
        /// Cancel the choose of user.
        /// </summary>
        CANCEL,
        /// <summary>
        /// Confirm the choose of user.
        /// </summary>
        CONFIRM,
        /// <summary>
        /// Interact with the object.
        /// </summary>
        INTERACT,
        /// <summary>
        /// Base attack.
        /// </summary>
        BASEATTACK,
        /// <summary>
        /// Special attack 1.
        /// </summary>
        ATTACK1,
        /// <summary>
        /// Special attack 2.
        /// </summary>
        ATTACK2,
        /// <summary>
        /// Special attack 3.
        /// </summary>
        ATTACK3,
        /// <summary>
        /// Special attack 4.
        /// </summary>
        ATTACK4,
        /// <summary>
        /// Generic command for deleting something.
        /// </summary>
        DELETE,
        /// <summary>
        /// Do nothing.
        /// </summary>
        DONOTHING
    
    }


    public static class GameControlExstension
    {
        /// <summary>
        /// Computes a list of GameControl typically associated with attack commands.
        /// </summary>
        /// <returns>the list of GameControl</returns>
        public static List<GameControl> GetAttackControls()
        {
            return new List<GameControl>()
            {
                GameControl.BASEATTACK,
                GameControl.ATTACK1,
                GameControl.ATTACK2,
                GameControl.ATTACK3,
                GameControl.ATTACK4
            };
        }
    }
}