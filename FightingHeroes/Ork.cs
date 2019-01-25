using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingHeroes
{
    class Ork : Hero
    {
        public override int Attack()
        {
            return rnd.Next(1, AttackMax);
        }

        public override int Block()
        {
            return rnd.Next(1, BlockMax);
        }
    }
}
