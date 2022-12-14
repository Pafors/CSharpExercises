namespace Exercise_5_Garage.Vehicles
{
    public class Motorcycle : Vehicle
    {
        public int CylinderVolume { get; protected set; }
        public Motorcycle(string brandAndModel, string color, int numberOfWheels, string powerSource, string registrationNumber, int cylinderVolume) : base(brandAndModel, color, numberOfWheels, powerSource, registrationNumber)
        {
            CylinderVolume = cylinderVolume;
            SearchTerms.Add("cv", "Cylinder volume (motorcycle)");
        }
        public Motorcycle() {
            SearchTerms.Add("cv", "Cylinder volume (motorcycle)");
            InputProperties.Add("CylinderVolume", "CYLINDER VOLYM");
        }
        public override string ToString()
        {
            return $"{base.ToString()}, CYLINDERVOLYM: {CylinderVolume} cc";
        }
        public override bool MatchesAny(string searchText)
        {
            return base.MatchesAny(searchText) || CylinderVolume.ToString() == searchText;
        }
        public override bool MatchesProp(string vehicleProp, string searchText)
        {
            switch (vehicleProp.ToLower())
            {
                case "cv":
                    return CylinderVolume.ToString() == searchText;
                default:
                    return base.MatchesProp(vehicleProp, searchText);
            }
        }
    }
}
