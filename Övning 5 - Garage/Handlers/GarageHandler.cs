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
        // TODO Make it an "IGarage"
        private Garage<T>? garageToHandle;

        public GarageHandler()
        { }
        public GarageHandler(Garage<T> garage)
        {
            garageToHandle = garage;
        }

        public void newGarage(int wantedSize)
        {
            SetGarageToHandle(new Garage<T>(wantedSize));
        }

        public void SetGarageToHandle(Garage<T> garage)
        {
            if(garage != null)
            { 
                garageToHandle = garage;
            }
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
            // TODO Make it a copy/clone
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
        public IEnumerable<IVehicle> Find(string searchTerm)
        {
            // TODO Make safe copy/clone/string
            return garageToHandle.Find(searchTerm);
        }
        public bool HaveAGarage()
        {
            if (garageToHandle != null)
            {
                return true;
            }
            return false;
        }


    }
}


//En GarageHandler.För att abstrahera ett lager så att det inte finns någon direkt
//kontakt mellan användargränssnittet och garage klassen.Detta görs lämpligen
//genom en klass som hanterar funktionaliteten som gränssnittet behöver ha
//tillgång till.