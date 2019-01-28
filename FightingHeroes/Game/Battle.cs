using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingHeroes
{
    class Battle
    {
        //METHODS
        public static void StartFight(Hero hero1, Hero hero2)
        {
            int roundNumber = 0;

            Console.WriteLine("Prepare to Fight! \n" +
                                "[Press any key]");
            Console.ReadKey();
            Console.WriteLine();

            hero2.GetStats();

            while (true)
            {
                roundNumber++;
                Console.WriteLine($"-----------Round: {roundNumber}-------------");
                if (GetAction() == "attack")
                {
                    if (GetAttackResult(hero1, hero2) == "Game Over!")
                    {
                        Console.WriteLine("Game Over!");
                        break;
                    }
                    else if (GetAttackResult(hero2, hero1) == "Game Over!")
                    {
                        Console.WriteLine("Game Over!");
                        break;
                    }
                    Console.WriteLine($"\n{hero1.Name} <H: {hero1.Health}>");
                    Console.WriteLine($"{hero2.Name} <H: {hero2.Health}>\n");
                }
                else
                {
                    if(GetDefenseResult(hero1, hero2) == "Game Over!")
                    {
                        Console.WriteLine("Game Over!");
                        break;
                    }
                    Console.WriteLine($"\n{hero1.Name} <H: {hero1.Health}>");
                    Console.WriteLine($"{hero2.Name} <H: {hero2.Health}>\n");
                }
            }
        }

        public static string GetAction()
        {
            string actionType = "";

            do
            {
                Console.WriteLine("Select your action: \n" +
                "[1] Attack \n" +
                "[2] Defensife position");

                ConsoleKeyInfo action = Console.ReadKey();

                switch (action.KeyChar)
                {
                    case '1':
                        Console.WriteLine();
                        actionType = "attack";
                        break;
                    case '2':
                        Console.WriteLine();
                        actionType = "defense";
                        break;
                    default:
                        actionType = "error";
                        Console.WriteLine();
                        Console.WriteLine("\nWrong input. Please try again.\n");
                        break;
                }
            }
            while (actionType == "error");

            return actionType;
        }

        public static string GetAttackResult(Hero heroA, Hero heroB)
        {
            int heroAAttack = heroA.Attack();
            int heroBBlock = heroB.Block();
            int dealedDamage = heroAAttack - heroBBlock;

            if(dealedDamage > 0)
            {
                heroB.Health = heroB.Health - dealedDamage;
            }
            else
            {
                dealedDamage = 0;
            }

            Console.WriteLine($"\n{heroA.Name} attacks {heroB.Name} ({heroAAttack})");
            Console.WriteLine($"{heroB.Name} blocks ({heroBBlock})");
            Console.WriteLine($"{heroA.Name} deals damage ({dealedDamage})");

            if (heroB.Health <= 0)
            {
                Console.WriteLine();
                Console.WriteLine($"{heroA.Name} <H: {heroA.Health}>");
                Console.WriteLine($"{heroB.Name} <H: {heroB.Health}>");

                Console.WriteLine();
                Console.WriteLine($"{heroB.Name} died! {heroA.Name} is victorius!");
                return "Game Over!";
            }
            else
            {
                return "Fight Again!";
            }
        }

        public static string GetDefenseResult(Hero heroA, Hero heroB)
        {
            int heroADefense = heroA.Defense();
            int heroBAttack = heroB.Attack();
            int dealedDamage = heroBAttack - heroADefense;

            if (dealedDamage > 0)
            {
                heroA.Health = heroA.Health - dealedDamage;
            }
            else
            {
                dealedDamage = 0;
            }

            Console.WriteLine($"\n{heroA.Name} gets defensive position. He is able to use his max armor ({heroA.Armor})\n");

            Console.WriteLine($"{heroB.Name} attacks {heroA.Name} ({heroBAttack})");
            Console.WriteLine($"{heroA.Name} blocks ({heroADefense})");
            Console.WriteLine($"{heroB.Name} deals damage ({dealedDamage})");

            if (heroA.Health <= 0)
            {
                Console.WriteLine();
                Console.WriteLine($"{heroA.Name} <H: {heroA.Health}>");
                Console.WriteLine($"{heroB.Name} <H: {heroB.Health}>");

                Console.WriteLine();
                Console.WriteLine($"{heroA.Name} died! {heroB.Name} is victorius!");
                return "Game Over!";
            }
            else
            {
                return "Fight Again!";
            }
        }
    }
}
