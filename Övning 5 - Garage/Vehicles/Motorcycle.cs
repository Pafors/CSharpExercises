using Exercise_5_Garage.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5_Garage.Vehicles
{
    public class Motorcycle : Vehicle
    {
        public int CylinderVolume { get; protected set; }
        public Motorcycle(string brandAndModel, string color, int numberOfWheels, string powerSource, string registrationNumber, int cylinderVolume) : base(brandAndModel, color, numberOfWheels, powerSource, registrationNumber)
        {
            CylinderVolume = cylinderVolume;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {CylinderVolume}";
        }

    }
}
