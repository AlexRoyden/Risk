namespace Risk.Land.Territories.Europe
{
    class NorthenEurope : ITerritory
    {
        public enum Neighbours { Scandanavia = 1, Ukraine, SouthernEurope, WesternEurope };

        public int Occupant { get; set; }

        public int Armies { get; set; }
    }
}