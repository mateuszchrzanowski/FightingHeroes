using FightingHeroes.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingHeroes.Character.Player
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
            int attackType = 0;

            do
            {
                Console.WriteLine("\nSelect your attack type:\n" +
                $"[1] Fireball (dmg: 4 - {FireballAttackMax})\n" +
                $"[2] Lightning (dmg: 2 - {LightningAttackMax})\n" +
                $"[3] Wild Fire (dmg: 1 - {WildFireAttackMax})");

                ConsoleKeyInfo attack = Console.ReadKey();

                switch (attack.KeyChar)
                {
                    case '1':
                        Console.WriteLine();
                        attackType = FireballAttack();
                        break;
                    case '2':
                        Console.WriteLine();
                        attackType = LightningAttack();
                        break;
                    case '3':
                        Console.WriteLine();
                        attackType = WildFireAttack();
                        break;
                    default:
                        attackType = 0;
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("\nWrong input. Please try again.");
                        Console.ResetColor();
                        break;
                }
            }
            while (attackType == 0);

            return attackType;
        }

        //METHODS
        public int FireballAttack()
        {
            SoundEffect.GetSound(Resource.fireball);
            return rnd.Next(4, FireballAttackMax);
        }

        public int LightningAttack()
        {
            SoundEffect.GetSound(Resource.lightning);
            return rnd.Next(2, LightningAttackMax);
        }

        public int WildFireAttack()
        {
            SoundEffect.GetSound(Resource.wild_fire);
            return rnd.Next(1, WildFireAttackMax);
        }

        public override int Block()
        {
            return rnd.Next(1, Armor);
        }

        public override int Defense()
        {
            SoundEffect.GetSound(Resource.wizard_defense);
            return Armor;
        }

        public override void GetStats()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nYOUR CHARACTER:");
            base.GetStats();
            Console.WriteLine($"Max Fireball Damage: {FireballAttackMax} \n" +
                        $"Max Lightning Damage: {LightningAttackMax} \n" +
                        $"Max Wild Fire Damage: {WildFireAttackMax} \n" +
                        $"<H: {Health} | A: {Armor} | MFD: {FireballAttackMax} | " +
                        $"MLD: {LightningAttackMax} | MWFD: {WildFireAttackMax}> \n");
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
