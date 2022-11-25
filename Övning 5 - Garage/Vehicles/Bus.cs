using Exercise_5_Garage.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5_Garage.Vehicles
{
    public class Bus : Vehicle
    {
        public int NumberOfSeats { get; protected set; }
        public Bus(string brandAndModel, string color, int numberOfWheels, string powerSource, string registrationNumber, int numberOfSeats) : base(brandAndModel, color, numberOfWheels, powerSource, registrationNumber)
        {
            NumberOfSeats = numberOfSeats;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {NumberOfSeats}";
        }
    }
}
