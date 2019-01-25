using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingHeroes
{
    class Wizard : Hero
    {
        //PROPERTIES
        public int FireballAttackMax { get; set; }
        public int LightningAttackMax { get; set; }
        public int WildFireAttackMax { get; set; }

        //METHODS
        public override int Attack()
        {
            //int attack = 0;
            int attackType = 0;

            do
            {
                Console.WriteLine("\nSelect your attack type:\n" +
                $"[1] Fireball (dmg: 4 - {FireballAttackMax})\n" +
                $"[2] Lightning (dmg: 2 - {LightningAttackMax})\n" +
                $"[3] Wild Fire (dmg: 1 - {WildFireAttackMax})");

                //attack = Convert.ToInt32(Console.ReadLine());
                //attack = Convert.ToInt32(Console.ReadKey().Key.ToString());
                //Console.WriteLine();
                ConsoleKeyInfo attack = Console.ReadKey();

                switch (attack.KeyChar)
                {
                    case '1':
                        //Console.WriteLine("Fireball");
                        Console.WriteLine();
                        attackType = FireballAttack();
                        break;
                    case '2':
                        //Console.WriteLine("Lightning");
                        Console.WriteLine();
                        attackType = LightningAttack();
                        break;
                    case '3':
                        //Console.WriteLine("Wild Fire");
                        Console.WriteLine();
                        attackType = WildFireAttack();
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

        public int FireballAttack()
        {
            return rnd.Next(4, FireballAttackMax);
        }

        public int LightningAttack()
        {
            return rnd.Next(2, LightningAttackMax);
        }

        public int WildFireAttack()
        {
            return rnd.Next(1, WildFireAttackMax);
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
            Console.WriteLine("\nYOUR CHARACTER: \n" +
                        $"Name: {Name} \n" +
                        "Class: Wizard \n" +
                        $"Health: {Health} \n" +
                        $"Armor: {Armor} \n" +
                        $"Max Fireball Damage: {FireballAttackMax} \n" +
                        $"Max Lightning Damage: {LightningAttackMax} \n" +
                        $"Max Wild Fire Damage: {WildFireAttackMax} \n" +
                        $"<H: {Health} | A: {Armor} | MFD: {FireballAttackMax} | " +
                        $"MLD: {LightningAttackMax} | MWFD: {WildFireAttackMax}> \n");
        }
    }
}
