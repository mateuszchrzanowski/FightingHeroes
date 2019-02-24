using FightingHeroes.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingHeroes.Character.Player
{
    class Warrior : Hero
    {
        //PROPERTIES
        public int SwordAttackMax { get; set; }
        public int AxeAttackMax { get; set; }
        public int MaceAttackMax { get; set; }

        public override int Attack()
        {
            int attackType = 0;

            do
            {
                Console.WriteLine("\nSelect your attack type: \n" +
                $"[1] Sword (dmg: 5 - {SwordAttackMax}) \n" +
                $"[2] Axe (dmg: 3 - {AxeAttackMax}) \n" +
                $"[3] Mace (dmg: 1 - {MaceAttackMax}) \n" +
                $"[4] Special Attack (dmg: 27) (x{SpecialAttackNumber})");

                ConsoleKeyInfo attack = Console.ReadKey();

                switch (attack.KeyChar)
                {
                    case '1':
                        Console.WriteLine();
                        attackType = SwordAttack();
                        break;
                    case '2':
                        Console.WriteLine();
                        attackType = AxeAttack();
                        break;
                    case '3':
                        Console.WriteLine();
                        attackType = MaceAttack();
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
        public int SwordAttack()
        {
            SoundEffect.GetSound(Resource.sword);
            return rnd.Next(5, SwordAttackMax);
        }

        public int AxeAttack()
        {
            SoundEffect.GetSound(Resource.axe);
            return rnd.Next(3, AxeAttackMax);
        }

        public int MaceAttack()
        {
            SoundEffect.GetSound(Resource.mace);
            return rnd.Next(1, MaceAttackMax);
        }

        public int SpecialAttack(int specialAttackNumber)
        {
            if (specialAttackNumber > 0)
            {
                SoundEffect.GetSound(Resource.warrior_special);
                return (SwordAttackMax + AxeAttackMax + MaceAttackMax) - 10;
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
            return rnd.Next(3, Armor);
        }

        public override int Defense()
        {
            SoundEffect.GetSound(Resource.warrior_defense);
            return Armor;
        }

        public override void GetStats()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nYOUR CHARACTER:");
            base.GetStats();
            Console.WriteLine($"Max Sword Damage: {SwordAttackMax} \n" +
                        $"Max Axe Damage: {AxeAttackMax} \n" +
                        $"Max Mace Damage: {MaceAttackMax} \n" +
                        $"<H: {Health} | A: {Armor} | " +
                        $"MSD: {SwordAttackMax} | MAD: {AxeAttackMax} | MMD: {MaceAttackMax}> \n");
            Console.ResetColor();
        }

        public override int RestoreHealth(int playerActualHealth, int healthPotionsAmount)
        {
            //if (healthPotionsAmount > 0)
            //{
                if (playerActualHealth < 30)
                {
                    Health = Health + 5;
                }
                else if (playerActualHealth >= 30 && playerActualHealth < 35)
                {
                    Health = 35;
                }
            //}
            //else
            //{
            //    return 0;
            //}

            return Health;
        }
    }
}
