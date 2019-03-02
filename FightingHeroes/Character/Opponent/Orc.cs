using FightingHeroes.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingHeroes.Character.Opponent
{
    class Orc : Hero
    {
        public override int Attack()
        {
            return rnd.Next(1, AttackMax);
        }

        public override int Block()
        {
            return rnd.Next(1, Armor);
        }

        public override int Defense()
        {
            throw new NotImplementedException();
        }

        public override int DefenseRestoreHealth(int playerActualHealth)
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

            SoundEffect.GetSound(Resource.orc);
        }

        public override int RestoreHealth(int playerActualHealth)
        {
            throw new NotImplementedException();
        }
    }
}
