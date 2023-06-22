using OOP22_rusco_dc_csharp.CommonFile.GameControl;
using OOP22_rusco_dc_csharp.Pesaresi.Gamecommand;

namespace OOP22_rusco_dc_csharp.Marcaccio.actors.skills
{
    /**
    * Interface of the Skill used by Actors.
    */
    public interface ISkill
    {
        /**
        * @param key
        * @return the Builder from the correct input
        */
        IGameCommand? GetAction(GameControl key);

        /**
        * @param key the keybind of the Gamecommand you want to set 
        * @param action the new GameCommand you want to put
        */
        void SetAction(GameControl key, IGameCommand action);
    }
}
