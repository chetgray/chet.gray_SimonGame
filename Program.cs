using System;
using System.Collections.Generic;

namespace SimonGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> simonSequence = new List<string>();
            int minValue = 0;
            int maxValue = 9;
            Random random = new Random();

            bool inputIsCorrect = true;
            while (inputIsCorrect)
            {
                simonSequence.Add(random.Next(minValue, maxValue).ToString());
                PromptForKeyToContinue();
            }
            Console.WriteLine("Incorrect");
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
    }
}
