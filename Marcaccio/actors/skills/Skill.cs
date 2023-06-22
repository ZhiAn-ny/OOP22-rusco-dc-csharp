using OOP22_rusco_dc_csharp.Pesaresi.Gamecommand;

namespace OOP22_rusco_dc_csharp.Marcaccio.actors.skills
{
    /**
    * The Class that manage the "Actions"(GameCommand) an Actor can do.
    */
    public class Skill : ISkill
    {
        private readonly Dictionary<GameControl, IGameCommand> _skills;

        /**
        * 
        */
        public Skill()
        {
            _skills = new Dictionary<GameControl, IGameCommand>();
        }

        /**
        * 
        */
        public void SetAction(GameControl key, IGameCommand action) => _skills[key] = action;

        /**
        * 
        */
        public IGameCommand? GetAction(GameControl key) => _skills[key];

        /**
        *
        */
        public override string ToString()
        {
            string info = string.Empty;
            foreach (GameControl gameCommand in GameControl.GetAttackControls())
            {
                info += $"{gameCommand.ToString()}{skills[gameCommand].ToString()}";
            }
            return info;
        }
    }
}