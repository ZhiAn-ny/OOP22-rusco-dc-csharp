using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP22_rusco_dc_csharp.Bevilacqua.gamemap
{
    internal interface IRoom
    {
        /// <summary>
        /// Returns the internal area of the room.
        /// </summary>
        /// <returns>the internal area of the room</returns>
        int getArea();

        /// <summary>
        /// Returns the rooms connected to the current one and the side on which
        /// they communicate between each other.
        /// </summary>
        /// <returns>a Dictionary specifying the Direction on which the room's
        /// doors are placed and, the connected room if any</returns>
        Dictionary<Direction, IRoom> getConnectedRooms();

    }
}
