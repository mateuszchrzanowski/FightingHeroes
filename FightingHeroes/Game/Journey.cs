using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingHeroes
{
    class Journey
    {
        public static string StartJourney(Hero playerHero)
        {
            string userDirectionChoice;
            string userDirectionChoiceResult = "";

            Console.WriteLine("Beggin your Journey! \n" +
                "[Press any key]");

            Console.ReadKey();
            Console.WriteLine();

            Console.WriteLine("You have been banished from your hometown. \n" +
                "Now you are standing in the middle of deep dark woods. \n" +
                "You can go east into to the MOUNTAINS or west to the SWAMPS near the old burial ground.\n");

            do
            {
                Console.WriteLine("Choose direction of your journey: \n" +
                "[M] Mountains \n" +
                "[S] Swamps");

                userDirectionChoice = Console.ReadKey().Key.ToString();
                Console.WriteLine();

                switch (userDirectionChoice.ToUpper())
                {
                    case "M":
                        userDirectionChoiceResult = "mountains";
                        GetMountainsScenario(playerHero);
                        break;
                    case "S":
                        userDirectionChoiceResult = "swamps";
                        GetSwampsScenario(playerHero);
                        break;
                    default:
                        userDirectionChoiceResult = "error";
                        Console.WriteLine("\nWrong input. Please try again. \n");
                        break;
                }
            }
            while (userDirectionChoiceResult == "error");

            return userDirectionChoiceResult;
            
        }

        public static void GetMountainsScenario(Hero playerHero)
        {
            Console.WriteLine("\nIn the mountains you are attacked by a troll! \n" +
                "You have to defend yourself!");
            Console.WriteLine();

            Hero troll = new Troll()
            {
                Name = "Garatah",
                CharacterClass = "Troll",
                Health = 35,
                Armor = 5,
                AttackMax = 12,
            };

            Battle.StartFight(playerHero, troll);

            Console.WriteLine("Do you wanna play further?");
            Console.ReadKey();
        }

        public static void GetSwampsScenario(Hero playerHero)
        {
            Console.WriteLine("\nIn the swamps you are attacked by a orc! \n" +
                "You have to defend yourself!");
            Console.WriteLine();

            Hero orc = new Orc()
            {
                Name = "Uruk-hai",
                CharacterClass = "Orc",
                Health = 30,
                Armor = 7,
                AttackMax = 11,
            };

            Battle.StartFight(playerHero, orc);
        }
    }
}
