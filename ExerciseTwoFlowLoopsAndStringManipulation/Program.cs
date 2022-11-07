using ExerciseTwoFlowLoopsAndStringManipulation;
using System;

bool exitRequested = false;

while (!exitRequested)
{
    Console.WriteLine("   --== HUVUDMENYN ==--");
    Console.WriteLine($"({MenuItems.TicketPriceOne}) Biljettpris för ungdom eller pensionär");
    Console.WriteLine($"({MenuItems.TicketPriceMulti}) Biljettpris för sällskap");
    Console.WriteLine($"({MenuItems.OutputTenTimes}) Skriva ut vald text tio gånger");
    Console.WriteLine($"({MenuItems.OutputThirdWord}) Skriv en mening vars tredje ord kommer att skrivas ut");
    Console.WriteLine($"({MenuItems.Quit}) Avsluta");
    Console.WriteLine("");
    string userMenuSelection = Utilities.GetStringInput("Skriv siffran för ditt val: "); // For future use, keep as "string"

    switch (userMenuSelection)
    {
        case MenuItems.Quit:
            // User selected to exit the application
            if (Utilities.Confirm("Avslutar, är du säker (j/n)? "))
            {
                exitRequested = true;
            };
            break;

        case MenuItems.TicketPriceOne:
            // Show cost for one ticket
            Ticket ticket = new(Utilities.GetUintInput("Ange ålder: "));
            Console.WriteLine($"{ticket.Category.ToUpper()}: {ticket.Price} kr");
            break;

        case MenuItems.TicketPriceMulti:
            // Calculate ticket cost for groups
            uint groupSize = 0, totalTicketCost = 0;
            List<Ticket> tickets = new List<Ticket>();
            groupSize = Utilities.GetUintInput("Ange antalet personer i gruppen: ");
            // Add tickets
            for (int i = 0; i < groupSize; i++)
            {
                tickets.Add(new(Utilities.GetUintInput($"Ange ålder för person {i + 1}: ")));
            }
            Console.WriteLine($"ANTAL I SÄLLSKAPET: {tickets.Count}");
            // Calculate total cost for the group, and output the result
            foreach (Ticket singleTicket in tickets)
            {
                totalTicketCost += singleTicket.Price;
            }
            Console.WriteLine($"TOTAL KOSTNAD FÖR GRUPPEN: {totalTicketCost}");
            break;

        case MenuItems.OutputTenTimes:
            // Write text ten (10) times on the same line (unless wrapped)
            Console.WriteLine("Ange text som ska skrivas ut tio (10) gånger:");
            int loopAmount = 10;
            string loopText = Console.ReadLine()!;
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{i + 1}.{loopText}");
                if ((i + 1) < loopAmount)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine();
            break;

        case MenuItems.OutputThirdWord:
            // Extract the third word and write it
            Console.WriteLine("Skriv meningen som ska delas upp, vars tredje ord kommer visas:");
            string userSelectedSentence = Console.ReadLine()!;
            var splitSentence = userSelectedSentence.Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (splitSentence.Length < 3)
            {
                Console.WriteLine("Meningen har färre än 3 ord, så inget skrivs ut");
            }
            else
            {
                Console.WriteLine($"Det tredje ordet är: '{splitSentence[2]}'");
            }
            break;

        default:
            Console.WriteLine("Ogiltigt menyval, försök igen");
            break;
    }
    Console.WriteLine("");
}