using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingHeroes
{
    class Zombie : Hero
    {
        public override int Attack()
        {
            return rnd.Next(4, AttackMax);
        }

        public override int Block()
        {
            return rnd.Next(4, Armor);
        }

        public override int Defense()
        {
            throw new NotImplementedException();
        }

        public override void GetStats()
        {
            Console.WriteLine("YOUR OPPONENT:");
            base.GetStats();
            Console.WriteLine($"Max Attack: {AttackMax} \n" +
                        $"<H: {Health} | A: {Armor} | MA: {AttackMax}> \n\n");
        }
    }
}
