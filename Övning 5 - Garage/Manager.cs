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
        private GarageHandler<IVehicle> gh;
        
        public Manager(IUI ui)
        {
            this.ui = ui;
        }

        internal void StartUp()
        {
            gh = new GarageHandler<IVehicle>(new Garage<IVehicle>(4));

            ui.OutputData($"Parked before: {gh.NumberOfParkedVehicles()}\n");
            gh.ParkVehicle(new Car("Volvo 240", "Blue", 4, PowerType.Diesel, "JAC495", convertible: false ));
            gh.ParkVehicle(new Car("Honda CRV", "Silver", 4, PowerType.Petrol, "QWE123", convertible: false ));
            gh.ParkVehicle(new Bus("Scania", "Green", 8, PowerType.Diesel, "BUS042", 40));
            gh.ParkVehicle(new Bus("Scania", "Yellow", 8, PowerType.Diesel, "BUS043", 40));
            gh.ParkVehicle(new Bus("Scania", "Red", 8, PowerType.Diesel, "BUS044", 40));
            ui.OutputData($"Parked after: {gh.NumberOfParkedVehicles()}\n");
            foreach (var v in gh.GetParkedVehicles())
            {
                ui.OutputData($"Vehicle before: {v}\n");
            }
            ui.OutputData("---\n");
            gh.UnParkVehicle(1);
            gh.ParkVehicle(new Bus("Scania", "Pink", 8, PowerType.Diesel, "BUS044", 40));
            
            foreach (var v in gh.GetParkedVehicles())
            {
                ui.OutputData($"Vehicle after: {v}\n");
            }

            ui.OutputData($"Free parking spots: {gh.GetNumberOfAvailableParkingSpots()}\n");
  
        }
    }
}
