namespace Risk.Land.Territories.Asia
{
    class MiddleEast : ITerritory
    {
        public enum Neighbours { Ukraine = 1, Afghanistan, India, EastAfrica, Egypt };

        public int Occupant { get; set; }

        public int Armies { get; set; }
    }
}