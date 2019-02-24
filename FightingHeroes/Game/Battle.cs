using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightingHeroes.Sound;

namespace FightingHeroes
{
    class Battle
    {
        //METHODS
        public static string StartFight(Hero hero1, Hero hero2)
        {
            int roundNumber = 0;

            Console.WriteLine("Prepare to Fight! \n" +
                                "[Press any key]");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine();

            hero2.GetStats();

            while (true)
            {
                roundNumber++;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"-------------Round: {roundNumber}-------------");
                Console.ResetColor();
                string getAction = GetAction(hero1);
                if (getAction == "attack")
                {
                    if (GetAttackResult(hero1, hero2) == "Game Over!")
                    {
                        return "You Win!";
                    }
                    else if (GetAttackResult(hero2, hero1) == "Game Over!")
                    {
                        return "Game Over!";
                    }

                    Console.ForegroundColor = ConsoleColor.DarkRed;

                    Console.WriteLine($"\n{hero1.Name} <H: {hero1.Health}>");
                    Console.WriteLine($"{hero2.Name} <H: {hero2.Health}>\n");

                    Console.ResetColor();
                }
                else if (getAction == "defense")
                {
                    if (GetDefenseResult(hero1, hero2) == "Game Over!")
                    {
                        return "Game Over!";
                    }

                    Console.ForegroundColor = ConsoleColor.DarkRed;

                    Console.WriteLine($"\n{hero1.Name} <H: {hero1.Health}>");
                    Console.WriteLine($"{hero2.Name} <H: {hero2.Health}>\n");

                    Console.ResetColor();
                }
                else if (getAction == "health")
                {
                    if (GetHealthPotionResult(hero1, hero2) == "Game Over!")
                    {
                        return "Game Over!";
                    }

                    Console.ForegroundColor = ConsoleColor.DarkRed;

                    Console.WriteLine($"\n{hero1.Name} <H: {hero1.Health}>");
                    Console.WriteLine($"{hero2.Name} <H: {hero2.Health}>\n");

                    Console.ResetColor();
                }
                if (getAction == "special")
                {
                    if (GetSpecialAttackResult(hero1, hero2) == "Game Over!")
                    {
                        return "You Win!";
                    }
                    else if (GetAttackResult(hero2, hero1) == "Game Over!")
                    {
                        return "Game Over!";
                    }

                    Console.ForegroundColor = ConsoleColor.DarkRed;

                    Console.WriteLine($"\n{hero1.Name} <H: {hero1.Health}>");
                    Console.WriteLine($"{hero2.Name} <H: {hero2.Health}>\n");

                    Console.ResetColor();
                }
            }
        }

