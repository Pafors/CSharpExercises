using Exercise_5_Garage.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5_Garage.Helpers
{
    internal static class Menu
    {
        public const string NewGarage = "new";
        public const string Populate = "populate";
        public const string Park = "park";
        public const string UnPark = "unpark";
        public const string ListVehicles = "list";
        public const string ListVehiclesByType = "types";
        public const string Quit = "quit";
        public const string ShortQuit = "q";

        public static void WriteMenu(IUI ui)
        {
            ui.OutputData("\nFORDONS GARAGETS KOMMANDON\n");
            ui.OutputData($"'{NewGarage}' Skapar ett nytt garage\n");
            ui.OutputData($"'{Populate}' Fyller på med lite fordon\n");
            ui.OutputData($"'{Park}' Parkerar ett fordon\n");
            ui.OutputData($"'{UnPark}' Avparkerar ett fordon\n");
            ui.OutputData($"'{ListVehicles}' Visar parkerade fordon\n");
            ui.OutputData($"'{ListVehiclesByType}' Visar parkerade fordon per typ\n");
            ui.OutputData($"'{Quit}' Avsluta\n");
            ui.OutputData("\n");
        }
    }
}