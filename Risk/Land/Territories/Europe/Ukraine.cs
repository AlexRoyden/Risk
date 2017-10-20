namespace Risk.Land.Territories.Europe
{
    class Ukraine : ITerritory
    {
        public enum Neighbours { Ural = 1, Afghanistan, MiddleEast, SouthernEurope, NorthernEurope, Scandanavia };

        public int Occupant { get; set; }

        public int Armies { get; set; }
    }
}