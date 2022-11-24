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

        public void NewGarage(int wantedSize)
        {
            SetGarageToHandle(new Garage<T>(wantedSize));
        }

        public void SetGarageToHandle(Garage<T> garage)
        {
            if (garage != null)
            {
                garageToHandle = garage;
            }
        }

        public bool ParkVehicle(T vehicle)
        {
            if (garageToHandle == null) { return false; }
            return garageToHandle.ParkVehicle(vehicle);
        }
        //public void UnParkVehicle(IVehicle vehicle) 
        public bool UnParkVehicle(int id)
        {
            if (garageToHandle == null) { return false; }
            return garageToHandle.UnParkVehicle(id);
        }

        public IEnumerable<IVehicle> GetParkedVehicles()
        {
            if (garageToHandle == null) { return Enumerable.Empty<IVehicle>(); }
            // TODO Make it a copy/clone
            return (IEnumerable<IVehicle>)garageToHandle.ToList();
        }

        public IEnumerable<List<IVehicle>> GetParkedVehiclesByType()
        { 
            if (garageToHandle == null)
            { 
                return Enumerable.Empty<List<IVehicle>>();
            }    
            return (IEnumerable<List<IVehicle>>)garageToHandle.GroupBy(v => v.GetType()).ToList();
        }
        public int GetNumberOfAvailableParkingSpots()
        {
            if (garageToHandle == null) { return 0; }
            return garageToHandle.GetNumberOfAvailableParkingSpots();
        }

        public int NumberOfParkedVehicles()
        {
            if (garageToHandle == null) { return 0; }
            return garageToHandle.NumberOfParkedVehicles();
        }
        public IEnumerable<IVehicle> FindByRegistration(string searchTerm)
        {
            if (garageToHandle == null) { return Enumerable.Empty<IVehicle>(); }
            // TODO Make safe copy/clone/string
            return garageToHandle.FindByRegistration(searchTerm);
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