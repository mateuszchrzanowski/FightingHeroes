﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace FightingHeroes
{
    static class Intro
    {
        //METHODS
        public static string StartGame()
        {
            string userCharacterChoice;
            string userCharacterChoiceResult = "";
            var startMusic = new SoundPlayer();
            startMusic.SoundLocation = @"D:\MCh\kody\CSharp\FightingHeroes\FightingHeroes\Sound\GOT2.wav";
            startMusic.Play();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("### Fighting Heroes ###\n");
            Console.ResetColor();

            do
            {
                Console.WriteLine("Choose your character: \n" +
                "[W] WARRIOR\n" +
                "[D] WIZARD \n" +
                "[H] HUNTER");

                userCharacterChoice = Console.ReadKey().Key.ToString();
                Console.WriteLine();

                switch (userCharacterChoice.ToUpper())
                {
                    case "D":
                        userCharacterChoiceResult = "wizard";
                        break;
                    case "W":
                        userCharacterChoiceResult = "warrior";
                        break;
                    case "H":
                        userCharacterChoiceResult = "hunter";
                        break;
                    default:
                        userCharacterChoiceResult = "error";
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("\nWrong input. Please try again. \n");
                        Console.ResetColor();
                        break;
                }
            }
            while (userCharacterChoiceResult == "error");

            return userCharacterChoiceResult;

        }

        public static string GetName()
        {
            string characterName;

            do
            {
                Console.WriteLine("\nEnter your character's name (3-15 chars):");
                characterName = Console.ReadLine();
            }
            while (characterName.Length > 15 || characterName.Length < 3);

            return characterName;
        }
    }
}
