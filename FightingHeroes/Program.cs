using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingHeroes
{
    class Program
    {
        //TODO:
        /* Commit
         * 
         * 
         * Zrobić klasę Opponent - będzie więcej przeciwników, których trzeba będzie poknować po kolei. 
         * 
         * Chyba będą dwie osobne klasy: Opponent i Hero.
         * Warrior i Wizard (i inne postacie do gry) będą dziedziczyc po Hero, a przeciwnicy po Opponent. 
         * Trzeba będzie przerobić klasę Battle.cs
         * 
         * Opponent : Hero
         * Properties: Name, Helath, Armor, AttackMax
         * Methods: Attack i Block na pewno
         * Potem np Orc : Opponent; Troll : Opponent; Skeleton : Opponent; Zombie : Opponent; Ancient Deamon : Opponent itd
         * 
         * Droga do bossa. Opisy i wybory gdzie chcesz iść (np. East or West).
         * 
         * Health nie będzie się odnawiać po każdym przeciwniku. Zrobimy za to Life Potion.
         * Będzie można odnowić Health (albo na maxa albo np +5. jescze nie wiem)
         * 
         * Zrobić tryb multiplayer
         * 
         * zrobić więcej postaci
         * 
         * 
        */

        //DONE:
        /*
         * Added CharacterClass property in Hero class,
         * Edited GetStats method (changed abstract to virtual),
         * Deleted useless, commented code.
         * 
         */

        static void Main(string[] args)
        {
            Hero urukhai = new Orc()
            {
                Name = "Uruk-hai",
                CharacterClass = "Orc",
                Health = 30,
                Armor = 7,
                AttackMax = 11,
            };

            switch (Intro.StartGame())
            {
                case "wizard":
                    Hero wizard = new Wizard()
                    {
                        Name = Intro.GetName(),
                        CharacterClass = "Wizard",
                        Health = 30,
                        Armor = 7,
                        FireballAttackMax = 13,
                        LightningAttackMax = 15,
                        WildFireAttackMax = 17,
                    };
                    wizard.GetStats();

                    Battle.StartFight(wizard, urukhai);
                    break;
                case "warrior":
                    Hero warrior = new Warrior()
                    {
                        Name = Intro.GetName(),
                        CharacterClass = "Warrior",
                        Health = 35,
                        Armor = 8,
                        SwordAttackMax = 10,
                        AxeAttackMax = 12,
                        MaceAttackMax = 15,
                    };
                    warrior.GetStats();

                    Battle.StartFight(warrior, urukhai);
                    break;
            }

            Console.ReadLine();
        }
    }
}
