namespace OOP22_rusco_dc_csharp.Marcaccio.actors.stats
{
    /**
    * A class used to manage the Stats of an Actor.
    */
    public class Stat : IStat
    {
        /**
        * StatName represent every name associated to every Stat of an Actor.
        */
        public enum StatName
        {
            /**
            * HP represent the Health Value of the actor.
            */
            HP,
            /**
            * AP represent the Action Points of the actor.
            */
            AP,
            /**
            * DMG represent the Base Damage of the actor.
            */
            DMG,
            /**
            * STR represent the Strenght Value of the actor.
            */
            STR,
            /**
            * DEX represent the Dexterity Value of the actor.
            */
            DEX,
            /**
            * INT represent the Intellect Value of the actor.
            */
            INT
        }

        private static readonly Tuple<int, int> DEFAULT = new(0, 0);

        private readonly Dictionary<StatName, Tuple<int, int>> _stats;

        /**
        * Basic Constructor for StatImpl.
        */
        public Stat()
        {
            _stats = new Dictionary<StatName, Tuple<int, int>>();

            foreach (StatName statName in Enum.GetValues(typeof(StatName)))
            {
                _stats[statName] = DEFAULT;
            }
        }

        /**
        * 
        */
        public void SetStatActualValue(StatName toSet, int actualValue)
        {
            Tuple<int, int> values = _stats[toSet];
            _stats[toSet] = new(actualValue, values.Item2);
        }

        /**
        * 
        */
        public void SetStatMaxValue(StatName toSet, int maxValue)
        {
            Tuple<int, int> values = _stats[toSet];
            _stats[toSet] = new(values.Item1, maxValue);
        }

        /**
        * 
        */
        public void SetStat(StatName toSet, Tuple<int, int> value) => _stats[toSet] = value;

        /**
        * 
        */
        public int GetStatActual(StatName statName) => _stats[statName].Item1;

        /**
        * 
        */
        public int GetStatMax(StatName statName) => _stats[statName].Item2;

        /**
        * 
        */
        public override string ToString()
        {
            string info = "";
            foreach (StatName statName in Enum.GetValues(typeof(StatName)))
            {
                info += statName + ":["
                    + GetStatActual(statName) + "|"
                    + GetStatMax(statName) + "], ";
            }
            return info[..^2];
        }
    }
}