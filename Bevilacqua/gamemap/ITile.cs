using Interactable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP22_rusco_dc_csharp.Bevilacqua.gamemap
{
    public interface ITile
    {
        /// <summary>
        /// Places an interabtable object on the tile.
        /// </summary>
        /// <param name="obj">The object to place on the tile</param>
        /// <returns>True if the object was placed successfully, 
        /// False otherwise</returns>
        bool Put(IInteractable obj);

        /// <summary>
        /// Returns the interactable object placed on the tile.
        /// </summary>
        /// <returns>the object on the tile</returns>
        IInteractable Get();

        /// <summary>
        /// Empties the tile.
        /// </summary>
        /// <returns>the object placed on the tile, if any</returns>
        IInteractable Empty();

    }
}
