﻿using Exercise_5_Garage.Vehicles;
using Exercise_5_Garage.VehicleStorageFacilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5_Garage.Handlers
{
    public class GarageHandler<T> where T : IVehicle
    {
        private Garage<T> garageToHandle;

        public GarageHandler(Garage<T> garage)
        {
            garageToHandle = garage;
        }

        public bool ParkVehicle(T vehicle)
        {
            return garageToHandle.ParkVehicle(vehicle);
        }
        //public void UnParkVehicle(IVehicle vehicle) 
        public bool UnParkVehicle(int id)
        {
            return garageToHandle.UnParkVehicle(id);
        }

        public IEnumerable<IVehicle> GetParkedVehicles()
        {
            return (IEnumerable<IVehicle>)garageToHandle.ToList();
        }

        public int GetNumberOfAvailableParkingSpots()
        {
            return garageToHandle.GetNumberOfAvailableParkingSpots();
        }

        public int NumberOfParkedVehicles()
        {
            return garageToHandle.NumberOfParkedVehicles();
        }
    }
}


//En GarageHandler.För att abstrahera ett lager så att det inte finns någon direkt
//kontakt mellan användargränssnittet och garage klassen.Detta görs lämpligen
//genom en klass som hanterar funktionaliteten som gränssnittet behöver ha
//tillgång till.