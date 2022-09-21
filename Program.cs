using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimonGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double difficulty = PromptParseDouble(
                "What is you're difficulty factor? (0 = easy, 1 = medium, 2+ = hard. Decimals are okay.)"
            );
            while (difficulty < 0)
            {
                difficulty = PromptParseDouble("No negative numbers, please.");
            }
            int minValue = 0;
            int maxValue = (int)Math.Pow(10, difficulty + 1) - 1; // 9, 99, 999, ...
            int blankDelay = 45;
            int sayDelay = (int)(3000 * Math.Pow(2, -difficulty)) + 45; // 3000, 1500, 750, ...

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

        private static double PromptParseDouble(string promptString)
        {
            double returnVal;
            Console.Write($"{promptString}\n» ");
            while (!double.TryParse(Console.ReadLine(), out returnVal))
            {
                Console.Write($"ERROR: Input was not in the correct format.\n{promptString}:\n» ");
            }
            return returnVal;
        }
    }
}
