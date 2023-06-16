using Marcaccio.skills;
using Marcaccio.stats;
using static YourNamespace.Stats.StatImpl;

namespace Marcaccio.actors
{
    public interface IActor : IGameCommand
    {
        string GetName();
        IStat GetStats();
        ISkill GetSkills();
        int GetStatActual(StatName statName);
        int GetStatMax(StatName statName);
        void SetPos(Tuple<int, int> newPos);
        void ModifyActualStat(StatName statName, int value);
        void ModifyMaxStat(StatName statName, int value);
        bool IsAlive();
    }
}