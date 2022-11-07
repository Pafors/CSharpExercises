using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTwoFlowLoopsAndStringManipulation
{
    static class Utilities
    {
        public static string GetStringInput(string inputPrompt, IUI ui)
        {
            do
            {
                
                ui.OutputData(inputPrompt);
                string userInput = ui.InputData();
                if (!string.IsNullOrWhiteSpace(userInput))
                {
                    return userInput;
                }
                else
                {
                    ui.OutputData("Felaktig inmatning, försök igen");
                };
            }
            while (true);
        }

        public static uint GetUintInput(string inputPrompt, IUI ui)
        {
            do
            {
                // Check that the received input is a valid number (valid uint)
                if (uint.TryParse(GetStringInput(inputPrompt, ui), out uint userInput))
                {
                    return userInput;
                }
                else
                {
                    ui.OutputData("Felaktigt värde, försök igen");
                }
            }
            while (true);
        }
    
        public static bool Confirm(string confirmPrompt, IUI ui)
        {
            string confirmExit = GetStringInput(confirmPrompt, ui);
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
