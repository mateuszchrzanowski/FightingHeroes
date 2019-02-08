﻿using System;
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
         * 
         * 
         * Trzeba ograniczyć możliwość wykorzystania Life Potion. Np. 3 razy
         * 
         * Pozmieniać kolory tekstu
         * 
         * Zrobić tryb multiplayer
         * 
         * 
         * 
        */

        //DONE:
        /*
         * 
         * Implemented Hunter.cs class. Deleted useless comments.
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
                case "hunter":
                    Hero hunter = new Hunter()
                    {
                        Name = Intro.GetName(),
                        CharacterClass = "Hunter",
                        Health = 30,
                        Armor = 6,
                        DaggerAttackMax = 9,
                        BowAttackMax = 13,
                        CrossbowAttackMax = 15,
                    };
                    hunter.GetStats();
                    Journey.StartJourney(hunter);
                    break;
            }

            Console.ReadLine();
        }
    }
}
