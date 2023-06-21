using Marcaccio.skills;
using NUnit.Framework;
using OOP22_rusco_dc_csharp.Marcaccio.actors.hero;
using OOP22_rusco_dc_csharp.Marcaccio.actors.item;
using OOP22_rusco_dc_csharp.Marcaccio.actors.skills;
using OOP22_rusco_dc_csharp.Marcaccio.actors.stats;
using OOP22_rusco_dc_csharp.Pesaresi.Gamecommand;
using static OOP22_rusco_dc_csharp.Marcaccio.actors.stats.Stat;

namespace OOP22_rusco_dc_csharp.Marcaccio.test
{
    [TestFixture]
    public class HeroTest
    {
        private readonly Tuple<int, int> _actHeroPos = new (0,0);
        private readonly ISkill _skill = new Skill();
        private readonly IStat _stat = new Stat();
        private readonly string _name = "Test";
        IHero _hero;

        [SetUp]
        public void Start()
        {
            _stat.SetStat(StatName.HP, new (1,1));
            _stat.SetStat(StatName.AP, new (1,1));
            _stat.SetStat(StatName.DMG, new (1,1));
            _stat.SetStat(StatName.STR, new (1,1));
            _stat.SetStat(StatName.DEX, new (1,1));
            _stat.SetStat(StatName.INT, new (1,1));

            _skill.SetAction(GameControl.MOVE, new MoveUpCommand());
            
            _hero = new Hero(_name, _actHeroPos, _skill, _stat);

            Dictionary<StatName, int> _equipStat = new()
            {
                { StatName.HP, 1 }
            };
            IEquipment _equip = new Equipment("TestEquip", "TestEquipPath", Inventory.Slot.WEAPON, _equipStat, null);
            _hero.GetInventory().AddItem(_equip);
        }

        [Test]
        public void ActorTest() {
            Tuple<int, int> _pos = new (0,0);
            int _statVal = 1;
            IStat _tetsStat = _hero.GetStats();
            
            foreach (StatName statName in Enum.GetValues(typeof(StatName)))
            {
                Assert.Multiple(() =>
                {
                    Assert.That(_tetsStat.GetStatActual(statName), Is.EqualTo(_statVal));
                    Assert.That(_tetsStat.GetStatMax(statName), Is.EqualTo(_statVal));
                });
            }
        } 


    }
}