using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingHeroes
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
                $"[3] Mace (dmg: 1 - {MaceAttackMax})");

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

        public int SwordAttack()
        {
            return rnd.Next(5, SwordAttackMax);
        }

        public int AxeAttack()
        {
            return rnd.Next(3, AxeAttackMax);
        }

        public int MaceAttack()
        {
            return rnd.Next(1, MaceAttackMax);
        }

        public override int Block()
        {
            return rnd.Next(3, Armor);
        }

        public override int Defense()
        {
            return Armor;
        }

        public override void GetStats()
        {
            Console.WriteLine("\nYOUR CHARACTER:");
            base.GetStats();
            Console.WriteLine($"Max Sword Damage: {SwordAttackMax} \n" +
                        $"Max Axe Damage: {AxeAttackMax} \n" +
                        $"Max Mace Damage: {MaceAttackMax} \n" +
                        $"<H: {Health} | A: {Armor} | " +
                        $"MSD: {SwordAttackMax} | MAD: {AxeAttackMax} | MMD: {MaceAttackMax}> \n");
        }

        public override void RestoreHealth(int playerActualHealth)
        {
            /*
            if (playerActualHealth < (Health - 5))
            {
                Health = playerActualHealth + 5;
            }
            else if(playerActualHealth > (Health - 5) && playerActualHealth < Health)
            {
                Health = playerActualHealth;
            }
            */

        }
    }
}
