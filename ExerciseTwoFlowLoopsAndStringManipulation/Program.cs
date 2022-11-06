using ExerciseTwoFlowLoopsAndStringManipulation;
using System;

bool exitRequested = false;

while (!exitRequested)
{
    Console.WriteLine("    -== HUVUDMENYN ==-");
    Console.WriteLine("(1) Biljettpris för ungdom eller pensionär");
    Console.WriteLine("(2) Biljettpris för sällskap");
    Console.WriteLine("(3) Skriva ut vald text tio gånger");
    Console.WriteLine("(4) Skriv en mening vars tredje ord kommer att skrivas ut");
    Console.WriteLine("(0) Avsluta");
    Console.WriteLine("");
    Console.Write("Skriv siffran för ditt val: ");
    string userMenuSelection = Console.ReadLine()!;

    switch (userMenuSelection)
    {
        case "0":
            // User selected to exit the application
            if (Utilities.confirm("Avslutar, är du säker (j/n)? "))
            {
                exitRequested = true;
            };
            break;

        case "1":
            // Show cost for one ticket
            Ticket ticket = new(Utilities.getUintInput("Ange ålder: "));
            Console.WriteLine($"{ticket.Category}: {ticket.Price} kr");
            break;

        case "2":
            // Calculate ticket cost for groups
            uint groupSize = 0, totalTicketCost = 0;
            List<Ticket> tickets = new List<Ticket>();
            groupSize = Utilities.getUintInput("Ange antalet personer i gruppen: ");

            for (int i = 0; i < groupSize; i++)
            {
                tickets.Add(new(Utilities.getUintInput($"Ange ålder för person {i + 1}: ")));
            }
            Console.WriteLine($"ANTAL I SÄLLSKAPET: {tickets.Count}");
            foreach (Ticket singleTicket in tickets)
            {
                totalTicketCost += singleTicket.Price;
            }
            Console.WriteLine($"TOTAL KOSTNAD FÖR GRUPPEN: {totalTicketCost}");
            break;

        case "3":
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

        case "4":
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