using OOP22_rusco_dc_csharp.Marcaccio.actors.skills;
using OOP22_rusco_dc_csharp.Marcaccio.actors.stats;
using static OOP22_rusco_dc_csharp.Marcaccio.actors.stats.Stat;


namespace OOP22_rusco_dc_csharp.Marcaccio.actors
{
    public interface IActor : IEntity
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