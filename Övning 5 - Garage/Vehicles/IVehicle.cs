using Exercise_5_Garage.Types;

namespace Exercise_5_Garage.Vehicles
{
    public interface IVehicle
    {
        string BrandAndModel { get; set; }   
        string Color { get; set; }
        int NumberOfWheels { get; set; }
        string PowerSource { get; set; }
        string RegistrationNumber { get; set; }
        string GetVehicleType();
        bool MatchesAny(string searchText);
        bool MatchesProp(string vehicleProp, string searchText);
    }
}