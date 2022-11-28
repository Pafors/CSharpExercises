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
            return $"{base.ToString()}, ANTAL MOTORER: {NumberOfEngines}";
        }
        public override bool MatchesAny(string searchText)
        {
            return base.MatchesAny(searchText) || NumberOfEngines.ToString() == searchText;
        }
        public override bool MatchesProp(string vehicleProp, string searchText)
        {
            switch (vehicleProp.ToLower())
            {
                case "numberofengines":
                case "numengines":
                case "negines":
                case "ne":
                    return NumberOfEngines.ToString() == searchText;
                default:
                    return base.MatchesProp(vehicleProp, searchText);
            }
        }
    }
}
