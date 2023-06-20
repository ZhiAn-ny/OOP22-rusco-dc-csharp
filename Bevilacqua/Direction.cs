using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP22_rusco_dc_csharp.Bevilacqua
{
    /// <summary>
    /// Defines a set of basic directions that can be used in the game.
    /// </summary>
    public enum Direction
    {
        Up, Down, Left, Right, Undefined
    }

    public static class Directions
    {
        public static Direction GetOpposite(Direction dir)
        {
            switch (dir) 
            {
                case Direction.Up: return Direction.Down;
                case Direction.Down: return Direction.Up;
                case Direction.Left: return Direction.Right;
                case Direction.Right: return Direction.Left;
                default: return Direction.Undefined;
            }
        }
    }
}
