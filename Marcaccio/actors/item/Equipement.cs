using OOP22_rusco_dc_csharp.CommonFile.GameControl;
using OOP22_rusco_dc_csharp.Marcaccio.actors.hero;
using OOP22_rusco_dc_csharp.Pesaresi.Gamecommand;
using static OOP22_rusco_dc_csharp.Marcaccio.actors.hero.Inventory;
using static OOP22_rusco_dc_csharp.Marcaccio.actors.stats.Stat;

namespace OOP22_rusco_dc_csharp.Marcaccio.actors.item
{
    /**
     * Implementation of the IEquipment interface.
     */
    public class Equipment : IEquipment
    {
        private readonly string _name;
        private readonly string _path;
        private readonly Slot _slot;
        private readonly Dictionary<StatName, int> _stat;
        private readonly Tuple<GameControl, IGameCommand>? _action;

        /**
         * Constructor for Equipment.
         * 
         * @param name        the name of the equipment
         * @param path        the path to the equipment related info
         * @param slot        the slot of the equipment
         * @param stat        the stats modified by the equipment
         * @param action      the action changed by the equipment
         */
        public Equipment(
            string name,
            string path,
            Slot slot,
            Dictionary<StatName, int> stat,
            Tuple<GameControl, IGameCommand> action)
        {
            _name = name;
            _path = path;
            _slot = slot;
            _stat = new Dictionary<StatName, int>(stat);
            _action = action;
        }

        /**
         * Gets whether the item is wearable.
         *
         * @return true if the item is wearable, false otherwise
         */
        public bool IsWearable() => true;

        /**
         * Gets the name of the equipment.
         *
         * @return the name of the equipment
         */
        public string GetName() => _name;

        /**
         * Gets the path to the equipment related info.
         *
         * @return the path to the equipment related info
         */
        public string GetPath() => _path;

        /**
         * Equips the equipment to the specified hero.
         *
         * @param hero the hero to equip the equipment to
         */
        public void Equip(IHero hero)
        {
            foreach (var entry in _stat)
            {
                hero.ModifyMaxStat(entry.Key, entry.Value);
                hero.ModifyActualStat(entry.Key, entry.Value);
            }

            if (_action != null)
            {
                hero.GetSkills().SetAction(_action.Item1, _action.Item2);
            }

            var inventory = hero.GetInventory();
            inventory.RemoveItem(inventory.GetAllItems().IndexOf(this));
        }

        /**
         * Unequips the equipment from the specified hero.
         *
         * @param hero the hero to unequip the equipment from
         */
        public void Unequip(IHero hero)
        {
            foreach (var entry in _stat)
            {
                hero.ModifyActualStat(entry.Key, -entry.Value);
                hero.ModifyMaxStat(entry.Key, -entry.Value);
            }

            hero.GetInventory().AddItem(this);
        }

        /**
         * Gets the slot occupied by the equipment.
         *
         * @return the slot occupied by the equipment
         */
        public Slot GetSlot() => _slot;
    }
}