﻿using Exercise_5_Garage.Types;
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
            SearchTerms.Add("ns", "Number of seats (bus)");
        }
        public override string ToString()
        {
            return $"{base.ToString()}, ANTAL SÄTEN: {NumberOfSeats}";
        }
        public override bool MatchesAny(string searchText)
        {
            return base.MatchesAny(searchText) || NumberOfSeats.ToString() == searchText;
        }
        public override bool MatchesProp(string vehicleProp, string searchText)
        {
            switch (vehicleProp.ToLower())
            {
                case "ns":
                    return NumberOfSeats.ToString() == searchText;
                default:
                    return base.MatchesProp(vehicleProp, searchText);
            }
        }
    }
}
