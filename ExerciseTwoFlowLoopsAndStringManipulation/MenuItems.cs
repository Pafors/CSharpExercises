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

        internal static void WriteMenu()
        {
            Console.WriteLine("   --== HUVUDMENYN ==--");
            Console.WriteLine($"({TicketPriceOne}) Biljettpris för ungdom eller pensionär");
            Console.WriteLine($"({TicketPriceMulti}) Biljettpris för sällskap");
            Console.WriteLine($"({OutputTenTimes}) Skriva ut vald text tio gånger");
            Console.WriteLine($"({OutputThirdWord}) Skriv en mening vars tredje ord kommer att skrivas ut");
            Console.WriteLine($"({Quit}) Avsluta");
            Console.WriteLine("");
        }
    }
}
