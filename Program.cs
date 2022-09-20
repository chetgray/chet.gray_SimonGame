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
            List<string> simonSequence = new List<string>();
            List<string> inputSequence = new List<string>();
            int minValue = 0;
            int maxValue = 9;
            int sayDelay = 3000;
            Random random = new Random();

            bool inputIsCorrect = true;
            while (inputIsCorrect)
            {
                simonSequence.Add(random.Next(minValue, maxValue).ToString());
                SaySequence(simonSequence, sayDelay);

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

        private static void SaySequence(IEnumerable<string> simonSequence, int sayDelay)
        {
            Console.Clear();
            foreach (string item in simonSequence)
            {
                Console.WriteLine($"Simon says:\n{item}");
                Task.Delay(sayDelay).Wait();
                Console.Clear();
            }
        }
    }
}
