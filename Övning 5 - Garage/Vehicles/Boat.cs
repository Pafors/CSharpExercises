using Exercise_5_Garage.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5_Garage.Vehicles
{
    public class Boat : Vehicle
    {
        public int Length { get; protected set; }
        public int Draft { get; protected set; }
        public Boat(string brandAndModel, string color, int numberOfWheels, PowerType powerSource, string registrationNumber, int length, int draft) : base(brandAndModel, color, numberOfWheels, powerSource, registrationNumber)
        {
            Length = length;
            Draft = draft;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {Length}, {Draft}";
        }
    }
}
