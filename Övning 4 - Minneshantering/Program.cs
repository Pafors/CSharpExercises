using System;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

// Frågor:
// 1. Hur fungerar stacken och heapen ? Förklara gärna med exempel eller skiss på dess
//    grundläggande funktion
// Svar: Stacken är som en hög med papper, det man lägger senast hamnar överst
//       och plockas upp först. För att komma åt det sista pappret måste de plockas 
//       upp i tur och ordning från översta (senast inkomna) till det sista (först
//       inkomna). Stacken är "linjär", en dimensionell.
//       Heapen är mer som en stor yta där data läggs på ledig plats och allt är snabbt
//       och lättåtkomligt. Eftersom heapen inte är "linjär" så måste en "städare" komma
//       in och rensa bort data där kopplingen försvunnit, en "garbage collect" (GC).
// 
// 2. Vad är Value Types repsektive Reference Types och vad skiljer dem åt?
// Svar: Beroende på vilken typ det är så lagras de olika. Value Types lagras normalt
//       direkt på stacken, om de inte är inbakade i en Reference Type då hamnar de på
//       heapen där alla Reference Types lagras. Om jag inte minns fel så lagras en
//       pointer till Reference Type på stacken.
//
// 3. Följande metoder ( se bild nedan ) genererar olika svar. Den första returnerar 3, den
//    andra returnerar 4, varför?
// Svar: Det beror på att "ReturnValue2()" använder en MyInt klass som är en reference type,
//       vilket gör att när "y = x;" exekveras i metoden så sätts "y" till exakt samma objekt
//       som "x" (samma pekare), och det leder till att även "x" blir "4" när "y = 4;". 

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            //List<string> theList = new List<string>();
            //string input = Console.ReadLine();
            //char nav = input[0];
            //string value = input.substring(1);

            //switch(nav){...}

            // 1.Skriv klart implementationen av ExamineList-metoden så att undersökningen blir genomförbar.
            // Svar: Se koden nedan
            //
            // 2.När ökar listans kapacitet ? (Alltså den underliggande arrayens storlek)
            // Svar: Den underliggande arrayens storlek är initiellt 0 och ökar varje gång kapaciteten på arrayen inte 
            //       räcker till för antalet i listan.
            //
            // 3.Med hur mycket ökar kapaciteten?
            // Svar: Först 4, sedan dubblas kapaciteten, dvs 4, 8, 16, 32. Klassiska binära värden. :)
            //
            // 4.Varför ökar inte listans kapacitet i samma takt som element läggs till ?
            // Svar: En array har en fast storlek och kan inte utökas eller minskas, den underliggande arrayen i för listan
            //       måste skapas och all data överföras till nya vilket tar tid och resurser från processorn.
            //
            // 5.Minskar kapaciteten när element tas bort ur listan?
            // Svar: Nej
            //
            // 6.När är det då fördelaktigt att använda en egendefinierad array istället för en lista?
            // Svar: När man vet storleken och att den inte kommer att förändras (bli större).

            var userMadeList = new List<string>();
            bool isActiveWithList = true;
            Console.WriteLine("\nCommands:\n'+item' will add 'item' to the list\n'-item' will remove it\n'q' will exit to main menu");
            do
            {
                Console.WriteLine($"List count: {userMadeList.Count} and capacity: {userMadeList.Capacity}");
                Console.Write("Command: ");
                string userInput = Console.ReadLine()!;
                // Add a check that the input is not empty
                if (userInput.Length > 0)
                {
                    char command = userInput[0];
                    // value could be an empty string if user only put in a command
                    string value = userInput.Substring(1);

                    switch (command)
                    {
                        case '+':
                            userMadeList.Add(value);
                            break;
                        case '-':
                            userMadeList.Remove(value);
                            break;
                        case 'q':
                            isActiveWithList = false;
                            break;
                        default:
                            Console.WriteLine($"Unknown command '{command}'");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, try again (+item, -item, q)");
                }
            } while (isActiveWithList);
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            var userMadeQueue = new Queue<string>();
            bool isActiveWithQueue = true;
            Console.WriteLine("\nCommands:\n'+item' will add 'item' to the queue\n'-' will dequeue an item\n'q' will exit to main menu");
            do
            {
                Console.WriteLine($"Queue count: {userMadeQueue.Count}");
                Console.Write("Command: ");
                string userInput = Console.ReadLine()!;
                // Add a check that the input is not empty
                if (userInput.Length > 0)
                {
                    char command = userInput[0];
                    // value could be an empty string if user only put in a command
                    string value = userInput.Substring(1);

                    switch (command)
                    {
                        case '+':
                            userMadeQueue.Enqueue(value);
                            break;
                        case '-':
                            if (userMadeQueue.Count > 0)
                            {
                                string deQueued = userMadeQueue.Dequeue();
                                Console.WriteLine($"'{deQueued}' is not longer in the queue");
                            }
                            else { Console.WriteLine("Queue is empty"); }
                            break;
                        case 'q':
                            isActiveWithQueue = false;
                            break;
                        default:
                            Console.WriteLine($"Unknown command '{command}'");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, try again (+item, -, q)");
                }
            } while (isActiveWithQueue);


        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            // 1. Simulera ännu en gång ICA-kön på papper. Denna gång med en stack. Varför är det
            //    inte så smart att använda en stack i det här fallet ?
            // Svar: Den som kommer först till ICA-kön kommer få assistans sist om det hela tiden 
            //       kommer nya kunder. Är kunden ensam så fungerar det, men hur ofta är det så. :)
            //
            // 2. Implementera en ReverseText - metod som läser in en sträng från användaren och
            //    med hjälp av en stack vänder ordning på teckenföljden för att sedan skriva ut den
            //    omvända strängen till användaren.
            // Svar: Texten i kommentaren direkt under "ExamineStack()" anger
            //       att vi ska göra något annat än den i PDF:en.
            //       Jag följde PDF:ens anvisning, och på två olika sätt.

            string ReverseText(string text)
            {
                var userMadeStack = new Stack<char>();
                // Better to use StringBuilder than a string, for the garbage collector
                var reversedText = new StringBuilder();
                // Add (push) to stack
                foreach (var character in text)
                {
                    userMadeStack.Push(character);
                }
                // Remove (pop) from stack and add it to the stringbuilder
                foreach (var entry in userMadeStack)
                {
                    reversedText.Append(entry);
                }
                return reversedText.ToString();
            }

            bool validInput = false;
            Console.WriteLine("Write some text that will be reversed using a stack");
            do
            {
                Console.Write("Enter text: ");
                string userInput = Console.ReadLine()!;
                // Add a check that the input is not empty
                if (userInput.Length > 0)
                {
                    validInput = true;
                    Console.WriteLine(ReverseText(userInput));
                }
                else
                {
                    Console.WriteLine("Empty input, please try again");
                }
            }
            while (!validInput);
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            // 1. Skapa med hjälp av er nya kunskap funktionalitet för att kontrollera en välformad
            //    sträng på papper.Du ska använda dig av någon eller några av de datastrukturer vi
            //    precis gått igenom.Vilken datastruktur använder du?
            // Svar:
            //
            // 2. Implementera funktionaliteten i metoden CheckParentheses. Låt programmet läsa
            //    in en sträng från användaren och returnera ett svar som reflekterar huruvida
            //    strängen är välformad eller ej.

            bool validCharPairs(Dictionary<char, char> pairs, string text)
            {
                if (text.Length == 0) { return true; }
                var charStack = new Stack<char>();
                foreach (var character in text)
                {
                    if (pairs.ContainsKey(character))
                    {
                        charStack.Push(character);
                    }
                    if (pairs.ContainsValue(character))
                    {
                        // Since it's and "end" parentheses and no "open" are on the stack it's a non-valid match
                        if (charStack.Count == 0) { return false; }
                        // Pop from the stack
                        char lastOnStack = charStack.Pop();
                        // And check if it's a match, if so, continue to the next
                        if (pairs[lastOnStack] != character) { return false; }
                    }
                }
                // All matches so return true
                return true;
            }

            // Make a dictionary with matching parentheses (brackets and braces) pairs
            var matchingParenthesesPairs = new Dictionary<char, char>()
            {
                { '(', ')' },
                { '{', '}' },
                { '[', ']' }
            };

            bool validInput = false;
            Console.WriteLine("Write some text that will checked for valid parentheses");
            do
            {
                Console.Write("Enter text: ");
                string userInput = Console.ReadLine()!;
                // Add a check that the input is not empty
                if (userInput.Length > 0)
                {
                    validInput = true;
                    if (validCharPairs(matchingParenthesesPairs, userInput))
                    {
                        Console.WriteLine("The text has valid pairs of parentheses, brackets and braces\n");
                    }
                    else
                    {
                        Console.WriteLine("The text has non-valid pairs of parentheses, brackets and braces\n");
                    }
                }
                else
                {
                    Console.WriteLine("Empty input, please try again");
                }
            }
            while (!validInput);
        }
    }
}

