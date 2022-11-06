using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTwoFlowLoopsAndStringManipulation
{
    static class Utilities
    {
        public static string getStringInput(string inputPrompt)
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

        public static uint getUintInput(string inputPrompt)
        {
            do
            {

                if (uint.TryParse(getStringInput(inputPrompt), out uint userInput))
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
    
        public static bool confirm(string confirmPrompt)
        {
            string confirmExit = getStringInput(confirmPrompt);
            if (confirmExit.ToLower() == "j")
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
