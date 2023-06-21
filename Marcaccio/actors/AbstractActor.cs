using Marcaccio;
using OOP22_rusco_dc_csharp.Bevilacqua.gamemap;
using OOP22_rusco_dc_csharp.Marcaccio.actors.skills;
using OOP22_rusco_dc_csharp.Marcaccio.actors.stats;
using OOP22_rusco_dc_csharp.Pesaresi.Gamecommand;
using static OOP22_rusco_dc_csharp.Marcaccio.actors.stats.Stat;


namespace OOP22_rusco_dc_csharp.Marcaccio.actors
{
    public abstract class AbstractActor : IActor
    {
        private readonly string _name;
        private readonly int _ID = 3;
        private readonly IStat _stat;
        private readonly ISkill _skill;
        private Tuple<int, int> _pos;

        protected AbstractActor(string name, IStat stat, ISkill skill, Tuple<int, int> pos)
        {
            _name = name;
            _stat = stat;
            _skill = skill;
            _pos = pos;
        }

        public int GetID() => _ID;
        public string GetName() => _name;
        public IStat GetStats() => _stat;
        public ISkill GetSkills() => _skill;
        public Tuple<int, int> GetPos() => _pos;
        public int GetStatActual(StatName statName) => _stat.GetStatActual(statName);
        public int GetStatMax(StatName statName) => _stat.GetStatMax(statName);
        public void SetPos(Tuple<int, int> newPos) => _pos = newPos;
        public void ModifyActualStat(StatName statName, int value) => _stat.SetStatActualValue(statName, value);
        public void ModifyMaxStat(StatName statName, int value) => _stat.SetStatMaxValue(statName, value);
        public bool IsAlive() => _stat.GetStatActual(StatName.HP) > 0;
        public abstract string GetPath();
    }
}