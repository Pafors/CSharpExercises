using Exercise_5_Garage.Types;
using Exercise_5_Garage.Vehicles;

namespace Exercise_5_Garage.VehicleStorageFacilities
{
    public interface IGarage<T> : IEnumerable<T> where T : IVehicle
    {
        Medium TransportType { get; }

        List<int> AvailableParkingSpots();
        IEnumerable<IVehicle> FindAny(string searchTerm);
        IEnumerable<IVehicle> FindByProp(string vehicleProp, string searchText);
        IEnumerable<IVehicle> FindByRegistration(string searchTerm);
        List<string> GetAllRegistrationNumbers();
        //IEnumerator<T> GetEnumerator(); // TODO XXXXXX
        int GetNumberOfAvailableParkingSpots();
        Dictionary<string, string> GetSearchTerms();
        int GetSize();
        int NumberOfParkedVehicles();
        (bool, string) ParkVehicle(T vehicle);
        bool UnParkVehicle(string registrationNumber);
    }
}