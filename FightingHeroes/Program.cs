﻿using System;
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
         * Zmienić metodę Battle.StartFight() - aktualnie po śmierci bohatera można wybierąc kolejne lokacje w Journey.cs.
         * Trzeba to zmienić na Game Over!
         * 
         * Health nie będzie się odnawiać po każdym przeciwniku. Zrobimy za to Life Potion.
         * Będzie można odnowić Health (albo na maxa albo np +5. jescze nie wiem)
         * 
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
         * Updated GetMountainsScenario() and GetSwampsScenario() methods.
         * Added GetCaveScenario() and GetBurialScenario()
         * Added Manticore.cs and Zombie.cs
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
