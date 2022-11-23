using Exercise_5_Garage.Types;
using Exercise_5_Garage.Vehicles;
using System.Collections;
using System.Collections.Generic;

namespace Exercise_5_Garage.VehicleStorageFacilities
{
    // TODO Vidare ska det gå att iterera över en instans av Garage med hjälp av
    // foreach. Det innebär att Garage ska implementera den generiska varianten
    // av interfacet IEnumerable:
    public class Garage<T> : IEnumerable<T> where T : IVehicle
    {
        private readonly T[] vehicleStorage;
        private readonly int size;
        private int count = 0;
        public Medium TransportType { get; private set; }
        public Garage(int garageSizeWanted, Medium transportType = Medium.Land)
        {
            // Handle negative sizes of garage sizes
            int garageSize = garageSizeWanted < 0 ? 0 : garageSizeWanted;
            vehicleStorage = new T[garageSize];
            TransportType = transportType;
            size = garageSize;
            // TODO Vid instansieringen av ett nytt garage måste kapaciteten anges som argument till konstruktorn.
        }

        //public IEnumerator<T> GetEnumerator() => vehicleStorage.GetEnumerator();
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var vehicle in vehicleStorage)
            {
                //Console.WriteLine($"{vehicle.BrandAndModel}");
                if (vehicle != null)
                { yield return vehicle; }
                else
                {
                    Console.WriteLine("NULL");
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


        public bool ParkVehicle(T vehicle)
        {
            int? freeParkingSpot = null;
            freeParkingSpot = FreeParkingSpots().FirstOrDefault();
            if (freeParkingSpot == null)
            {
                return false;
            }

            // TODO Fix to store on empty spots
            vehicleStorage[(int)freeParkingSpot] = vehicle;
            count++;
            return true;
        }

        //public bool UnParkVehicle(T vehicle)
        //{

        //}

        public int NumberOfParkedVehicles()
        {
            return count;
        }

        public List<int> FreeParkingSpots()
        {
            // Build a new anonymous object with array index and vehicle data, then
            // find the first "null" and return the index. Return the index found as a list.
            return vehicleStorage.Select((v, i) => new { Index = i, Vehicle = v }) // Pair up values and indexes
                                    .Where(p => p.Vehicle == null) // Do the filtering
                                    .Select(p => p.Index).ToList(); // Keep the index and drop the value
        }
        public int NumberOfFreeParkingSpots()
        {
            // Count the values in the list
            return FreeParkingSpots().Count();
        }

    }
}
