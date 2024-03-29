﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimonGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minValue = 0;
            int maxValue = 0;
            int blankDelay = 45;
            int sayDelay = 0;
            string difficulty = "";
            bool difficultyIsSet = false;
            while (!difficultyIsSet)
            {
                Console.Write("Select a difficulty level? (easy, medium, hard)\n» ");
                difficulty = Console.ReadLine();
                switch (difficulty)
                {
                    case "easy":
                        maxValue = 10;
                        sayDelay = 5000;
                        difficultyIsSet = true;
                        break;
                    case "medium":
                        maxValue = 20;
                        sayDelay = 3000;
                        difficultyIsSet = true;
                        break;
                    case "hard":
                        maxValue = 30;
                        sayDelay = 1000;
                        difficultyIsSet = true;
                        break;
                    default:
                        Console.WriteLine($"ERROR: {difficulty} is not a valid difficulty level");
                        break;
                }
            }

            List<string> simonSequence = new List<string>();
            List<string> inputSequence = new List<string>();
            Random random = new Random();
            bool inputIsCorrect = true;
            while (inputIsCorrect)
            {
                simonSequence.Add(random.Next(minValue, maxValue).ToString());
                SaySequence(simonSequence, sayDelay, blankDelay);

                inputSequence.Clear();
                inputIsCorrect = true;
                for (int i = 0; i < simonSequence.Count; i++)
                {
                    Console.Write($"What was item #{i}\n» ");
                    inputSequence.Add(Console.ReadLine());
                    if (inputSequence[i] != simonSequence[i])
                    {
                        inputIsCorrect = false;
                        break;
                    }
                }
            }

            Console.WriteLine("Incorrect");
            Console.WriteLine("Simon\tYou\nsaid:\tsaid:");
            for (int i = 0; i < simonSequence.Count; i++)
            {
                Console.WriteLine($"{simonSequence[i]}\t{inputSequence.ElementAtOrDefault(i)}");
            }
            Console.WriteLine($"Your score was: {simonSequence.Count - 1}");
            PromptForKeyToExit();
        }

        private static void PromptForKeyToContinue(
            string message = "\nPress any key to continue . . . "
        )
        {
            Console.Write(message);
            Console.ReadKey(intercept: true);
            Console.WriteLine();
        }

        private static void PromptForKeyToExit(
            string message = "\nPress any key to exit . . . ",
            int exitCode = 0
        )
        {
            PromptForKeyToContinue(message);
            Environment.Exit(exitCode);
        }

        private static void SaySequence(
            IEnumerable<string> simonSequence,
            int sayDelay,
            int blankDelay = 0
        )
        {
            Console.Clear();
            foreach (string item in simonSequence)
            {
                Console.WriteLine("Simon says:");
                Task.Delay(blankDelay).Wait();
                Console.WriteLine(item);
                Task.Delay(sayDelay).Wait();
                Console.Clear();
            }
        }
    }
}
