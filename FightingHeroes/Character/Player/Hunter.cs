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
                $"[3] Crossbow (dmg: 1 - {CrossbowAttackMax})");

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
            return rnd.Next(5, DaggerAttackMax);
        }

        public int BowAttack()
        {
            return rnd.Next(3, BowAttackMax);
        }

        public int CrossbowAttack()
        {
            return rnd.Next(2, CrossbowAttackMax);
        }

        public override int Block()
        {
            return rnd.Next(1, Armor);
        }

        public override int Defense()
        {
            return Armor;
        }

        public override void GetStats()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nYOUR CHARACTER:");
            base.GetStats();
            Console.WriteLine($"Max Dagger Damage: {DaggerAttackMax} \n" +
                        $"Max Bow Damage: {BowAttackMax} \n" +
                        $"Max Crossbow Damage: {CrossbowAttackMax} \n" +
                        $"<H: {Health} | A: {Armor} | " +
                        $"MDD: {DaggerAttackMax} | MBD: {BowAttackMax} | MCD: {CrossbowAttackMax}> \n");
            Console.ResetColor();
        }

        public override int RestoreHealth(int playerActualHealth, int healthPotionsAmount)
        {
            if (healthPotionsAmount > 0)
            {
                if (playerActualHealth < 25)
                {
                    Health = Health + 5;
                }
                else if (playerActualHealth >= 25 && playerActualHealth < 30)
                {
                    Health = 30;
                }
            }
            else
            {
                return 0;
            }

            return Health;
        }
    }
}
