using OOP22_rusco_dc_csharp.Marcaccio.actors;
﻿using Interactable;
using System.Collections.Immutable;
using IEntity = OOP22_rusco_dc_csharp.Marcaccio.IEntity;


namespace OOP22_rusco_dc_csharp.Bevilacqua.GameMap
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
        ImmutableList<IEntity> GetTilesAsEntities { get; }

        /// <summary>
        /// The list of monsters in the room.
        /// </summary>
        ImmutableList<IActor> Monsters { get; }

        /// <summary>
        /// The list of objects in the room.
        /// </summary>
        ImmutableList<IInteractable> ObjectsInRoom{ get; }

        /// <summary>
        /// Returns the rooms connected to the current one and the side on which
        /// they communicate between each other.
        /// </summary>
        /// <returns>a Dictionary specifying the Direction on which the room's
        /// doors are placed and, the connected room if any</returns>
        Dictionary<Direction, IRoom?> ConnectedRooms { get; }

        /// <summary>
        /// Returns the internal area of the room.
        /// </summary>
        /// <returns>the internal area of the room</returns>
        int GetArea();

        /// <summary>
        /// Returns the tile at the specified position.
        /// </summary>
        /// <param name="pos">The position to check</param>
        /// <returns>The tile at the specified position, if any</returns>
        ITile? Get(Tuple<int, int> pos);

        /// <summary>
        /// Place an object in the specified position.
        /// </summary>
        /// <param name="pos">the position at which place the object</param>
        /// <param name="obj">the object to place</param>
        /// <returns>True if the object was successfully placed,
        /// False otherwise</returns>
        bool Put(Tuple<int, int> pos, IInteractable obj);

        /// <summary>
        /// Returns whether the specified position is accessible to an actor.
        /// </summary>
        /// <param name="pos">the position in which move the actor</param>
        /// <returns>True if the tile at the specified position is accessible,
        /// False otherwise</returns>
        bool IsAccessible(Tuple<int, int> pos);

        /// <summary>
        /// Checks whether a specified position is part of the room.
        /// </summary>
        /// <param name="pos">the position check</param>
        /// <returns>True if the position is part of the room, False otherwise</returns>
        bool IsInRoom(Tuple<int, int> pos);

        /// <summary>
        /// Replaces the Tile at the specified position with a new one.
        /// </summary>
        /// <param name="pos">the position of the Tile to replace</param>
        /// <param name="newTile">the new Tile</param>
        /// <returns>True if the Tile has been successfully replaced,
        /// false otherwise.</returns>
        bool ReplaceTile(Tuple<int, int> pos, ITile newTile);

        /// <summary>
        /// Clears the area centered in the specified position.
        /// </summary>
        /// <param name="pos">the center of the area</param>
        /// <param name="rad">the radius of the area</param>
        void ClearArea(Tuple<int, int> pos, int rad);

        /// <summary>
        /// Adds a monster to the room.
        /// </summary>
        /// <param name="monster">the monster to add</param>
        /// <returns>True if the monster has been added, False otherwise.</returns>
        bool AddMonster(IActor monster);

        /// <summary>
        /// Eliminates a monster and removes it from the map.
        /// </summary>
        /// <param name="monster">the monster to eliminate</param>
        void EliminateMonster(IActor monster);

        /// <summary>
        /// Adds a door on the side facing the specified direction.
        /// </summary>
        /// <param name="dir">the side of the room on which place the door</param>
        /// <returns>True, if the door was placed correctly, False otherwise</returns>
        bool AddDoor(Direction dir);
        
        /// <summary>
        /// Adds stairs on the side facing the specified direction.
        /// </summary>
        /// <param name="dir">the side of the room on which place the stairs</param>
        /// <returns>True, if the stairs were placed correctly, False otherwise</returns>
        bool AddStair(Direction dir);

        /// <summary>
        /// Connects a room to the current one.
        /// </summary>
        /// <param name="dir">the direction on which the two rooms
        /// will be communicating</param>
        /// <param name="other">the room to connect</param>
        /// <returns>True if the rooms have been correctly connected,
        /// False otherwise</returns>
        bool AddConnectedRoom(Direction dir, IRoom other);

        /// <summary>
        /// Returns the room connected to the current one on the specified side.
        /// </summary>
        /// <param name="dir">the side of the room on which stands the passage
        /// to the other room</param>
        /// <returns>a nullable object representing the connected room</returns>
        IRoom? GetConnectedRoom(Direction dir);

        /// <summary>
        /// Returns the door on the specified side of the room if any.
        /// </summary>
        /// <param name="dir">the side of the room on which search the door</param>
        /// <returns>a nullable object representing the door</returns>
        IInteractable? GetDoorOnSide(Direction dir);
    }
}
