using Marcaccio.stats;

namespace YourNamespace.Stats
{
    public class StatImpl : IStat
    {
        public enum StatName
        {
            HP,
            AP,
            DMG,
            STR,
            DEX,
            INT
        }

        private static readonly Tuple<Int32, Int32> DEFAULT = new(0, 0);

        private readonly Dictionary<StatName, Tuple<Int32, Int32>> _stats;

        public StatImpl()
        {
            _stats = new Dictionary<StatName, Tuple<Int32, Int32>>();

            foreach (StatName statName in Enum.GetValues(typeof(StatName)))
            {
                _stats[statName] = DEFAULT;
            }
        }

        public void SetStatActualValue(StatName toSet, int actualValue)
        {
            Tuple<Int32, Int32> values = _stats[toSet];
            _stats[toSet] = new (actualValue, values.Item2);
        }

        public void SetStatMaxValue(StatName toSet, int maxValue)
        {
            Tuple<Int32, Int32> values = _stats[toSet];
            _stats[toSet] = new (values.Item1, maxValue);
        }

        public void SetStat(StatName toSet, Tuple<Int32, Int32> value) => _stats[toSet] = value;

        public int GetStatActual(StatName statName) => _stats[statName].Item1;

        public int GetStatMax(StatName statName) => _stats[statName].Item2;

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