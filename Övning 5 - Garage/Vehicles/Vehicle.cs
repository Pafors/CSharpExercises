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
        // TODO change from "set" to "init"?
        public string BrandAndModel { get; set; }
        public string Color { get; set; }
        public int NumberOfWheels { get; set; }
        public string PowerSource { get; set; }
        public string RegistrationNumber { get; set; }
        public Vehicle(string brandAndModel, string color, int numberOfWheels, string powerSource, string registrationNumber)
        {
            BrandAndModel = brandAndModel;
            Color = color;
            NumberOfWheels = numberOfWheels;
            PowerSource = powerSource;
            RegistrationNumber = registrationNumber;
        }
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
                case "typ":
                case "t":
                    return GetVehicleType().Contains(searchText, StringComparison.OrdinalIgnoreCase);
                case "brandandmodel":
                case "brand":
                case "märke":
                case "model":
                case "modell":
                case "bm":
                    return BrandAndModel.Contains(searchText, StringComparison.OrdinalIgnoreCase);
                case "color":
                case "colour":
                case "färg":
                    return Color.Contains(searchText, StringComparison.OrdinalIgnoreCase);
                case "wheels":
                case "numwheels":
                case "nwheels":
                case "nw":
                    return NumberOfWheels.ToString() == searchText;
                case "powersource":
                case "power":
                case "fuel":
                case "ps":
                    return PowerSource.Contains(searchText, StringComparison.OrdinalIgnoreCase);
                case "registrationnumber":
                case "regnum":
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
