using OOP22_rusco_dc_csharp.Marcaccio.actors.skills;
using OOP22_rusco_dc_csharp.Marcaccio.actors.stats;
using static OOP22_rusco_dc_csharp.Marcaccio.actors.stats.Stat;


namespace OOP22_rusco_dc_csharp.Marcaccio.actors
{
    /**
    * Interface for the Actors.
    */
    public interface IActor : IEntity
    {
        /**
        * @return the name of the Actor
        */
        string GetName();

        /**
        * @return the Actor's Stat
        */
        IStat GetStats();

        /**
        * @return the Actor's Skill 
        */
        ISkill GetSkills();

        /**
        * @param statName of the Stat you want to get info of
        * @return it's actual Value
        */
        int GetStatActual(StatName statName);

        /**
        * @param statName of the Stat you want to get info of
        * @return it's max Value
        */
        int GetStatMax(StatName statName);

        /**
        * @param newPos of the Actor
        */
        void SetPos(Tuple<int, int> newPos);

        /**
        * @param statName of the Stat you want to modify
        * @param value that you want to add to it's actual Value
        */
        void ModifyActualStat(StatName statName, int value);

        /**
        * @param statName of the Stat you want to modify
        * @param value that you want to add to it's max Value
        */
        void ModifyMaxStat(StatName statName, int value);

        /**
        * @return if the Hero is alive
        */
        bool IsAlive();
    }
}