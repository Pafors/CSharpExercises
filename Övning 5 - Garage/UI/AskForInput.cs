using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5_Garage.UI
{
    internal class AskForInput
    {
        IUI ui;
        public AskForInput(IUI ui)
        {
            this.ui = ui;
        }

        public string GetString(string inputPrompt)
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
                    ui.OutputData("*** Felaktig inmatning, försök igen\n");
                };
            }
            while (true);
        }

        public string GetFromSelectionString(string inputPrompt, List<string> selection)
        {
            do
            {
                var userInput = GetString(inputPrompt);
                if(selection.Contains(userInput, StringComparer.OrdinalIgnoreCase)) { return userInput; }
                ui.OutputData("*** Finns inte som valmöjlighet, försök igen");
            } while (true);
        }
        public string GetFromUnSelectionString(string inputPrompt, List<string> nonSelection)
        {
            do
            {
                var userInput = GetString(inputPrompt);
                if(!nonSelection.Contains(userInput, StringComparer.OrdinalIgnoreCase)) { return userInput; }
                ui.OutputData("*** Finns redan, skriv ett nytt");
            } while (true);
        }

        public int GetInt(string inputPrompt)
        {
            do
            {
                // Check that the received input is a valid number (valid uint)
                if (int.TryParse(GetString(inputPrompt), out int userInput))
                {
                    return userInput;
                }
                else
                {
                    ui.OutputData("*** Felaktigt värde, försök igen\n");
                }
            }
            while (true);
        }
        public double GetDouble(string inputPrompt)
        {
            do
            {
                // Check that the received input is a valid number (valid uint)
                if (double.TryParse(GetString(inputPrompt), out double userInput))
                {
                    return userInput;
                }
                else
                {
                    ui.OutputData("*** Felaktigt värde, försök igen\n");
                }
            }
            while (true);
        }

        public bool ConfirmYes(string confirmPrompt)
        {
            string confirmExit = GetString(confirmPrompt);
            if (confirmExit.ToLower() == "j" || confirmExit.ToLower() == "ja")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public (string Command, string[]? Args) GetCommand()
        {
            var commandArgs = GetString("Command> ").Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[]? args;
            if (commandArgs.Length < 1)
            {
                args = null;
            }
            else
            {
                args = commandArgs[1..];
            }
            return (Command: commandArgs[0].ToLower(), Args: args);
        }
    }
}
