namespace Risk.Land.Territories.Europe
{
    class WesternEurope : ITerritory
    {
        public enum Neighbours { GreatBritain = 1, NorthernEurope, SouthernEurope, NorthAfrica }

        public int Occupant { get; set; }

        public int Armies { get; set; }
    }
}