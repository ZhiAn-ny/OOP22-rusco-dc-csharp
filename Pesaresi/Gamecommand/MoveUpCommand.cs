using System;
using OOP22_rusco_dc_csharp.CommonFile;

namespace OOP22_rusco_dc_csharp.Pesaresi.Gamecommand
{
    /**
    * Implementation of abstract class <code>MoveBuilder</code>, usefull to move up the actor.
    */
    public class MoveUpCommand : MoveCommand
    {

        /**
         * 
         */
        protected override Tuple<Int32, Int32> ComputeNewPos()
        {
            return MovementCalc.ComputeUpPos(this.GetActor().GetPos());
        }
    }
}