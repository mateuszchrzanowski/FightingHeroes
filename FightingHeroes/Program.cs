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
         * //Zamiast StartFight() w poniższym switchu uruchomię metodę Journey.StartJourney()
                    //będzie mały opis świata, może wybory WEST/EAST
                    //wewnątrz metody StartJourney() będzie wywoływanie metody StartFight z różnymi przeciwnikami
                    //np.: Battle.StartFight(warrior, orc), Battle.StartFight(warrior, troll)
                    //instancje klasy Hero dla przeciwników będą musiały być tworzone gdzie indziej.
                    //może w metodzie StartJourney()?
         * 
         * Będzie więcej przeciwników, których trzeba będzie poknować po kolei. 
         * 
         * 
         * Opponent : Hero
         * Properties: Name, Helath, Armor, AttackMax
         * Methods: Attack i Block na pewno
         * Potem np Orc : Hero; Troll : Hero; Skeleton : Hero; Zombie : Hero; Ancient Deamon : Hero itd
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
         * Updated StartJourney() method - added switch with directions. Added ChooseDirection() method - WORK IN PROGRESS
         * 
         */

        static void Main(string[] args)
        {
            /*
            Hero urukhai = new Orc()
            {
                Name = "Uruk-hai",
                CharacterClass = "Orc",
                Health = 30,
                Armor = 7,
                AttackMax = 11,
            };
            */

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

                    //Battle.StartFight(wizard, urukhai);
                    Journey.StartJourney(wizard);
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

                    //Battle.StartFight(warrior, urukhai);
                    break;
                    //Tutaj zamiast StartFight() uruchomię metodę Journey.StartJourney()
                    //będzie mały opis świata, może wybory WEST/EAST
                    //wewnątrz metody StartJourney() będzie wywoływanie metody StartFight z różnymi przeciwnikami
                    //np.: Battle.StartFight(warrior, orc), Battle.StartFight(warrior, troll)
                    //instancje klasy Hero dla przeciwników będą musiały być tworzone gdzie indziej.
                    //może w metodzie StartJourney()?
            }

            Console.ReadLine();
        }
    }
}
