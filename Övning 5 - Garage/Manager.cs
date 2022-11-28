using Exercise_5_Garage.Handlers;
using Exercise_5_Garage.Helpers;
using Exercise_5_Garage.UI;
using Exercise_5_Garage.Vehicles;
using System.Linq;

namespace Exercise_5_Garage
{
    internal class Manager
    {
        private readonly IUI ui;
        private readonly IGarageHandler<IVehicle> gh;
        private readonly Dictionary<string, Action<string[]>> commandMenu;
        private readonly AskForInput askForInput;

        public Manager(IUI ui, IGarageHandler<IVehicle> garageHandler)
        {
            this.ui = ui;
            gh = garageHandler;
            commandMenu = new Dictionary<string, Action<string[]>>
            {
                { Menu.NewGarage, NewGarage },
                { Menu.Populate, Populate },
                { Menu.Park, Park },
                { Menu.UnPark, UnPark },
                { Menu.ListVehicles, ListVehicles },
                { Menu.ListVehiclesByType, ListVehiclesByType },
                { Menu.FindAny, FindAny },
                { Menu.FindByProp, FindByProp },
                { Menu.FindByRegistration, FindByRegistration },
                { Menu.Quit, ExitApplication },
                { Menu.ShortQuit, ExitApplication }
            };
            askForInput = new AskForInput(ui);
        }
        internal void StartUpLoop()
        {
            Menu.WriteMenu(ui);
            // Command loop
            while (true)
            {
                ShowStats();
                (string command, string[]? cmdArgs) = askForInput.GetCommand();
                if (commandMenu.ContainsKey(command))
                {
                    commandMenu[command]?.Invoke(cmdArgs!);
                }
                else
                {
                    ui.OutputData($"*** Kommandot '{command}' saknas, försök igen\n");
                    Menu.WriteMenu(ui);
                }
            }
        }
        private void ShowStats()
        {
            ui.OutputData("[ LEDIGA PLATSER: ");
            if (gh.HaveAGarage())
            {
                ui.OutputData($"{gh.GetNumberOfAvailableParkingSpots()}/{gh.GetSizeOfGarage()}");
            }
            else
            {
                ui.OutputData("0/0 (garage saknas)");
            }
            ui.OutputData(" ]\n");
        }
        internal void NewGarage(string[] size)
        {
            int wantedSize = 0;
            if (!gh.HaveAGarage() || (gh.HaveAGarage() && askForInput.ConfirmYes("Det finns redan ett garage, vill du fortsätta (j/n)? ")))
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
            if (!HaveGarage(gh)) { return; }
            var vehicles = new List<IVehicle>() {
                new Car("Volvo 240", "Blue", 4, "Diesel", "JAC495", convertible: false),
                new Car("Honda CRV", "Silver", 4, "Petrol", "QWE123", convertible: false),
                new Car("Land Rover", "Green", 4, "Diesel", "TRN707", convertible: true),
                new Bus("Scania", "Green", 8,"Diesel", "BUS042", 40),
                new Bus("Scania", "Yellow", 8, "Diesel", "BUS043", 40),
                new Bus("Scania clone", "Yellow", 8, "Diesel", "BUS043", 40),
                new Bus("Scania", "Red", 8, "Electrical", "BZZ232", 40),
                new Airplane("Airbus 340", "White", 12, "Jet", "JA8090", 4),
                new Boat("Vindö 32", "White", 0, "Diesel", "WNDPWR42x", 9, 1.3),
                new Motorcycle("Honda Goldwing", "Black", 2, "Petrol", "CRZ001", 1833),
                new Motorcycle("Honda Silverwing", "Purple", 2, "Petrol", "CRZ001", 1433)
            };
            foreach (var vehicle in vehicles)
            {
                (bool result, string reason) = gh.ParkVehicle(vehicle);
                if (result)
                {
                    ui.OutputData($"Parked: '{vehicle.RegistrationNumber}'\n");
                }
                else
                {
                    ui.OutputData($"Not parked '{vehicle.BrandAndModel}' with registration number '{vehicle.RegistrationNumber}': {reason}\n");
                }
            }
        }
        internal void Park(string[] vehicleData)
        {
            // TODO använda "params"?

            if (!HaveGarage(gh)) { return; }
            if (gh.GetNumberOfAvailableParkingSpots() < 1)
            {
                ui.OutputData("*** Garaget är fullt\n");
                return;
            }
            if (vehicleData.Length > 1)
            {
                // TODO parse
            }

            // TODO Cleanup
            ui.OutputData("Fordons typer: ");
            var vehicleTypes = gh.GetVehicleTypes();
            var vehicleNames = gh.GetVehicleTypes().Select(t => t.Name.ToLower()).ToList();
            foreach (var vehicleName in vehicleNames) { ui.OutputData($"{vehicleName} "); }
            ui.OutputData("\n");
            var selectedVehicleTypeString = askForInput.GetFromSelectionString("Välj typ: ", vehicleNames);
            Type? selectedVehicleType = vehicleTypes.Where(t => t.Name.ToLower() == selectedVehicleTypeString.ToLower()).FirstOrDefault();
            ArgumentNullException.ThrowIfNull(selectedVehicleType);

            string brandAndModel = askForInput.GetString("Märke och modell: ");
            string color = askForInput.GetString("Färg: ");
            int numberOfWheels = askForInput.GetInt("Antal hjul: ");
            string powerSource = askForInput.GetString("Drivmedel: ");
            string registrationNumber = askForInput.GetFromUnSelectionString("Registreringsnummer: ", gh.GetAllRegistrationNumbers());

            // Each class special prop and creation of the instance
            IVehicle newVehicle;
            switch (selectedVehicleTypeString.ToLower())
            {
                case "airplane":
                    int numberOfEngines = askForInput.GetInt("Antal motorer: ");
                    newVehicle = new Airplane(brandAndModel, color, numberOfWheels, powerSource, registrationNumber, numberOfEngines);
                    break;
                case "boat":
                    int length = askForInput.GetInt("Längd: ");
                    double draft = askForInput.GetDouble("Djup gång: ");
                    newVehicle = new Boat(brandAndModel, color, numberOfWheels, powerSource, registrationNumber, length, draft);
                    break;
                case "bus":
                    int numberOfSeats = askForInput.GetInt("Antal platser: ");
                    newVehicle = new Bus(brandAndModel, color, numberOfWheels, powerSource, registrationNumber, numberOfSeats);
                    break;
                case "car":
                    bool isConvertible = askForInput.ConfirmYes("Är det en cabriolet (j/n)? ");
                    newVehicle = new Car(brandAndModel, color, numberOfWheels, powerSource, registrationNumber, isConvertible);
                    break;
                case "motorcycle":
                    int cylinderVolume = askForInput.GetInt("Cylinder volym: ");
                    newVehicle = new Motorcycle(brandAndModel, color, numberOfWheels, powerSource, registrationNumber, cylinderVolume);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unknown vehicle type");
            }

            gh.ParkVehicle(newVehicle);


        }
        internal void UnPark(string[] registrationSearch)
        {
            if (!HaveGarage(gh)) { return; }
            string regNumber;
            if (registrationSearch.Length < 1)
            {
                regNumber = askForInput.GetString("Vilket registreringsnummer vill du avparkera?\n");
            }
            else
            {
                regNumber = registrationSearch[0];
            }
            // Vehicle will be unparked if its registration number are in the garage
            if (gh.UnParkVehicle(regNumber))
            {
                ui.OutputData($"Fordon med registreringsnummer '{regNumber}' är avparkerad\n");
            }
            else
            {
                ui.OutputData($"*** Garaget saknar ett fordon med registreringsnummer '{regNumber}'\n");
            }
        }
        internal void ListVehicles(string[] _)
        {
            if (!HaveGarage(gh)) { return; }
            foreach (var vehicle in gh.GetParkedVehicles())
            {
                ui.OutputData($"{vehicle}\n");
            }
        }
        internal void ListVehiclesByType(string[] _)
        {
            if (!gh.HaveAGarage())
            {
                ui.OutputData("*** Garage saknas\n");
                return;
            }
            var v = gh.GetParkedVehicles();
            var groups = v.GroupBy(
                v => v.GetType().ToString(),
                v => v.GetType(),
                (vtGrp, vt) => new { VehicleType = vtGrp.Split(".").Last(), Count = vt.Count() });

            ui.OutputData($"FORDONSTYP OCH ANTAL\n");
            foreach (var grping in groups)
            {
                ui.OutputData($"{grping.VehicleType, 12}: ");
                ui.OutputData($"{grping.Count} st\n");
            }
        }
        internal void FindAny(string[] searchTerms)
        {
            if (!HaveGarage(gh)) { return; }
            // No parameters in input, ask for them
            if (searchTerms.Length < 1)
            {
                searchTerms = askForInput.GetString("Ange sök termer (mellanslag är avdelare): ").Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            // First get a list of all vehicles, which will be be filtered for each match
            List<IVehicle> intersectResult = gh.GetParkedVehicles().ToList();

            // Filters so only those terms that matches any of the props will stay
            foreach (var searchTerm in searchTerms)
            {
                intersectResult = intersectResult.Intersect(gh.FindAny(searchTerm)).ToList();
            }

            ShowSearchResults(intersectResult);
        }
        internal void FindByProp(string[] searchTerms)
        {
            if (!gh.HaveAGarage())
            {
                ui.OutputData("*** Garage saknas\n");
                return;
            }
            // TODO PROPS BY GARAGE
            var uniqueSearchTerms = gh.GetSearchTerms();
            if (uniqueSearchTerms == null) { return; }
            foreach (var searchTerm in uniqueSearchTerms)
            {
                ui.OutputData($"{searchTerm.Key, 7} {searchTerm.Value}\n");
            }
            ui.OutputData("Exempel på sökning: 'type:car color:blue', 'ps:diesel wheels:4'\n");
            // No parameters in input, ask for them
            if (searchTerms.Length < 1)
            {
                // TODO lägga till andra egenskaper
                searchTerms = askForInput.GetString("Ange sök termer (mellanslag är avdelare): ").Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            // First get a list of all vehicles, which will be be filtered for each match
            List<IVehicle> intersectResult = gh.GetParkedVehicles().ToList();

            // Keep only the results that matches the selected props
            foreach (var searchTerm in searchTerms)
            {
                // Split each search term ("vehicleProp:searchText") into it's parts
                string[] searchData = searchTerm.Split(":", StringSplitOptions.RemoveEmptyEntries);
                // If prop or text terms are missing, skip this search term
                if ( searchData.Length != 2 ) { continue; }
                string vehicleProp = searchData[0];
                string searchText = searchData[1];
                intersectResult = intersectResult.Intersect(gh.FindByProp(vehicleProp, searchText)).ToList();
            }
            ShowSearchResults(intersectResult);

        }
        internal void FindByRegistration(string[] rnToFind)
        {
            if(!HaveGarage(gh)) {  return ; }
            string searchString;
            // No parameters in input, ask for it
            if (rnToFind.Length < 1)
            {
                searchString = askForInput.GetString("Vilket registreringsnummer vill du söka efter?\n");
            }
            else
            {
                // Only use the first parameter for the registration search, could be changed to a "find any" of parameters
                searchString = rnToFind[0];
            }
            ShowSearchResults(gh.FindByRegistration(searchString));
        }
        internal void ExitApplication(string[] _)
        {
            Environment.Exit(0);
        }
        internal void ShowSearchResults(IEnumerable<IVehicle> results)
        {
            ui.OutputData($"\nFOUND {results.Count()} MATCHES\n");
            foreach (var match in results)
            {
                ui.OutputData($"{match}\n");
            }
        }
        internal bool HaveGarage(IGarageHandler<IVehicle> gh)
        {
            if (!gh.HaveAGarage())
            {
                ui.OutputData("*** Garage saknas\n");
                return false;
            }
            return true;
        }
    }
}
