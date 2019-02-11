using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightingHeroes.Character.Opponent;

namespace FightingHeroes
{
    class Journey
    {
        public static string StartJourney(Hero playerHero)
        {
            string userDirectionChoice;
            string userDirectionChoiceResult = "";

            Console.WriteLine("Begin your Journey! \n" +
                "[Press any key]");

            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You have been banished from your hometown. \n" +
                "Now you are standing in the middle of deep dark forest. \n" +
                "You can go east into to the MOUNTAINS or west to the SWAMPS near the old burial ground.\n");
            Console.ResetColor();

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

        public static string GetMountainsScenario(Hero playerHero)
        {
            string userDirectionChoice;
            string userDirectionChoiceResult = "";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nIn the mountains you are attacked by a troll! \n" +
                "You have to defend yourself!");
            Console.ResetColor();
            Console.WriteLine();

            Hero troll = new Troll()
            {
                Name = "Garatah",
                CharacterClass = "Troll",
                Health = 35,
                Armor = 5,
                AttackMax = 12,
            };

            //Battle.StartFight(playerHero, troll);

            if(IsHeroAlive(playerHero, troll))
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You have defeated mighty troll from the mountains.\n" +
                    "Now you can continue your journey.\n" +
                    "You can go north to the ANCIENT CAVE or west to the SWAMPS near the old burial ground.\n");
                Console.ResetColor();
            }
            else
            {
                GetDefeatedInfo();
                /*
                Console.WriteLine("You have been defeated! \n" +
                    "[Press any key to exit game]");
                Console.ReadKey();

                Environment.Exit(0);
                */
            }
            

            do
            {
                Console.WriteLine("Choose direction of your journey: \n" +
                "[C] Ancient Cave \n" +
                "[S] Swamps");

                userDirectionChoice = Console.ReadKey().Key.ToString();
                Console.WriteLine();

                switch (userDirectionChoice.ToUpper())
                {
                    case "C":
                        userDirectionChoiceResult = "cave";
                        GetCaveScenario(playerHero);
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

        public static string GetSwampsScenario(Hero playerHero)
        {
            string userDirectionChoice;
            string userDirectionChoiceResult = "";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nIn the swamps you are attacked by an orc! \n" +
                "You have to defend yourself!");
            Console.ResetColor();
            Console.WriteLine();

            Hero orc = new Orc()
            {
                Name = "Uruk-hai",
                CharacterClass = "Orc",
                Health = 30,
                Armor = 7,
                AttackMax = 11,
            };

            //Battle.StartFight(playerHero, orc);

            if (IsHeroAlive(playerHero, orc))
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You have defeated wild orc from the swamps.\n" +
                    "Now you can continue your journey.\n" +
                    "You can go north to the OLD BURIAL GROUND or east into the MOUNTAINS.\n");
                Console.ResetColor();
            }
            else
            {
                GetDefeatedInfo();

                /*
                Console.WriteLine("You have been defeated! \n" +
                    "[Press any key to exit game]");
                Console.ReadKey();

                Environment.Exit(0);
                */
            }

            do
            {
                Console.WriteLine("Choose direction of your journey: \n" +
                "[B] Old Burial Ground \n" +
                "[M] Mountains");

                userDirectionChoice = Console.ReadKey().Key.ToString();
                Console.WriteLine();

                switch (userDirectionChoice.ToUpper())
                {
                    case "B":
                        userDirectionChoiceResult = "burial";
                        GetBurialScenario(playerHero);
                        break;
                    case "M":
                        userDirectionChoiceResult = "mountains";
                        GetMountainsScenario(playerHero);
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

        public static string GetCaveScenario(Hero playerHero)
        {
            string userDirectionChoice;
            string userDirectionChoiceResult = "";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nInside the ancient cave you are attacked by a manticore! \n" +
                "You have to defend yourself!");
            Console.ResetColor();
            Console.WriteLine();

            Hero manticore = new Manticore()
            {
                Name = "Falazad",
                CharacterClass = "Manticore",
                Health = 40,
                Armor = 3,
                AttackMax = 12,
            };

            //Battle.StartFight(playerHero, manticore);

            if (IsHeroAlive(playerHero, manticore))
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You have defeated great manticore from the ancient cave.\n" +
                    "Now you can continue your journey.\n" +
                    "You can go west to the OLD BURIAL GROUND or south into the MOUNTAINS.\n");
                Console.ResetColor();
            }
            else
            {
                GetDefeatedInfo();

                /*
                Console.WriteLine("You have been defeated! \n" +
                    "[Press any key to exit game]");
                Console.ReadKey();

                Environment.Exit(0);
                */
            }

            do
            {
                Console.WriteLine("Choose direction of your journey: \n" +
                "[B] Old Burial Ground \n" +
                "[M] Mountains");

                userDirectionChoice = Console.ReadKey().Key.ToString();
                Console.WriteLine();

                switch (userDirectionChoice.ToUpper())
                {
                    case "B":
                        userDirectionChoiceResult = "burial";
                        GetBurialScenario(playerHero);
                        break;
                    case "M":
                        userDirectionChoiceResult = "mountains";
                        GetMountainsScenario(playerHero);
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

        public static string GetBurialScenario(Hero playerHero)
        {
            string userDirectionChoice;
            string userDirectionChoiceResult = "";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nIn the old burial ground you are attacked by a Zombie! \n" +
                "You have to defend yourself!");
            Console.ResetColor();
            Console.WriteLine();

            Hero zombie = new Zombie()
            {
                Name = "Halath",
                CharacterClass = "Zombie",
                Health = 45,
                Armor = 3,
                AttackMax = 13,
            };

            //Battle.StartFight(playerHero, zombie);

            if (IsHeroAlive(playerHero, zombie))
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You have defeated rotten zombie from the old burial ground.\n" +
                    "Now you can continue your journey.\n" +
                    "You can go east to the ANCIET CAVE or south into the SWAMPS.\n");
                Console.ResetColor();
            }
            else
            {
                GetDefeatedInfo();

                /*
                Console.WriteLine("You have been defeated! \n" +
                    "[Press any key to exit game]");
                Console.ReadKey();

                Environment.Exit(0);
                */
            }

            do
            {
                Console.WriteLine("Choose direction of your journey: \n" +
                "[C] Ancient Cave \n" +
                "[S] Swamps");

                userDirectionChoice = Console.ReadKey().Key.ToString();
                Console.WriteLine();

                switch (userDirectionChoice.ToUpper())
                {
                    case "C":
                        userDirectionChoiceResult = "Ancient Cave";
                        GetCaveScenario(playerHero);
                        break;
                    case "S":
                        userDirectionChoiceResult = "Swamps";
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

        public static bool IsHeroAlive(Hero playerHero, Hero opponent)
        {
            if (Battle.StartFight(playerHero, opponent) == "Game Over!")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void GetDefeatedInfo()
        {
            Console.WriteLine("\nYou have been defeated! \n" +
                    "[Press any key to exit game]");
            Console.ReadKey();

            Environment.Exit(0);
        }
    }
}
