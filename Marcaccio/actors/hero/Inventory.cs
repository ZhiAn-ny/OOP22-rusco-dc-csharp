using It.Unibo.Ruscodc.Model.Actors.Hero;
using OOP22_rusco_dc_csharp.Marcaccio.actors.item;

namespace OOP22_rusco_dc_csharp.Marcaccio.actors.hero
{
    /**
     * Implementation of Inventory that is used by the Hero to store Items.
     */
    public class Inventory : IInventory
    {
        /**
         * Slot used in the Equipment.
         */
        public enum Slot
        {
            /**
             * Head slot for Equipment.
             */
            HEAD,
            /**
             * Armor slot for Equipment.
             */
            ARMOR,
            /**
             * Weapon slot for Equipment.
             */
            WEAPON,
            /**
             * Special slot for Equipment.
             */
            SPECIAL
        }

        private const int INV_SPACE = 35;

        private readonly List<IItem> _bag;
        private readonly Dictionary<Slot, IEquipment?> _equipment;

        /**
         * Basic Constructor for the Inventory.
         */
        public Inventory()
        {
            _bag = new List<IItem>();
            _equipment = new Dictionary<Slot, IEquipment?>();
            foreach (Slot slot in Enum.GetValues(typeof(Slot)))
            {
                _equipment.Add(slot, null);
            }
        }

        /**
         * {@inheritdoc}
         */
        public IItem GetItem(int index)
        {
            return _bag[index];
        }

        /**
         * {@inheritdoc}
         */
        public List<IEquipment> GetEquippedItems() => _equipment.Values.ToList();

        /**
         * {@inheritdoc}
         */
        public void Equip(IEquipment equip, IHero hero)
        {
            IEquipment toUnequip = _equipment[equip.GetSlot()];
            toUnequip?.Unequip(hero);
            _equipment[equip.GetSlot()] = equip;
            equip.Equip(hero);
        }

        /**
         * {@inheritdoc}
         */
        public List<IItem> GetAllItems() => _bag;

        /**
         * {@inheritdoc}
         */
        public void AddItem(IItem item) => _bag.Add(item);

        /**
         * {@inheritdoc}
         */
        public void RemoveItem(int index) => _bag.RemoveAt(index);

        /**
         * {@inheritdoc}
         */
        public bool IsEmpty() => _bag.Count == 0;

        /**
         * {@inheritdoc}
         */
        public int SlotOccupied() => _bag.Count;

        /**
         * {@inheritdoc}
         */
        public bool IsFull() => _bag.Count >= INV_SPACE;
    }
}