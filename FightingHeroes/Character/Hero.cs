using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingHeroes
{
    abstract class Hero
    {
        //PROPERTIES
        public string Name { get; set; }
        public string CharacterClass { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
        public int AttackMax { get; set; }
        public int HealthPotionsAmount { get; set; }

        public Random rnd = new Random();

        //METHODS
        public virtual void GetStats()
        {
            Console.WriteLine($"Name: {Name} \n" +
                        $"Character Class: {CharacterClass} \n" +
                        $"Health: {Health} \n" +
                        $"Armor: {Armor}");
        }
        public abstract int Attack();
        public abstract int Block();
        public abstract int Defense();
        public abstract int RestoreHealth(int playerActualHealth, int healthPotionsAmount);

        public int SpecialAttack(int attack1, int attack2, int attack3, int specialAttackNumber)
        {
            if (specialAttackNumber > 0)
            {
                return (attack1 + attack2 + attack3) - 10;
            }
            else
            {
                return 0;
            }
        }
    }
}
