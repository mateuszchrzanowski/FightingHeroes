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
                "You can go east into to the MOUNTAINS or west to the SWAMPS near the old burial ground.");

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
                        MountainsSwampsJourney(playerHero);
                        break;
                    case "S":
                        userDirectionChoiceResult = "swamps";
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

        public static void ChooseDirection()
        {
            string userDirectionChoice;
            string userDirectionChoiceResult = "";

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
                        Console.WriteLine("In the mountains you are attacked by an orc!");
                        Hero urukhai = new Orc()
                        {
                            Name = "Uruk-hai",
                            CharacterClass = "Orc",
                            Health = 30,
                            Armor = 7,
                            AttackMax = 11,
                        };
                        Battle.StartFight(playerHero, urukhai);
                        break;
                    case "S":
                        userDirectionChoiceResult = "swamps";
                        break;
                    default:
                        userDirectionChoiceResult = "error";
                        Console.WriteLine("\nWrong input. Please try again. \n");
                        break;
                }
            }
            while (userDirectionChoiceResult == "error");
        }

        /*
        public static string MountainsSwampsJourney(Hero playerHero, string direction)
        {
            switch (StartJourney(playerHero))
            {
                case "mountains":
                    Console.WriteLine("In the mountains you are attacked by an orc!");
                    Hero urukhai = new Orc()
                    {
                        Name = "Uruk-hai",
                        CharacterClass = "Orc",
                        Health = 30,
                        Armor = 7,
                        AttackMax = 11,
                    };
                    Battle.StartFight(playerHero, urukhai);
                    break;
            }

            return "return";
        }
        */
    }
}
