using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingHeroes.Character.Opponent
{
    class Manticore : Hero
    {
        public override int Attack()
        {
            return rnd.Next(3, AttackMax);
        }

        public override int Block()
        {
            return rnd.Next(3, Armor);
        }

        public override int Defense()
        {
            throw new NotImplementedException();
        }

        public override void GetStats()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("YOUR OPPONENT:");
            base.GetStats();
            Console.WriteLine($"Max Attack: {AttackMax} \n" +
                        $"<H: {Health} | A: {Armor} | MA: {AttackMax}> \n\n");
            Console.ResetColor();
        }

        public override int RestoreHealth(int playerActualHealth, int healthPotionsAmount)
        {
            throw new NotImplementedException();
        }
    }
}
