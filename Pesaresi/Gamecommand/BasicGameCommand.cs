using System;
using System.Collections.Generic;
using OOP22_rusco_dc_csharp.Bevilacqua.GameMap;
using OOP22_rusco_dc_csharp.CommonFile.GameControl;
using OOP22_rusco_dc_csharp.Marcaccio;
using OOP22_rusco_dc_csharp.Marcaccio.actors;

namespace OOP22_rusco_dc_csharp.Pesaresi.Gamecommand
{
    /**
   * Initial implementation of GameCommand.
   * Generally each type of command must know at least two information:
   * <ul>
   * <li> who launch the command </li>
   * <li> where the command was launched </li>
   * </ul>
   * 
   * but these two information are unkonwed when the command-object is created.
   * So, to avoid DRY, i'll provide an basic implementation for all game command:
   * a class that implement two setter, that set these two informations
   */
    public abstract class BasicGameCommand : IGameCommand
    {
        private static readonly String GLOBAL_ERR_MESS = "Cannot execute this method on this object";
        private static readonly String ERR_TITLE = "Error during execution of command";

        private IActor _actActor;
        private IRoom _where;

        protected IActor ActActor{get; set;}
        protected IRoom Where{get; set;}

        /**
        * 
        */
        public void SetActor(IActor by) => ActActor = by;

        /**
        * 
        */
        public void SetRoom(IRoom where) => Where = where;

        /**
        * A message error useful for coders that advise the method is not invocable for this object.
        * (for example, for all QuickCommand objects, method like "modify" (specific of HandableGameCommand interface),
        * is not invocable).
        * @return this message error 
        */
        protected String GetGlobalErrMess() => GLOBAL_ERR_MESS;

        /**
        * For avoid DRY, other classes that extends this class can get a standard error title.
        * @return the error title, something that advise that action is not terminated correctly
        */
        protected String GetErrTitle() => ERR_TITLE;

        public abstract void Execute();

        public abstract bool IsReady();

        public abstract IList<IEntity> GetEntities();

        public abstract bool Modify(GameControl input);

        public abstract void SetCursorPos(Tuple<int, int> toFocus);

        public abstract void SetTarget(IList<IActor> targettableActors);

        public abstract bool IsTargetInRange(IActor target);

        public abstract int GetAPCost();

    }
}