using Exercise_5_Garage.Types;
using Exercise_5_Garage.Vehicles;
using System.Collections;
using System.Collections.Generic;

namespace Exercise_5_Garage.VehicleStorageFacilities
{
    public class Garage<T> : IEnumerable<T> where T : IVehicle
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

        public bool ParkVehicle(T vehicle)
        {
            // Find the first available free "parking spot" in the array
            int? freeParkingSpot;
            var availableParkingSpots = AvailableParkingSpots();
            freeParkingSpot = availableParkingSpots.FirstOrDefault();
            // No available, return false from the operation
            if (availableParkingSpots.Count == 0 || freeParkingSpot == null)
            {
                return false;
            }
            // Spot found, park the vehicle
            vehicleStorage[(int)freeParkingSpot] = vehicle;
            return true;
        }

        public bool UnParkVehicle(string registrationNumber)
        {
            //var matchingVehicles = FindByRegistration(registrationNumber);
            //if (matchingVehicles != null && matchingVehicles.Count() != 1)
            //{
            //    return false;
            //}

            // Check for valid id (array index)
            //if (id < 0 || id > size || vehicleStorage[id] == null)
            //{ return false; }
            //vehicleStorage[id] = default;

            for (int i = 0; i < vehicleStorage.Length; i++)
            {
                if (vehicleStorage[i] == null) { continue; }
                if (vehicleStorage[i]!.RegistrationNumber.ToUpper() == registrationNumber.ToUpper())
                { 
                    vehicleStorage[i] = default(T); 
                    return true; 
                }
            }
            return false;
            
            //var onlyMatch = matchingVehicles!.First();
            //var vehicleStorageUpdated = vehicleStorage.Where(v => v != null && !v.Equals(onlyMatch)).ToArray();
            //vehicleStorage = vehicleStorageUpdated;
            //foreach (var v in vehicleStorage)
            //{
            //    Console.WriteLine($"1: {v}");
            //}
            //foreach (var v in vehicleStorageUpdated)
            //{
            //    Console.WriteLine($"2: {v}");
            //}
            //return true;
        }

        public int NumberOfParkedVehicles()
        {
            return size - GetNumberOfAvailableParkingSpots();
        }

        public List<int> AvailableParkingSpots()
        {
            // Build a new anonymous object with array index and vehicle data, then
            // find the first "null" and return the index. Return the index found as a list.
            return vehicleStorage.Select((v, i) => new { Index = i, Vehicle = v })
                                 .Where(p => p.Vehicle == null)
                                 .Select(p => p.Index).ToList();
        }
        public int GetNumberOfAvailableParkingSpots()
        {
            // Count the values in the list
            return AvailableParkingSpots().Count;
        }

        public IEnumerable<IVehicle> FindByRegistration(string searchTerm)
        {
            // TODO Make safe copy/clone/string
            return (IEnumerable<IVehicle>)vehicleStorage
                .Where(v => v != null && v.RegistrationNumber.ToUpper().Contains(searchTerm.ToUpper()));
        }

        public int GetSize()
        {
            return size;
        }
    }
}
