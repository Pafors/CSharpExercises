﻿using Exercise_5_Garage.Types;
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
            string trueFalseString = Convertible? "Ja" : "Nej";
            return $"{base.ToString()}, CABRIOLET: {trueFalseString}";
        }
        public override bool MatchesAny(string searchText)
        {
            return base.MatchesAny(searchText) || 
                Convertible && 
                (searchText.Contains("cab", StringComparison.OrdinalIgnoreCase) || searchText.Contains("conv", StringComparison.OrdinalIgnoreCase));
        }
        public override bool MatchesProp(string vehicleProp, string searchText)
        {
            bool checkFor;
            switch (searchText.ToLower())
            {
                case "yes":
                case "y":
                case "ja":
                case "j":
                    checkFor = true;
                    break;
                case "no":
                case "nej":
                case "n":
                    checkFor= false;
                    break;
                default:
                    // Putting in a "convertible:" and forgetting "yes/no" is probably a "yes"
                    checkFor= true;
                    break;
            }
            switch (vehicleProp.ToLower())
            {
                case "convertible":
                case "cabrilolet":
                case "conv":
                case "cab":
                    return Convertible == checkFor;
                default:
                    return base.MatchesProp(vehicleProp, searchText);
            }
        }
    }

}
