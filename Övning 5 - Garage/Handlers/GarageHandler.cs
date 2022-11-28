using Exercise_5_Garage.Vehicles;
using Exercise_5_Garage.VehicleStorageFacilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5_Garage.Handlers
{
    public class GarageHandler<T> : IGarageHandler<T> where T : IVehicle
    {
        private Garage<T>? garageToHandle;
        public GarageHandler() { }
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
        public (bool, string) ParkVehicle(T vehicle)
        {
            if (garageToHandle == null) { return (false, "Garage saknas"); }
            (bool result, string reason) = garageToHandle.ParkVehicle(vehicle);
            return (result, reason);
        }
        public bool UnParkVehicle(string registrationNumber)
        {
            if (garageToHandle == null) { return false; }
            return garageToHandle.UnParkVehicle(registrationNumber);
        }
        public IEnumerable<IVehicle> GetParkedVehicles()
        {
            if (garageToHandle == null) { return Enumerable.Empty<IVehicle>(); }
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
        public int GetSizeOfGarage()
        {
            if (garageToHandle == null) { return 0; }
            return garageToHandle.GetSize();
        }
        public IEnumerable<IVehicle> FindAny(string searchTerm)
        {
            if (garageToHandle == null) { return Enumerable.Empty<IVehicle>(); }
            return garageToHandle.FindAny(searchTerm);
        }
        public IEnumerable<IVehicle> FindByProp(string vehicleProp, string searchText)
        {
            if (garageToHandle == null) { return Enumerable.Empty<IVehicle>(); }
            return garageToHandle.FindByProp(vehicleProp, searchText);
        }
        public IEnumerable<IVehicle> FindByRegistration(string searchTerm)
        {
            if (garageToHandle == null) { return Enumerable.Empty<IVehicle>(); }
            return garageToHandle.FindByRegistration(searchTerm);
        }
        public List<string> GetAllRegistrationNumbers()
        {
            if (garageToHandle == null)
            {
                return new List<string>();
            }
            return garageToHandle.GetAllRegistrationNumbers();
        }
        public bool HaveAGarage()
        {
            return garageToHandle != null;
        }
        public IEnumerable<Type> GetVehicleTypes()
        {
            //return new List<string>() { "Airplane", "Boat", "Bus", "Car", "Motorcycle" };

            var type = typeof(IVehicle);
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsAbstract);
        }
        public Dictionary<string, string> GetSearchTerms()
        {
            if (garageToHandle == null) return new Dictionary<string, string>();
                return garageToHandle.GetSearchTerms();
        }
    }
}


//En GarageHandler.För att abstrahera ett lager så att det inte finns någon direkt
//kontakt mellan användargränssnittet och garage klassen.Detta görs lämpligen
//genom en klass som hanterar funktionaliteten som gränssnittet behöver ha
//tillgång till.