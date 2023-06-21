using OOP22_rusco_dc_csharp.Pesaresi.Gamecommand;

namespace OOP22_rusco_dc_csharp.Marcaccio.actors.skills
{

    public interface ISkill
    {
        IGameCommand? GetAction(GameControl key);
        void SetAction(GameControl key, IGameCommand action);
    }
}
