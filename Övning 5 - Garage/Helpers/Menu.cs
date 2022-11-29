using Exercise_5_Garage.UI;

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
        public const string FindAny = "find";
        public const string FindByProp = "findp";
        public const string FindByRegistration = "findreg";
        public const string Quit = "quit";
        public const string ShortQuit = "q";

        public static void WriteMenu(IUI ui)
        {
            ui.OutputData("\nFORDONS GARAGETS KOMMANDON\n");
            ui.OutputData($"'{NewGarage} (nnn)' Skapar ett nytt garage\n");
            ui.OutputData($"'{Populate}' Fyller på med lite fordon\n");
            ui.OutputData($"'{Park}' Parkerar ett nytt fordon\n");
            ui.OutputData($"'{UnPark} (rn1 rn2 ...)' Avparkerar ett fordon\n");
            ui.OutputData($"'{ListVehicles}' Visar parkerade fordon\n");
            ui.OutputData($"'{ListVehiclesByType}' Visar parkerade fordon per typ\n");
            ui.OutputData($"'{FindAny} (nnn nnn ...)' Hitta fordon\n");
            ui.OutputData($"'{FindByProp} (prop:nnn prop:nnn ...)' Hitta fordon via egenskap\n");
            ui.OutputData($"'{FindByRegistration} (rn)' Hitta fordon via registreringsnummer\n");
            ui.OutputData($"'{Quit}' Avsluta\n");
            ui.OutputData("NOTERA: Parametrar inom parantes är valfria, anges de inte som argument frågas de efter.");
            ui.OutputData("\n");
        }
    }
}