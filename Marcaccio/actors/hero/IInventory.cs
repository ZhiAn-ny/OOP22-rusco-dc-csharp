using OOP22_rusco_dc_csharp.Marcaccio.actors.item;

namespace OOP22_rusco_dc_csharp.Marcaccio.actors.hero
{
    /**
     * Interface for the Inventory of a Hero.
     */
    public interface IInventory
    {
        /**
         * Gets the item at the specified index.
         *
         * @param index the index of the item
         * @return the item at the specified index
         */
        IItem GetItem(int index);

        /**
         * Adds an item to the inventory.
         *
         * @param item the item to add
         */
        void AddItem(IItem item);

        /**
         * Removes the item at the specified index from the inventory.
         *
         * @param index the index of the item to remove
         */
        void RemoveItem(int index);

        /**
         * Gets the list of equipped items.
         *
         * @return the list of equipped items
         */
        List<IEquipment?> GetEquippedItems();

        /**
         * Equips an equipment item to the specified hero.
         *
         * @param equipment the equipment item to equip
         * @param hero      the hero to equip the item to
         */
        void Equip(IEquipment equipment, IHero hero);

        /**
         * Gets the list of all items in the inventory.
         *
         * @return the list of all items in the inventory
         */
        List<IItem> GetAllItems();

        /**
         * Checks if the inventory is empty.
         *
         * @return true if the inventory is empty, false otherwise
         */
        bool IsEmpty();

        /**
         * Gets the number of occupied inventory slots.
         *
         * @return the number of occupied inventory slots
         */
        int SlotOccupied();

        /**
         * Checks if the inventory is full.
         *
         * @return true if the inventory is full, false otherwise
         */
        bool IsFull();
    }
}
