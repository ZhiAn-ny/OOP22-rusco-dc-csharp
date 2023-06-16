using static YourNamespace.Stats.StatImpl;

namespace Marcaccio.stats
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