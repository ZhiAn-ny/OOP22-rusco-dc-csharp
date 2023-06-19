using System;
using System.Collections.Generic;

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

        /**
        * Client must not create directily this objects.
        */
        protected BasicGameCommand()
        {
        }

        /**
        * 
        */
        public void SetActor(IActor by) => _actActor = by;

        /**
        * 
        */
        public void SetRoom(IRoom where) => _where = where;


        /**
        * For avoid DRY, other classes that extends this class get who summon the command by this method.
        * @return who summon the command
        */
        protected IActor GetActor() => _actActor;

        /**
        * For avoid DRY, other classes that extends this class get where the command was summoned by this method.
        * @return where the command was summoned
        */
        protected IRoom getRoom() => _where;

        /**
        * A message error useful for coders that advise the method is not invocable for this object.
        * (for example, for all QuickCommand objects, method like "modify" (specific of HandableGameCommand interface),
        * is not invocable).
        * @return this message error 
        */
        protected String getGlobalErrMess() => GLOBAL_ERR_MESS;

        /**
        * For avoid DRY, other classes that extends this class can get a standard error title.
        * @return the error title, something that advise that action is not terminated correctly
        */
        protected String getErrTitle() => ERR_TITLE;

        public abstract void Execute();

        public abstract bool IsReady();

        public abstract IList<IEntity> GetEntities();

        public abstract bool Modify(GameControl input);

        public abstract void SetCursorPos(Tuple<Int32, Int32> toFocus);

        public abstract void SetTarget(IList<IActor> targettableActors);

        public abstract bool IsTargetInRange(IActor target);

        public abstract int GetAPCost();

    }
}