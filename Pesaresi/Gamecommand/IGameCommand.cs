using System;

namespace OOP22_rusco_dc_csharp.Pesaresi.Gamecommand
{
    /**
   * Interface for game's command. Defines method that all command must to implement
*/
    public interface IGameCommand
    {
        /**
        * Set into command who summon this command.
        * Once setted, other call to this method will be ineffective
        * This method is indispensable to the future execution of the command
        * @param by the actor that summon this command
        */
        void SetActor(IActor by);

        /**
        * Set into command who summon this command.
        * Once setted, other call to this method will be ineffective
        * This method is indispensable to the future execution of the command
        * @param where the room where this action is executing
        */
        void SetRoom(IRoom where);

        /**
        * Check if the wrapped command is logically ready to be executed.
        * @return the relative boolean value
        */
        bool IsReady();

        /**
        * Execute the wrapped command.
        * Even if the command can logically run, maybe there is a problem
        * For example, if the Actor wants to move up, but it cannot do it because there is a wall
        * @return eventually this error, coded into a special class
        * @throws ModelException if the exception have to change the game flow
        */
        void Execute();
    }
}