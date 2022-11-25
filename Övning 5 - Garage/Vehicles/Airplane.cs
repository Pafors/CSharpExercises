using Exercise_5_Garage.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5_Garage.Vehicles
{
    public class Airplane : Vehicle
    {
        public int NumberOfEngines { get; protected set; }
        public Airplane(string brandAndModel, string color, int numberOfWheels, string powerSource, string registrationNumber, int numberOfEngines) : base(brandAndModel, color, numberOfWheels, powerSource, registrationNumber)
        {
            NumberOfEngines = numberOfEngines;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {NumberOfEngines}";
        }

    }
}
