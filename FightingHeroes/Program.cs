using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightingHeroes.Character.Player;

namespace FightingHeroes
{
    class Program
    {
        //TODO:
        /* Commit
         * 
         * Trzeba poprawnie zaimplementować Hunter.cs, na razie tylko utworzyłem klasę
         * 
         * 
         * Trzeba ograniczyć możliwość wykorzystania Life Potion. Np. 3 razy
         * 
         * Pozmieniać kolory tekstu
         * 
         * Zrobić tryb multiplayer
         * 
         * zrobić więcej postaci
         * 
         * 
        */

        //DONE:
        /*
         * 
         * Implemented RestoreHealth() method in battle process. Added Hunter.cs class.
         * 
         */

        static void Main(string[] args)
        {
            switch (Intro.StartGame())
            {
                case "wizard":
                    Hero wizard = new Wizard()
                    {
                        Name = Intro.GetName(),
                        CharacterClass = "Wizard",
                        Health = 30,
                        Armor = 7,
                        FireballAttackMax = 13,
                        LightningAttackMax = 15,
                        WildFireAttackMax = 17,
                    };
                    wizard.GetStats();
                    Journey.StartJourney(wizard);
                    break;
                case "warrior":
                    Hero warrior = new Warrior()
                    {
                        Name = Intro.GetName(),
                        CharacterClass = "Warrior",
                        Health = 35,
                        Armor = 8,
                        SwordAttackMax = 10,
                        AxeAttackMax = 12,
                        MaceAttackMax = 15,
                    };
                    warrior.GetStats();
                    Journey.StartJourney(warrior);
                    break;
            }

            Console.ReadLine();
        }
    }
}
