namespace Marcaccio.skills
{
    public interface ISkill
    {
        IGameCommand? GetAction(GameControl key);
        void SetAction(GameControl key, IGameCommand action);
    }
}