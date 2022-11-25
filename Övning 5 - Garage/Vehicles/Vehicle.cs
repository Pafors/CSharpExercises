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
            return $"{BrandAndModel}, {Color}, {NumberOfWheels}, {PowerSource}, {RegistrationNumber}";
        }

        public virtual bool Matches(string searchText)
        {
            return BrandAndModel.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                Color.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                NumberOfWheels.ToString().Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                PowerSource.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                RegistrationNumber.Contains(searchText, StringComparison.OrdinalIgnoreCase);
        }
    }

}
