using Exercise_5_Garage.Vehicles;
using Exercise_5_Garage;
using Exercise_5_Garage.UI;
using Exercise_5_Garage.Handlers;

IUI ui = new ConsoleUI();
IGarageHandler<IVehicle> gh = new GarageHandler<IVehicle>();
ArgumentNullException.ThrowIfNull(gh);
//var storageFacilityManager = new Manager(ui, new GarageHandler<IVehicle>(new Garage<IVehicle>(4)));
var storageFacilityManager = new Manager(ui, gh);
storageFacilityManager.StartUpLoop();
