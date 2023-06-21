using static OOP22_rusco_dc_csharp.Marcaccio.actors.stats.Stat;

namespace OOP22_rusco_dc_csharp.Marcaccio.actors.stats
{
    /**
    * Interface for the Stats used by Actors.
    */
    public interface IStat
    {
        /**
        * @param toSet
        * @param actualValue
        */
        void SetStatActualValue(StatName toSet, int actualValue);

        /**
        * @param toSet
        * @param maxlValue
        */
        void SetStatMaxValue(StatName toSet, int maxValue);

        /**
        * @param toSet
        * @param val
        */
        void SetStat(StatName toSet, Tuple<int, int> value);

        /**
        * @param statName which Stat you want to get the info from
        * @return the current value of that Stat
        */
        int GetStatActual(StatName statName);

        /**
        * @param statName which Stat you want to get the info from
        * @return the max value of that Stat
        */
        int GetStatMax(StatName statName);
    }
}
