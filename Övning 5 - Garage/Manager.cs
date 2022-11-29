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
                    ui.OutputData($"*** KOMMANDOT '{command}' SAKNAS, FÖRSÖK IGEN\n");
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
                ui.OutputData("0/0 (GARAGE SAKNAS)");
            }
            ui.OutputData(" ]\n");
        }
        internal void NewGarage(string[] size)
        {
            int wantedSize = 0;
            if (!gh.HaveAGarage() || (gh.HaveAGarage() && askForInput.ConfirmYes("DET FINNS REDAN ETT GARAGE, VILL DU FORTSÄTTA (J/N)? ")))
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
                    wantedSize = askForInput.GetInt("ÖNSKAD STORLEK: ");
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
                    ui.OutputData($"PARKED: '{vehicle.RegistrationNumber}'\n");
                }
                else
                {
                    ui.OutputData($"NOT PARKED '{vehicle.BrandAndModel}' WITH REGISTRATION NUMBER '{vehicle.RegistrationNumber}': {reason}\n");
                }
            }
        }
        internal void Park(string[] vehicleData)
        {
            // TODO park använda "params"?

            if (!HaveGarage(gh)) { return; }
            if (gh.GetNumberOfAvailableParkingSpots() < 1)
            {
                ui.OutputData("*** GARAGET ÄR FULLT\n");
                return;
            }
            if (vehicleData.Length > 1)
            {
                // TODO park parse?
            }

            // TODO park Cleanup
            ui.OutputData("FORDONS TYPER: ");
            var vehicleTypes = gh.GetVehicleTypes();
            var vehicleNames = gh.GetVehicleTypes().Select(t => t.Name.ToLower()).ToList();
            foreach (var vehicleName in vehicleNames) { ui.OutputData($"{vehicleName} "); }
            ui.OutputData("\n");
            var selectedVehicleTypeString = askForInput.GetFromSelectionString("VÄLJ FORDONS TYP: ", vehicleNames);
            Type? selectedVehicleType = vehicleTypes.Where(t => t.Name.ToLower() == selectedVehicleTypeString.ToLower()).FirstOrDefault();
            ArgumentNullException.ThrowIfNull(selectedVehicleType);

            string brandAndModel = askForInput.GetString("MÄRKE OCH MODELL: ");
            string color = askForInput.GetString("FÄRG: ");
            int numberOfWheels = askForInput.GetInt("ANTAL HJUL: ");
            string powerSource = askForInput.GetString("DRIVMEDEL: ");
            string registrationNumber = askForInput.GetFromUnSelectionString("REGISTRERINGSNUMMER: ", gh.GetAllRegistrationNumbers());

            // Each class special prop and creation of the instance
            IVehicle newVehicle;
            switch (selectedVehicleTypeString.ToLower())
            {
                case "airplane":
                    int numberOfEngines = askForInput.GetInt("ANTAL MOTORER: ");
                    newVehicle = new Airplane(brandAndModel, color, numberOfWheels, powerSource, registrationNumber, numberOfEngines);
                    break;
                case "boat":
                    int length = askForInput.GetInt("LÄNGD: ");
                    double draft = askForInput.GetDouble("DJUP GÅNG: ");
                    newVehicle = new Boat(brandAndModel, color, numberOfWheels, powerSource, registrationNumber, length, draft);
                    break;
                case "bus":
                    int numberOfSeats = askForInput.GetInt("ANTAL PLATSER: ");
                    newVehicle = new Bus(brandAndModel, color, numberOfWheels, powerSource, registrationNumber, numberOfSeats);
                    break;
                case "car":
                    bool isConvertible = askForInput.ConfirmYes("ÄR DET EN CABRIOLET (J/N)? ");
                    newVehicle = new Car(brandAndModel, color, numberOfWheels, powerSource, registrationNumber, isConvertible);
                    break;
                case "motorcycle":
                    int cylinderVolume = askForInput.GetInt("CYLINDER VOLYM: ");
                    newVehicle = new Motorcycle(brandAndModel, color, numberOfWheels, powerSource, registrationNumber, cylinderVolume);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("UNKNOWN VEHICLE TYPE");
            }

            gh.ParkVehicle(newVehicle);
        }
        internal void UnPark(string[] registrationSearch)
        {
            if (!HaveGarage(gh)) { return; }
            string regNumber;
            if (registrationSearch.Length < 1)
            {
                regNumber = askForInput.GetString("VILKET REGISTRERINGSNUMMER VILL DU AVPARKERA?\n");
            }
            else
            {
                regNumber = registrationSearch[0];
            }
            // Vehicle will be unparked if its registration number are in the garage
            if (gh.UnParkVehicle(regNumber))
            {
                ui.OutputData($"FORDON MED REGISTRERINGSNUMMER '{regNumber}' ÄR AVPARKERAD\n");
            }
            else
            {
                ui.OutputData($"*** GARAGET SAKNAR ETT FORDON MED REGISTRERINGSNUMMER '{regNumber}'\n");
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
            if (!HaveGarage(gh)) { return; }
            var v = gh.GetParkedVehicles();
            var groups = v.GroupBy(
                v => v.GetType().ToString(),
                v => v.GetType(),
                (vtGrp, vt) => new { VehicleType = vtGrp.Split(".").Last(), Count = vt.Count() });

            ui.OutputData($"FORDONSTYP OCH ANTAL\n");
            foreach (var grping in groups)
            {
                ui.OutputData($"{grping.VehicleType,12}: ");
                ui.OutputData($"{grping.Count}\n");
            }
        }
        internal void FindAny(string[] searchTerms)
        {
            if (!HaveGarage(gh)) { return; }
            // No parameters in input, ask for them
            if (searchTerms.Length < 1)
            {
                searchTerms = askForInput.GetString("ANGE SÖK TERMER (MELLANSLAG ÄR AVDELARE): ").Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            // First get a list of all vehicles, which will be be filtered for each match
            List<IVehicle> intersectResult = gh.GetParkedVehicles().ToList();

            // Filters so only those terms that matches any of the props will stay, boolean AND
            foreach (var searchTerm in searchTerms)
            {
                intersectResult = intersectResult.Intersect(gh.FindAny(searchTerm)).ToList();
            }

            ShowSearchResults(intersectResult);
        }
        internal void FindByProp(string[] searchTerms)
        {
            if (!HaveGarage(gh)) { return; }

            // Gets the possible props of the vehicles stored in the garage
            var uniqueSearchTermsAvailable = gh.GetSearchTerms();
            // Failsafe check if a null return
            if (uniqueSearchTermsAvailable == null) { return; }

            // No parameters in input, ask for them
            if (searchTerms.Length < 1)
            {
                // No parameters to the command, show available props (search terms) and an example
                foreach (var searchTerm in uniqueSearchTermsAvailable)
                {
                    ui.OutputData($"{searchTerm.Key,7} {searchTerm.Value}\n");
                }
                ui.OutputData("EXEMPEL PÅ SÖKNING: 'type:car color:blue', 'ps:diesel wheels:4'\n");
                searchTerms = askForInput.GetString("ANGE SÖK TERMER (MELLANSLAG ÄR AVDELARE): ").Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            // If no search terms are provided, return
            if (searchTerms.Length < 1) { return; }
            int validSearchTerms = 0;

            // First get a list of all vehicles, which will be be filtered for each match
            List<IVehicle> intersectResult = gh.GetParkedVehicles().ToList();

            // Keep only the results that matches the selected props, boolean AND:ish
            foreach (var searchTerm in searchTerms)
            {
                // Split each search term ("vehicleProp:searchText") into it's parts
                string[] searchData = searchTerm.Split(":", StringSplitOptions.RemoveEmptyEntries);
                // If prop or text terms are missing, skip this search term
                if (searchData.Length != 2) { continue; }
                string vehicleProp = searchData[0];
                string searchText = searchData[1];
                // Skip if not a valid search term
                if (!uniqueSearchTermsAvailable.ContainsKey(vehicleProp.ToLower())) { continue;                }
                // Count how many valid search terms entered by user
                validSearchTerms++;
                intersectResult = intersectResult.Intersect(gh.FindByProp(vehicleProp, searchText)).ToList();
            }
            // If no valid search terms are provided, show nothing
            if (validSearchTerms < 1) { return; }
            ShowSearchResults(intersectResult);

        }
        internal void FindByRegistration(string[] rnToFind)
        {
            if (!HaveGarage(gh)) { return; }
            string searchString;
            // No parameters in input, ask for it
            if (rnToFind.Length < 1)
            {
                searchString = askForInput.GetString("VILKET REGISTRERINGSNUMMER VILL DU SÖKA EFTER?\n");
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
                ui.OutputData("*** GARAGE SAKNAS\n");
                return false;
            }
            return true;
        }
    }
}