        public static string GetAction(Hero hero)
        {
            string actionType = "";

            do
            {
                Console.WriteLine("Select your action: \n" +
                "[1] Attack \n" +
                "[2] Defensive position \n" +
                $"[3] Health Potion ({hero.HealthPotionsAmount})" +
                $"[4] Special Attack ({hero.SpecialAttackNumber})");

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
                    case '3':
                        if(hero.HealthPotionsAmount > 0)
                        {
                            Console.WriteLine();
                            SoundEffect.GetSound(Resource.potion);
                            actionType = "health";
                            break;
                        }
                        else
                        {
                            actionType = "error";
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("\nYou don't have any Health Potions! Please select other action.\n");
                            Console.ResetColor();
                            break;
                        }
                    case '4':
                        if (hero.SpecialAttackNumber > 0)
                        {
                            Console.WriteLine();
                            //SoundEffect.GetSound(Resource.potion);
                            actionType = "special";
                            break;
                        }
                        else
                        {
                            actionType = "error";
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("\nYou don't have enough power to use your special attack. Please select other action.\n");
                            Console.ResetColor();
                            break;
                        }
                    default:
                        actionType = "error";
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("\nWrong input. Please try again.\n");
                        Console.ResetColor();
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

            if (dealedDamage > 0)
            {
                heroB.Health = heroB.Health - dealedDamage;
            }
            else
            {
                dealedDamage = 0;
            }

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.WriteLine($"\n{heroA.Name} attacks {heroB.Name} ({heroAAttack})");
            Console.WriteLine($"{heroB.Name} blocks ({heroBBlock})");
            Console.WriteLine($"{heroA.Name} deals damage ({dealedDamage})");

            if (heroB.Health <= 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;

                Console.WriteLine();
                Console.WriteLine($"{heroA.Name} <H: {heroA.Health}>");
                Console.WriteLine($"{heroB.Name} <H: {heroB.Health}>");

                Console.ForegroundColor = ConsoleColor.DarkGreen;

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

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.WriteLine($"\n{heroA.Name} gets defensive position. He is able to use his max armor ({heroA.Armor})\n");

            Console.WriteLine($"{heroB.Name} attacks {heroA.Name} ({heroBAttack})");
            Console.WriteLine($"{heroA.Name} blocks ({heroADefense})");
            Console.WriteLine($"{heroB.Name} deals damage ({dealedDamage})");

            if (heroA.Health <= 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;

                Console.WriteLine();
                Console.WriteLine($"{heroA.Name} <H: {heroA.Health}>");
                Console.WriteLine($"{heroB.Name} <H: {heroB.Health}>");

                Console.ForegroundColor = ConsoleColor.DarkGreen;

                Console.WriteLine();
                Console.WriteLine($"{heroA.Name} died! {heroB.Name} is victorius!");
                return "Game Over!";
            }
            else
            {
                return "Fight Again!";
            }
        }

        public static string GetSpecialAttackResult(Hero heroA, Hero heroB)
        {
            int heroASpecialAttack = heroA.SpecialAttack(heroA.SpecialAttackNumber);
            int heroBBlock = heroB.Block();
            int dealedDamage = heroASpecialAttack - heroBBlock;

            if (dealedDamage > 0)
            {
                heroB.Health = heroB.Health - dealedDamage;
            }
            else
            {
                dealedDamage = 0;
            }

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.WriteLine($"\n{heroA.Name} attacks {heroB.Name} ({heroASpecialAttack})");
            Console.WriteLine($"{heroB.Name} blocks ({heroBBlock})");
            Console.WriteLine($"{heroA.Name} deals damage ({dealedDamage})");

            if (heroB.Health <= 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;

                Console.WriteLine();
                Console.WriteLine($"{heroA.Name} <H: {heroA.Health}>");
                Console.WriteLine($"{heroB.Name} <H: {heroB.Health}>");

                Console.ForegroundColor = ConsoleColor.DarkGreen;

                Console.WriteLine();
                Console.WriteLine($"{heroB.Name} died! {heroA.Name} is victorius!");
                return "Game Over!";
            }
            else
            {
                return "Fight Again!";
            }
        }

        public static string GetHealthPotionResult(Hero heroA, Hero heroB)
        {
            int heroABlock = heroA.Block();
            int heroBAttack = heroB.Attack();
            int dealedDamage = heroBAttack - heroABlock;

            heroA.RestoreHealth(heroA.Health, heroA.HealthPotionsAmount);
            heroA.HealthPotionsAmount--;

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.WriteLine($"\n{heroA.Name} uses Health Potion. He restored 5 health points. \n");


            Console.ForegroundColor = ConsoleColor.DarkRed;

            Console.WriteLine($"{heroA.Name} <H: {heroA.Health}> \n");

            Console.ResetColor();

            if (dealedDamage > 0)
            {
                heroA.Health = heroA.Health - dealedDamage;
            }
            else
            {
                dealedDamage = 0;
            }

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.WriteLine($"{heroB.Name} attacks {heroA.Name} ({heroBAttack})");
            Console.WriteLine($"{heroA.Name} blocks ({heroABlock})");
            Console.WriteLine($"{heroB.Name} deals damage ({dealedDamage})");

            if (heroA.Health <= 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;

                Console.WriteLine();
                Console.WriteLine($"{heroA.Name} <H: {heroA.Health}>");
                Console.WriteLine($"{heroB.Name} <H: {heroB.Health}>");

                Console.ForegroundColor = ConsoleColor.DarkGreen;

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
