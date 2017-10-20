namespace Risk.Land.Territories.Europe
{
    class SouthernEurope : ITerritory
    {
        public enum Neighbours { NorthernEurope = 1, Ukraine, Egypt, NorthAfrica, WesternEurope };

        public int Occupant { get; set; }

        public int Armies { get; set; }
    }
}