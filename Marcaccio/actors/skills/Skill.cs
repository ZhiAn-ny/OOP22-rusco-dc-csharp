using OOP22_rusco_dc_csharp.Marcaccio.actors.skills;
using OOP22_rusco_dc_csharp.Pesaresi.Gamecommand;

namespace Marcaccio.skills
{
    public class Skill : ISkill
    {
        private readonly Dictionary<GameControl, IGameCommand> _skills;

        public Skill()
        {
            _skills = new Dictionary<GameControl, IGameCommand>();
        }

        public void SetAction(GameControl key, IGameCommand action) => _skills[key] = action;

        public IGameCommand? GetAction(GameControl key) => _skills[key];

        
    }
}