using OOP22_rusco_dc_csharp.Marcaccio.actors.hero;
using static OOP22_rusco_dc_csharp.Marcaccio.actors.hero.Inventory;

namespace OOP22_rusco_dc_csharp.Marcaccio.actors.item
{
    /**
     * Interface for the Equipment.
     */
    public interface IEquipment : IItem
    {
        /**
         * Equips the equipment to the specified hero.
         *
         * @param hero the hero to equip the equipment to
         */
        void Equip(IHero hero);

        /**
         * Unequips the equipment from the specified hero.
         *
         * @param hero the hero to unequip the equipment from
         */
        void Unequip(IHero hero);

        /**
         * Gets the slot occupied by the equipment.
         *
         * @return the slot occupied by the equipment
         */
        Slot GetSlot();
    }
}