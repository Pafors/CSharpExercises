using Exercise_5_Garage.Handlers;
using Exercise_5_Garage.Types;
using Exercise_5_Garage.UI;
using Exercise_5_Garage.Vehicles;
using Exercise_5_Garage.VehicleStorageFacilities;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5_Garage
{
    internal class Manager
    {
        private readonly IUI ui;
        
        public Manager(IUI ui)
        {
            this.ui = ui;
        }

        internal void StartUp()
        {
            var g = new Garage<IVehicle>(10);
            var gh = new GarageHandler<IVehicle>(g);
            ui.OutputData($"Before: {g.NumberOfParkedVehicles()}\n");
            gh.ParkVehicle(new Car("Volvo 240", "Blue", 4, PowerType.Diesel, "JAC495", convertible: false ));
            gh.ParkVehicle(new Car("Honda CRV", "Silver", 4, PowerType.Petrol, "QWE123", convertible: false ));
            gh.ParkVehicle(new Bus("Scania", "Red", 8, PowerType.Diesel, "BUS042", 40));
            ui.OutputData($"After: {g.NumberOfParkedVehicles()}\n");
            foreach (var v in g)
            {
                ui.OutputData($"{v}\n");
            }
            ui.OutputData($"Free parking spots: {g.NumberOfFreeParkingSpots()}\n");
            foreach (var spot in g.FreeParkingSpots())
            {
                ui.OutputData($"{spot} ");
            }
        }
    }
}
