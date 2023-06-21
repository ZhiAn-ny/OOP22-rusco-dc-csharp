using System;
using OOP22_rusco_dc_csharp.CommonFile;

namespace OOP22_rusco_dc_csharp.Pesaresi.Gamecommand
{
    /**
    * Implementation of abstract class <code>MoveBuilder</code>, usefull to move up the actor.
    */
    public class MoveDownCommand : MoveCommand
    {
        /**
         * 
         */
        protected override Tuple<int, int> ComputeNewPos()
        {
            return MovementCalc.ComputeDownPos(ActActor.GetPos());
        }
    }
}