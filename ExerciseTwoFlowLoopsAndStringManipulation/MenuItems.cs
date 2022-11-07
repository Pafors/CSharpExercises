using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTwoFlowLoopsAndStringManipulation
{
    public static class MenuItems
    {
        public const string Quit = "0";
        public const string TicketPriceOne = "1";
        public const string TicketPriceMulti = "2";
        public const string OutputTenTimes = "3";
        public const string OutputThirdWord = "4";

        internal static void WriteMenu(IUI ui)
        {
            ui.OutputData("\n   --== HUVUDMENYN ==--\n");
            ui.OutputData($"({TicketPriceOne}) Biobiljett pris för en person\n");
            ui.OutputData($"({TicketPriceMulti}) Biobiljett pris för sällskap\n");
            ui.OutputData($"({OutputTenTimes}) Upprepa tio gånger, skriver ut vald text tio gånger\n");
            ui.OutputData($"({OutputThirdWord}) Det tredje ordet, skriv en mening vars tredje ord kommer att skrivas ut\n");
            ui.OutputData($"({Quit}) Avsluta\n");
            ui.OutputData("\n");
        }
    }
}
