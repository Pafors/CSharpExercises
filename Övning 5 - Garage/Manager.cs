using Exercise_5_Garage.Handlers;
using Exercise_5_Garage.Helpers;
using Exercise_5_Garage.Types;
using Exercise_5_Garage.UI;
using Exercise_5_Garage.Vehicles;
using Exercise_5_Garage.VehicleStorageFacilities;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5_Garage
{
    internal class Manager
    {
        private readonly IUI ui;
        private GarageHandler<IVehicle> gh;
        private readonly Dictionary<string, Action<string[]>> commandMenu;
        private AskForInput askForInput;

        public Manager(IUI ui, GarageHandler<IVehicle> garageHandler)
        {
            this.ui = ui;
            gh = garageHandler;
            commandMenu = new Dictionary<string, Action<string[]>>
            {
                { Menu.NewGarage, NewGarage },
                { Menu.Populate, Populate },
                //{ Menu.Park, Park },
                { Menu.UnPark, UnPark },
                { Menu.ListVehicles, ListVehicles },
                { Menu.ListVehiclesByType, ListVehiclesByType },
                { Menu.FindByRegistration, FindByRegistration },
                { Menu.Quit, ExitApplication },
                { Menu.ShortQuit, ExitApplication }
            };
            askForInput = new AskForInput(ui);
        }

        internal void StartUp()
        {
            // Command loop
            while (true)
            {
                Menu.WriteMenu(ui);
                showStats();
                (string command, string[]? cmdArgs) = askForInput.GetCommand();
                //foreach (var arg in cmdArgs!)
                //{
                //    ui.OutputData($"'{arg}'");
                //}
                //ui.OutputData("\n");
                if (commandMenu.ContainsKey(command))
                {
                    commandMenu[command]?.Invoke(cmdArgs);
                }
                else
                {
                    ui.OutputData($"Kommandot '{command}' saknas, försök igen\n");
                }

            }


            //ui.OutputData($"Parked before: {gh.NumberOfParkedVehicles()}\n");
            //gh.ParkVehicle(new Car("Volvo 240", "Blue", 4, PowerType.Diesel, "JAC495", convertible: false));
            //gh.ParkVehicle(new Car("Honda CRV", "Silver", 4, PowerType.Petrol, "QWE123", convertible: false));
            //gh.ParkVehicle(new Bus("Scania", "Green", 8, PowerType.Diesel, "BUS042", 40));
            //gh.ParkVehicle(new Bus("Scania", "Yellow", 8, PowerType.Diesel, "BUS043", 40));
            //gh.ParkVehicle(new Bus("Scania", "Red", 8, PowerType.Diesel, "BUS044", 40));
            //ui.OutputData($"Parked after: {gh.NumberOfParkedVehicles()}\n");
            //foreach (var v in gh.GetParkedVehicles())
            //{
            //    ui.OutputData($"Vehicle before: {v}\n");
            //}
            //ui.OutputData("---\n");
            //gh.UnParkVehicle(1);
            //gh.ParkVehicle(new Bus("Scania", "Pink", 8, PowerType.Diesel, "BUS044", 40));

            //foreach (var v in gh.GetParkedVehicles())
            //{
            //    ui.OutputData($"Vehicle after: {v}\n");
            //}

            //ui.OutputData($"Free parking spots: {gh.GetNumberOfAvailableParkingSpots()}\n");

            //var searchResult = gh.Find("Scania");
            //ui.OutputData("__________________\n");
            //foreach (var match in searchResult)
            //{
            //    ui.OutputData($"FOUND: '{match}'\n");

            //}
            //ui.OutputData("__________________\n");

        }

        private void showStats()
        {
            ui.OutputData("[ ");
            if (gh.HaveAGarage())
            {
                ui.OutputData($"LEDIGA PLATSER: {gh.GetNumberOfAvailableParkingSpots()}");
            }
            else
            {
                ui.OutputData("GARAGE SAKNAS");
            }
            ui.OutputData(" ]\n");
        }
        internal void NewGarage(string[] size)
        {
            int wantedSize = 0;
            if (!gh.HaveAGarage() || (gh.HaveAGarage() && askForInput.ConfirmYes("Det finns redan ett garage, vill du fortsätta (j/n)?")))
            {
                if (size.Length > 0)
                {
                    if (int.TryParse(size[0], out int parsedSize))
                    {
                        wantedSize = parsedSize;
                    }
                }
                else
                {
                    wantedSize = askForInput.GetInt("Önskad storlek: ");
                }
                if (wantedSize > 0)
                {
                    gh.NewGarage(wantedSize);
                }
            }
        }
        internal void Populate(string[] _)
        {
            if (!gh.HaveAGarage())
            {
                ui.OutputData("Garage saknas\n");
                return;
            }
            var vehicles = new List<IVehicle>() {
                new Car("Volvo 240", "Blue", 4, PowerType.Diesel, "JAC495", convertible: false),
                new Car("Honda CRV", "Silver", 4, PowerType.Petrol, "QWE123", convertible: false),
                new Bus("Scania", "Green", 8, PowerType.Diesel, "BUS042", 40),
                new Bus("Scania", "Yellow", 8, PowerType.Diesel, "BUS043", 40),
                new Bus("Scania", "Red", 8, PowerType.Diesel, "BUS044", 40),
                new Airplane("Airbus 340", "White", 12, PowerType.Jet, "JA8090", 4),
                new Boat("Vindö 32", "White", 0, PowerType.Diesel, "WNDPWR42x", 9, 1.3),
                new Motorcycle("Honda Goldwing", "Black", 2, PowerType.Petrol, "CRZ001", 1833)
            };
            foreach (var vehicle in vehicles)
            {
                if (gh.ParkVehicle(vehicle))
                {
                    ui.OutputData($"Parked: {vehicle}\n");
                }
                else
                {
                    ui.OutputData($"Not parked: {vehicle}\n");
                }
            }
        }
        internal void Park() { }
        internal void UnPark(string[] registrationSearch) 
        {
            if (!gh.HaveAGarage())
            {
                ui.OutputData("Garage saknas\n");
                return;
            }
            // TODO registrationSearch
            string regNumber;
            if (registrationSearch.Length < 1)
            {
                regNumber = askForInput.GetString("Vilket registreringsnummer vill du söka efter?\n");
            }
            else
            {
                regNumber = registrationSearch[0];
            }
            // TODO Success or not
            gh.UnParkVehicle(regNumber);
        }
        internal void ListVehicles(string[] _)
        {
            if (!gh.HaveAGarage())
            {
                ui.OutputData("Garage saknas\n");
                return;
            }
            foreach (var vehicle in gh.GetParkedVehicles())
            {
                ui.OutputData($"{vehicle}\n");
            }
        }
        internal void ListVehiclesByType(string[] _)
        {
            if (!gh.HaveAGarage())
            { 
                ui.OutputData("Garage saknas\n"); 
                return; 
            }
            var v = gh.GetParkedVehicles();
            var groups = v.GroupBy(
                v => v.GetType().ToString(),
                v => v.GetType(),
                (vtGrp, vt) => new { VehicleType = vtGrp.Split(".").Last(), Count = vt.Count() });
            foreach (var grping in groups)
            {
                ui.OutputData($"{grping.VehicleType}: ");
                ui.OutputData($"{grping.Count}\n");
            }
        }
        internal void FindByRegistration(string[] rnToFind)
        {
            if (!gh.HaveAGarage())
            {
                ui.OutputData("Garage saknas\n");
                return;
            }
            string searchString;
            if(rnToFind.Length < 1) {
                searchString = askForInput.GetString("Vilket registreringsnummer vill du söka efter?\n");
            }
            else
            {
                searchString = rnToFind[0];
            }
            ui.OutputData("MATCHES:\n");
            foreach (var match in gh.FindByRegistration(searchString))
            {
                ui.OutputData($"{match}\n");
            }
        }
        internal void ExitApplication(string[] _)
        {
            Environment.Exit(0);
        }

    }
}
