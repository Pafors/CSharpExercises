using Exercise_5_Garage.Types;

namespace Exercise_5_Garage.Vehicles
{
    public interface IVehicle
    {
        string BrandAndModel { get; set; }   
        string Color { get; set; }
        int NumberOfWheels { get; set; }
        PowerType PowerSource { get; set; }
        string RegistrationNumber { get; set; }
    }
}