using Exercise_5_Garage.Vehicles;
using Exercise_5_Garage.VehicleStorageFacilities;

namespace Exercise_5_Garage.Handlers
{
    public interface IGarageHandler<T> where T : IVehicle
    {
        IEnumerable<IVehicle> FindAny(string searchTerm);
        IEnumerable<IVehicle> FindByProp(string vehicleProp, string searchText);
        IEnumerable<IVehicle> FindByRegistration(string searchTerm);
        List<string> GetAllRegistrationNumbers();
        int GetNumberOfAvailableParkingSpots();
        IEnumerable<IVehicle> GetParkedVehicles();
        IEnumerable<List<IVehicle>> GetParkedVehiclesByType();
        int GetSizeOfGarage();
        IEnumerable<Type> GetVehicleTypes();
        bool HaveAGarage();
        void NewGarage(int wantedSize);
        int NumberOfParkedVehicles();
        (bool, string) ParkVehicle(T vehicle);
        void SetGarageToHandle(IGarage<T> garage);
        bool UnParkVehicle(string registrationNumber);
        Dictionary<string, string> GetSearchTerms();
    }
}