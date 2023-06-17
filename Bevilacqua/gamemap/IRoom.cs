using Marcaccio.actors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP22_rusco_dc_csharp.Bevilacqua.gamemap
{
    public interface IRoom
    {
        /// <summary>
        /// Represent the internal size of the room.
        /// </summary>
        Tuple<int, int> Size { get; }

        /// <summary>
        /// The tiles that compose the room.
        /// </summary>
        List<ITile> Tiles { get; }

        /// <summary>
        /// The list of monsters in the room.
        /// </summary>
        List<IActor> Monsters { get; }

        /// <summary>
        /// Returns the rooms connected to the current one and the side on which
        /// they communicate between each other.
        /// </summary>
        /// <returns>a Dictionary specifying the Direction on which the room's
        /// doors are placed and, the connected room if any</returns>
        Dictionary<Direction, IRoom> ConnectedRooms { get; }

        /// <summary>
        /// Returns the internal area of the room.
        /// </summary>
        /// <returns>the internal area of the room</returns>
        int GetArea();

    }
}
