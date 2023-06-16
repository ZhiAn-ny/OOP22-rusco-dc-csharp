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

        public override string ToString()
        {
            string info = string.Empty;
            foreach (GameControl gameCommand in GameControl.GetAttackControls())
            {
                info += gameCommand.ToString() + _skills[gameCommand].ToString();
            }
            return info;
        }
    }
}