﻿using FightingHeroes.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingHeroes.Character.Player
{
    class Hunter : Hero
    {
        //PROPERTIES
        public int DaggerAttackMax { get; set; }
        public int BowAttackMax { get; set; }
        public int CrossbowAttackMax { get; set; }

        public override int Attack()
        {
            int attackType = 0;

            do
            {
                Console.WriteLine("\nSelect your attack type: \n" +
                $"[1] Dagger (dmg: 5 - {DaggerAttackMax}) \n" +
                $"[2] Bow (dmg: 3 - {BowAttackMax}) \n" +
                $"[3] Crossbow (dmg: 1 - {CrossbowAttackMax}) \n" +
                $"[4] Special Attack (dmg: 27) (x{SpecialAttackNumber})");

                ConsoleKeyInfo attack = Console.ReadKey();

                switch (attack.KeyChar)
                {
                    case '1':
                        Console.WriteLine();
                        attackType = DaggerAttack();
                        break;
                    case '2':
                        Console.WriteLine();
                        attackType = BowAttack();
                        break;
                    case '3':
                        Console.WriteLine();
                        attackType = CrossbowAttack();
                        break;
                    case '4':
                        Console.WriteLine();
                        attackType = SpecialAttack(SpecialAttackNumber);
                        SpecialAttackNumber--;
                        break;
                    default:
                        attackType = 0;
                        Console.WriteLine();
                        Console.WriteLine("\nWrong input. Please try again.");
                        break;
                }
            }
            while (attackType == 0);

            return attackType;
        }

        //METHODS
        public int DaggerAttack()
        {
            SoundEffect.GetSound(Resource.dagger);
            return rnd.Next(5, DaggerAttackMax);
        }

        public int BowAttack()
        {
            SoundEffect.GetSound(Resource.bow);
            return rnd.Next(3, BowAttackMax);
        }

        public int CrossbowAttack()
        {
            SoundEffect.GetSound(Resource.crossbow);
            return rnd.Next(2, CrossbowAttackMax);
        }

        public int SpecialAttack(int specialAttackNumber)
        {
            if (specialAttackNumber > 0)
            {
                SoundEffect.GetSound(Resource.hunter_special);
                return (DaggerAttackMax + BowAttackMax + CrossbowAttackMax) - 10;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nYou don't have enough power to use your special attack. Please select other attack.");
                Console.ResetColor();
                return 0;
            }
        }

        public override int Block()
        {
            return rnd.Next(1, Armor);
        }

        public override int Defense()
        {
            SoundEffect.GetSound(Resource.hunter_defense);
            return Armor;
        }

        public override int DefenseRestoreHealth(int playerActualHealth)
        {
            if (playerActualHealth < 20)
            {
                Health = Health + 10;
            }
            else if (playerActualHealth >= 20 && playerActualHealth < 30)
            {
                Health = 30;
            }

            return Health;
        }

        public override void GetStats()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nYOUR CHARACTER:");
            base.GetStats();
            Console.WriteLine($"Max Dagger Damage: {DaggerAttackMax} \n" +
                        $"Max Bow Damage: {BowAttackMax} \n" +
                        $"Max Crossbow Damage: {CrossbowAttackMax} \n" +
                        $"Defense Possibilities: {DefenseAmount} \n" +
                        $"Health Potions Amount: {HealthPotionsAmount} \n" +
                        $"<H: {Health} | A: {Armor} | " +
                        $"MDD: {DaggerAttackMax} | MBD: {BowAttackMax} | MCD: {CrossbowAttackMax}> \n");
            Console.ResetColor();
        }

        public override int RestoreHealth(int playerActualHealth)
        {
            if (playerActualHealth < 15)
            {
                Health = Health + 15;
            }
            else if (playerActualHealth >= 15 && playerActualHealth < 30)
            {
                Health = 30;
            }
            return Health;
        }
    }
}
