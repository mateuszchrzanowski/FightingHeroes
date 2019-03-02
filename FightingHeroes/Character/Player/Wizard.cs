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
                $"[3] Wild Fire (dmg: 1 - {WildFireAttackMax}) \n" +
                $"[4] Special Attack (dmg: 35) (x{SpecialAttackNumber})");

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
                    case '4':
                        Console.WriteLine();
                        attackType = SpecialAttack(SpecialAttackNumber);
                        SpecialAttackNumber--;
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

        public int SpecialAttack(int specialAttackNumber)
        {
            if (specialAttackNumber > 0)
            {
                SoundEffect.GetSound(Resource.wizard_special);
                return (FireballAttackMax + LightningAttackMax + WildFireAttackMax) - 10;
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
            SoundEffect.GetSound(Resource.wizard_defense);
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
            Console.WriteLine($"Max Fireball Damage: {FireballAttackMax} \n" +
                        $"Max Lightning Damage: {LightningAttackMax} \n" +
                        $"Max Wild Fire Damage: {WildFireAttackMax} \n" +
                        $"Defense Possibilities: {DefenseAmount} \n" +
                        $"Health Potions Amount: {HealthPotionsAmount} \n" +
                        $"<H: {Health} | A: {Armor} | MFD: {FireballAttackMax} | " +
                        $"MLD: {LightningAttackMax} | MWFD: {WildFireAttackMax}> \n");
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
