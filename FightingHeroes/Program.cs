using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingHeroes
{
    class Program
    {
        //TODO:
        /* Commit
         * 
         * tymczasowo wizard ma 999 hp - pamiętać o tym
         * 
         * Health nie będzie się odnawiać po każdym przeciwniku. Zrobimy za to Life Potion.
         * Będzie można odnowić Health (albo na maxa albo np +5. jescze nie wiem)
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
         * Add RestoreHealth() method in Hero.cs class. Working on implement RestoreHealth() method in battle process.
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
                        Health = 999,//30,
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
