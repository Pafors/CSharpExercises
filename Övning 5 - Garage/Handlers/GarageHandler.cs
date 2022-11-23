using Exercise_5_Garage.Vehicles;
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
            // TODO FIX park
            return garageToHandle.ParkVehicle(vehicle);
        }
        public void UnParkVehicle(IVehicle vehicle) 
        {
            // TODO garageToHandle.remove(vehicle)
        }
    }
}


//En GarageHandler.För att abstrahera ett lager så att det inte finns någon direkt
//kontakt mellan användargränssnittet och garage klassen.Detta görs lämpligen
//genom en klass som hanterar funktionaliteten som gränssnittet behöver ha
//tillgång till.