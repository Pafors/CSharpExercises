using Exercise_5_Garage.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5_Garage.Vehicles
{
    public class Car : Vehicle
    {
        public bool Convertible { get; protected set; }

        public Car(string brandAndModel, string color, int numberOfWheels, string powerSource, string registrationNumber, bool convertible) : base(brandAndModel, color, numberOfWheels, powerSource, registrationNumber)
        {
            Convertible= convertible;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {Convertible}";
        }

        public override bool Matches(string searchText)
        {
            return base.Matches(searchText) || 
                Convertible && 
                (searchText.Contains("cab", StringComparison.OrdinalIgnoreCase) || searchText.Contains("conv", StringComparison.OrdinalIgnoreCase));
        }
    }

}
