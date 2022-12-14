namespace Exercise_5_Garage.Vehicles
{
    public class Boat : Vehicle
    {
        public int Length { get; protected set; }
        public double Draft { get; protected set; }
        public Boat(string brandAndModel, string color, int numberOfWheels, string powerSource, string registrationNumber, int length, double draft) : base(brandAndModel, color, numberOfWheels, powerSource, registrationNumber)
        {
            Length = length;
            Draft = draft;
            SearchTerms.Add("l", "Length (boat)");
            SearchTerms.Add("d", "Draft (boat)");
        }
        public Boat() {
            SearchTerms.Add("l", "Length (boat)");
            SearchTerms.Add("d", "Draft (boat)");
            InputProperties.Add("Length", "LÄNGD");
            InputProperties.Add("Draft", "DJUPGÅNG");
        }
        public override string ToString()
        {
            return $"{base.ToString()}, LÄNGD: {Length} m, DJUP: {Draft} m";
        }
        public override bool MatchesAny(string searchText)
        {
            return base.MatchesAny(searchText) || 
                Length.ToString() == searchText ||
                Draft.ToString() == searchText;
        }
        public override bool MatchesProp(string vehicleProp, string searchText)
        {
            switch (vehicleProp.ToLower())
            {
                case "l":
                    return Length.ToString() == searchText;
                case "d":
                    return Draft.ToString() == searchText;
                default:
                    return base.MatchesProp(vehicleProp, searchText);
            }
        }
    }
}
