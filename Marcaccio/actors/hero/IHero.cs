using Marcaccio.actors;
using OOP22_rusco_dc_csharp.Marcaccio.actors.hero;
using OOP22_rusco_dc_csharp.Pesaresi.Gamecommand;

namespace It.Unibo.Ruscodc.Model.Actors.Hero
{
    /**
     * Interface of the Hero controlled by the player.
     */
    public interface IHero : IActor
    {
        /**
         * Method used to make the player act with the hero.
         *
         * @param key the key pressed by the Player
         * @return an optional game command
         */
        IGameCommand? Act(GameControl key);

        /**
         * Gets the hero's inventory.
         *
         * @return the hero's inventory
         */
        IInventory GetInventory();
    }
}
