﻿using ExerciseTwoFlowLoopsAndStringManipulation;
using System;

bool exitRequested = false;
IUI ui = new ConsoleUI();

while (!exitRequested)
{
    MenuItems.WriteMenu(ui);
    string userMenuSelection = Utilities.GetStringInput("Skriv siffran för ditt val: ", ui); // For future use, keep as "string"

    switch (userMenuSelection)
    {
        case MenuItems.Quit:
            // User selected to exit the application
            if (Utilities.Confirm("Avslutar, är du säker (j/n)? ", ui))
            {
                exitRequested = true;
            };
            break;

        case MenuItems.TicketPriceOne:
            // Show cost for one ticket
            Ticket ticket = new(Utilities.GetUintInput("Ange ålder: ", ui));
            ui.OutputData($"{ticket.Category.ToUpper()}: {ticket.Price} kr\n");
            break;

        case MenuItems.TicketPriceMulti:
            // Calculate ticket cost for groups
            uint groupSize = 0, totalTicketCost = 0;
            List<Ticket> tickets = new List<Ticket>();
            groupSize = Utilities.GetUintInput("Ange antalet personer i gruppen: ", ui);
            // Add tickets
            for (int i = 0; i < groupSize; i++)
            {
                tickets.Add(new(Utilities.GetUintInput($"Ange ålder för person {i + 1}: ", ui)));
            }
            ui.OutputData($"ANTAL I SÄLLSKAPET: {tickets.Count}\n");
            // Calculate total cost for the group, and output the result
            foreach (Ticket singleTicket in tickets)
            {
                totalTicketCost += singleTicket.Price;
            }
            ui.OutputData($"TOTAL KOSTNAD FÖR GRUPPEN: {totalTicketCost}\n");
            break;

        case MenuItems.OutputTenTimes:
            // Write text ten (10) times on the same line (unless wrapped)
            ui.OutputData("Ange text som ska skrivas ut tio (10) gånger:\n");
            int loopAmount = 10;
            string loopText = ui.InputData()!;
            for (int i = 0; i < 10; i++)
            {
                ui.OutputData($"{i + 1}.{loopText}");
                if ((i + 1) < loopAmount)
                {
                    ui.OutputData(", ");
                }
            }
            ui.OutputData("\n");
            break;

        case MenuItems.OutputThirdWord:
            // Extract the third word and write it
            ui.OutputData("Skriv meningen som ska delas upp, vars tredje ord kommer visas:\n");
            string userSelectedSentence =ui.InputData()!;
            var splitSentence = userSelectedSentence.Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (splitSentence.Length < 3)
            {
                ui.OutputData("Meningen har färre än 3 ord, så inget skrivs ut\n");
            }
            else
            {
                ui.OutputData($"Det tredje ordet är: '{splitSentence[2]}'\n");
            }
            break;

        default:
            ui.OutputData("Ogiltigt menyval, försök igen\n");
            break;
    }
}