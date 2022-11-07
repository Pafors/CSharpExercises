using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTwoFlowLoopsAndStringManipulation
{
    static class Utilities
    {
        public static string GetStringInput(string inputPrompt)
        {
            do
            {
                // Selected to use "Write" instead of "WriteLine" for more flexibility, you can always add an '\n' if needed
                Console.Write(inputPrompt);
                string userInput = Console.ReadLine()!;
                if (!string.IsNullOrWhiteSpace(userInput))
                {
                    return userInput;
                }
                else
                {
                    Console.WriteLine("Felaktig inmatning, försök igen");
                };
            }
            while (true);
        }

        public static uint GetUintInput(string inputPrompt)
        {
            do
            {
                // Check that the received input is a valid number (valid uint)
                if (uint.TryParse(GetStringInput(inputPrompt), out uint userInput))
                {
                    return userInput;
                }
                else
                {
                    Console.WriteLine("Felaktigt värde, försök igen");
                }
            }
            while (true);
        }
    
        public static bool Confirm(string confirmPrompt)
        {
            string confirmExit = GetStringInput(confirmPrompt);
            if (confirmExit.ToLower() == "j" || confirmExit.ToLower() == "ja")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
