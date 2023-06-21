using OOP22_rusco_dc_csharp.Marcaccio.actors.skills;
using OOP22_rusco_dc_csharp.Marcaccio.actors.stats;
using OOP22_rusco_dc_csharp.Pesaresi.Gamecommand;

namespace OOP22_rusco_dc_csharp.Marcaccio.actors.hero
{
    /**
     * The implementation of the interface Hero used to create the playable characters.
     */
    public class Hero : AbstractActor, IHero
    {
        private readonly IInventory _inventory;
        private readonly string _path;

        /**
         * Basic Constructor for the Hero.
         * 
         * @param name        the name of the Hero
         * @param initialPos  the initial position of the Hero
         * @param skills      the skills of the Hero
         * @param stats       the stats of the Hero
         */
        public Hero(string name, Tuple<int, int> initialPos, ISkill skills, IStat stats)
            : base(name, stats, skills, initialPos)
        {
            _inventory = new Inventory();
            _path = "it/unibo/ruscodc/hero_res/" + GetName();
        }

        /**
         * {@inheritdoc}
         */
        public IGameCommand? Act(GameControl key)
        {
            IGameCommand? command = GetSkills().GetAction(key);
            if (command == null)
            {
                return null;
            }

            command.SetActor(this);
            return command;
        }

        /**
         * {@inheritdoc}
         */
        public IInventory GetInventory() => _inventory;

        public override string GetPath() => _path;

        /**
         * {@inheritdoc}
         */
        public override string ToString()
        {
            return GetStats().ToString() + "\n" + GetSkills().ToString();
        }
    }
}