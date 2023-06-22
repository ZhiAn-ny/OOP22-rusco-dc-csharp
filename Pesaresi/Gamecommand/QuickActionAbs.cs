using System;
using System.Collections.Generic;
using OOP22_rusco_dc_csharp.CommonFile.GameControl;
using OOP22_rusco_dc_csharp.Marcaccio;
using OOP22_rusco_dc_csharp.Marcaccio.actors;

namespace OOP22_rusco_dc_csharp.Pesaresi.Gamecommand
{
    /**
   * This abstract class defines that all the other class that extend this class will wrap an
   * action that tipically can execute without any type of other controls (neither by player or IA).
   * So logically the wrapped command can be executed
   */
    public abstract class QuickActionAbs : BasicGameCommand
    {

        /**
         * Client must not create this object directily.
         */
        protected QuickActionAbs()
        {
        }

        /**
         * 
         */
        public override bool IsReady() => true;

        /**
         * 
         */
        public override bool Modify(GameControl input)
        {
            throw new NotSupportedException(GetGlobalErrMess());
        }

        /**
         * 
         */
        public override IList<IEntity> GetEntities()
        {
            throw new NotSupportedException(GetGlobalErrMess());
        }

        /**
         * 
         */
        public override bool IsTargetInRange(IActor target)
        {
            throw new NotSupportedException(GetGlobalErrMess());
        }

        /**
         * 
         */
        public override int GetAPCost()
        {
            throw new NotSupportedException(GetGlobalErrMess());
        }

        /**
         * 
         */
        public override void SetCursorPos(Tuple<int, int> toFocus)
        {
            throw new NotSupportedException(GetGlobalErrMess());
        }

        /**
         * 
         */
        public override void SetTarget(IList<IActor> targettableActors)
        {
            throw new NotSupportedException(GetGlobalErrMess());
        }

    }
}