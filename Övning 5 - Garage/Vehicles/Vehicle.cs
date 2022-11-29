using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise_5_Garage.Types;

namespace Exercise_5_Garage.Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        public string BrandAndModel { get; set; } = "";
        public string Color { get; set; } = "";
        public int NumberOfWheels { get; set; } = 0;
        public string PowerSource { get; set; } = "";
        public string RegistrationNumber { get; set; } = "";
        public Dictionary<string, string> SearchTerms = new() {
                { "type", "Type of vehicle" },
                { "bm", "Brand and model" },
                { "color", "Color" },
                { "wheels", "Number of wheels" },
                { "ps", "Power source" },
                { "rn", "Registration number" }
            };
        public Dictionary<string, string> InputProperties = new()
        {
            { "BrandAndModel", "MÄRKE OCH MODELL" },
            { "Color", "FÄRG" },
            { "NumberOfWheels", "ANTAL HJUL" },
            { "PowerSource", "DRIVMEDEL"},
            { "RegistrationNumber", "REGISTRERINGSNUMMER"}
        };
        public Vehicle(string brandAndModel, string color, int numberOfWheels, string powerSource, string registrationNumber)
        {
            BrandAndModel = brandAndModel;
            Color = color;
            NumberOfWheels = numberOfWheels;
            PowerSource = powerSource;
            RegistrationNumber = registrationNumber;
        }
        public Vehicle() { }
        public Dictionary<string, string> GetSearchTerms() => SearchTerms;
        public Dictionary<string, string> GetinputProperties() => InputProperties;
        public override string ToString()
        {
            return $"TYP: {GetVehicleType()}, MÄRKE MODELL: {BrandAndModel}, FÄRG: {Color}, ANTAL HJUL: {NumberOfWheels}, DRIVMEDEL: {PowerSource}, REG.NUMMER: {RegistrationNumber}";
        }
        public virtual bool MatchesAny(string searchText)
        {
            return GetVehicleType().Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                BrandAndModel.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                Color.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                NumberOfWheels.ToString() == searchText ||
                PowerSource.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                RegistrationNumber.Contains(searchText, StringComparison.OrdinalIgnoreCase);
        }
        public virtual bool MatchesProp(string vehicleProp, string searchText)
        {
            switch (vehicleProp.ToLower())
            {
                case "type":
                    return GetVehicleType().Contains(searchText, StringComparison.OrdinalIgnoreCase);
                case "bm":
                    return BrandAndModel.Contains(searchText, StringComparison.OrdinalIgnoreCase);
                case "color":
                    return Color.Contains(searchText, StringComparison.OrdinalIgnoreCase);
                case "wheels":
                    return NumberOfWheels.ToString() == searchText;
                case "ps":
                    return PowerSource.Contains(searchText, StringComparison.OrdinalIgnoreCase);
                case "rn":
                    return RegistrationNumber.Contains(searchText, StringComparison.OrdinalIgnoreCase);
                default:
                    return false;
            }
        }
        public string GetVehicleType()
        {
            string vehicleType = this.GetType().ToString().Split(".").Last();
            return vehicleType;
        }
    }
}
