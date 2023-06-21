using static OOP22_rusco_dc_csharp.Marcaccio.actors.stats.Stat;

namespace OOP22_rusco_dc_csharp.Marcaccio.actors.stats
{
    public interface IStat
    {
        void SetStatActualValue(StatName toSet, int actualValue);
        void SetStatMaxValue(StatName toSet, int maxValue);
        void SetStat(StatName toSet, Tuple<int, int> value);
        int GetStatActual(StatName statName);
        int GetStatMax(StatName statName);
    }
}
