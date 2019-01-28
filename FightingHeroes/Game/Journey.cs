using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingHeroes.Game
{
    class Journey
    {
        public static void StartJourney(Hero hero)
        {
            Console.WriteLine("Beggin your Journey! \n" +
                "[Press any key]");

            Console.ReadKey();
            Console.WriteLine();

            Console.WriteLine("You have been banished from your hometown. \n" +
                "Now you are standing in the middle of deep dark woods. \n" +
                "You can go EAST into to the mountains or WEST to the swamps near the old burial ground.");

            Console.WriteLine("[E] - Mountains \n" +
                "[W] - Swamps");
        }
    }
}
