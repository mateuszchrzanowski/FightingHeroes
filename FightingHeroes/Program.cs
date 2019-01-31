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
         * Po Battle.StartFight() nie będzie końca gry. W klasie Journey.cs można pociągnąć grę dalej.
         * w każdej metodzie ...Scenario() po wywołaniu Battle.StartFight() wrzucimy kolejny wybór drogi
         * 
         * //Zamiast StartFight() w poniższym switchu uruchomię metodę Journey.StartJourney()
                    //będzie mały opis świata, może wybory WEST/EAST
                    //wewnątrz metody StartJourney() będzie wywoływanie metody StartFight z różnymi przeciwnikami
                    //np.: Battle.StartFight(warrior, orc), Battle.StartFight(warrior, troll)
                    //instancje klasy Hero dla przeciwników będą musiały być tworzone gdzie indziej.
                    //może w metodzie StartJourney()?
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
         * 
         * Updated Journey.cs class - added GetMountainsScenario() and GetSwampsScenario() methods.
         * Deleted ChooseDirection() method.
         * Deleted Opponent.cs class.
         * Deleted useless commented code.
         * 
         */

        static void Main(string[] args)
        {
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
                    Journey.StartJourney(warrior);
                    break;
            }

            Console.ReadLine();
        }
    }
}
