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
            // Standaed get string from user
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
                    ui.OutputData("*** FELAKTIG INMATNING, FÖRSÖK IGEN\n");
                };
            }
            while (true);
        }
        public string GetFromSelectionString(string inputPrompt, List<string> selection)
        {
            // Get string, but string is only valid if the input is one of the "selection"
            do
            {
                var userInput = GetString(inputPrompt);
                if (selection.Contains(userInput, StringComparer.OrdinalIgnoreCase)) { return userInput; }
                ui.OutputData("*** FINNS INTE SOM VALMÖJLIGHET, FÖRSÖK IGEN\n");
            } while (true);
        }
        public string GetMultipleFromSelectionString(string inputPrompt, List<string> selection)
        {
            // Get multiple strings, but string is only valid if the "selection" contains any of the input in any order
            // Example of valid: inputstring is "123 abc" and selection is "abc def 123"
            // Example of nonvalid: inputstring is "123 abc zxc" and selection is "abc def 123"
            do
            {
                var userInputItems = GetString(inputPrompt);
                bool validInput = true;
                foreach (var userInput in userInputItems.Split(" ", StringSplitOptions.RemoveEmptyEntries))
                {
                    if (!selection.Contains(userInput, StringComparer.OrdinalIgnoreCase))
                    {
                        ui.OutputData($"*** '{userInput}' FINNS INTE SOM VALMÖJLIGHET, FÖRSÖK IGEN\n");
                        validInput = false;
                    }

                }
                if (validInput) { return userInputItems; }
            } while (true);
        }
        public string GetFromUnSelectionString(string inputPrompt, List<string> nonSelection)
        {
            // Input and is valid if it doesn't contain anything from "nonSelection".
            do
            {
                var userInput = GetString(inputPrompt);
                if (!nonSelection.Contains(userInput, StringComparer.OrdinalIgnoreCase)) { return userInput; }
                ui.OutputData("*** FINNS REDAN, SKRIV ETT NYTT\n");
            } while (true);
        }
        public int GetInt(string inputPrompt)
        {
            // First get a string, then try to parse it to an int
            do
            {
                // Check that the received input is a valid number (valid int)
                if (int.TryParse(GetString(inputPrompt), out int userInput))
                {
                    return userInput;
                }
                else
                {
                    ui.OutputData("*** FELAKTIGT VÄRDE, FÖRSÖK IGEn\n");
                }
            }
            while (true);
        }
        public double GetDouble(string inputPrompt)
        {
            // First get a string, then try to parse it to an double
            do
            {
                // Check that the received input is a valid number (valid double)
                if (double.TryParse(GetString(inputPrompt), out double userInput))
                {
                    return userInput;
                }
                else
                {
                    ui.OutputData("*** FELAKTIGT VÄRDE, FÖRSÖK IGEN\n");
                }
            }
            while (true);
        }
        public bool ConfirmYes(string confirmPrompt)
        {
            // Boolean input, can be used to confirm any "yes/no"
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
            // Command line input, returns a tuple with "command" and it's "args"
            var commandArgs = GetString("COMMAND> ").Split(" ", StringSplitOptions.RemoveEmptyEntries);
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
