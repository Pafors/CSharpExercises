using Exercise_5_Garage.Types;
using Exercise_5_Garage.Vehicles;
using System.Collections;

namespace Exercise_5_Garage.VehicleStorageFacilities
{
    public class Garage<T> : IEnumerable<T>, IGarage<T> where T : IVehicle
    {
        private T?[] vehicleStorage;
        private readonly int size;
        public Medium TransportType { get; private set; }
        public Garage(int garageSizeWanted, Medium transportType = Medium.Land)
        {
            // Handle negative sizes of garage sizes, set to "0" if negative
            int garageSize = garageSizeWanted < 0 ? 0 : garageSizeWanted;
            vehicleStorage = new T[garageSize];
            TransportType = transportType;
            size = garageSize;
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var vehicle in vehicleStorage)
            {
                if (vehicle != null)
                { yield return vehicle; }
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public (bool, string) ParkVehicle(T vehicle)
        {
            // Don't accept a vehicle that has the same registration numbers as an already parked vehicle
            if (GetAllRegistrationNumbers().Contains(vehicle.RegistrationNumber, StringComparer.OrdinalIgnoreCase))
            { return (false, "DUBLETT AV REGISTRERINGSNUMMER"); }
            // Find the first available free "parking spot" ("null") in the array
            int? freeParkingSpot;
            var availableParkingSpots = AvailableParkingSpots();
            freeParkingSpot = availableParkingSpots.FirstOrDefault();
            // No available, return false from the operation
            if (availableParkingSpots.Count == 0 || freeParkingSpot == null)
            {
                return (false, "GARAGET FULLT");
            }
            // Spot found, park the vehicle
            vehicleStorage[(int)freeParkingSpot] = vehicle;
            return (true, "");
        }
        public bool UnParkVehicle(string registrationNumber)
        {
            // Unpark and set to the default ("null") value to indicate free parking slot
            for (int i = 0; i < vehicleStorage.Length; i++)
            {
                if (vehicleStorage[i] == null) { continue; }
                if (vehicleStorage[i]!.RegistrationNumber.ToLower() == registrationNumber.ToLower())
                {
                    vehicleStorage[i] = default(T);
                    return true;
                }
            }
            return false;
        }
        public int NumberOfParkedVehicles()
        {
            return size - GetNumberOfAvailableParkingSpots();
        }
        public List<int> AvailableParkingSpots()
        {
            // Build a new anonymous object with array index and vehicle data, then find
            // the first "null" and return the index. Return all the index found as a list.
            return vehicleStorage.Select((v, i) => new { Index = i, Vehicle = v })
                                 .Where(p => p.Vehicle == null)
                                 .Select(p => p.Index).ToList();
        }
        public int GetNumberOfAvailableParkingSpots()
        {
            // Count the values in the list
            return AvailableParkingSpots().Count;
        }
        public IEnumerable<IVehicle> FindAny(string searchTerm)
        {
            // Iterate through all the vehicles and check for a match
            return (IEnumerable<IVehicle>)vehicleStorage
                .Where(v => v != null && v.MatchesAny(searchTerm));
        }
        public IEnumerable<IVehicle> FindByProp(string vehicleProp, string searchText)
        {
            // Iterate through all the vehicles and check for a match
            return (IEnumerable<IVehicle>)vehicleStorage
               .Where(v => v != null && v.MatchesProp(vehicleProp, searchText));
        }
        public IEnumerable<IVehicle> FindByRegistration(string searchTerm)
        {
            // Iterate through all the vehicles and check for a match
            return (IEnumerable<IVehicle>)vehicleStorage
                .Where(v => v != null && v.RegistrationNumber.ToUpper().Contains(searchTerm.ToUpper()));
        }
        public int GetSize()
        {
            return size;
        }
        public List<string> GetAllRegistrationNumbers()
        {
            // Iterate through all the vehicles and return all the registration numbers as a list
            return vehicleStorage.Where(v => v != null).Select(v => v!.RegistrationNumber).ToList();
        }
        public Dictionary<string, string> GetSearchTerms()
        {
            Dictionary<string, string> mergedTerms = new();
            // Iterate through all the vehicles and make a dictionary of all possible search terms for properties
            foreach (var vehicle in vehicleStorage)
            {
                if (vehicle == null) continue;
                mergedTerms = mergedTerms.Union(vehicle.GetSearchTerms()).ToDictionary(pair => pair.Key, pair => pair.Value);
            }
            return mergedTerms;
        }
    }
}
