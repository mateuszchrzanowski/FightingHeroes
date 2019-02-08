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
        public abstract int RestoreHealth(int health);  
    }
}
