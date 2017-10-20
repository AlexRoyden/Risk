namespace Risk.Land.Territories.Asia
{
    class Afghanistan : ITerritory
    {
        public enum Neighbours { Ural = 1, China, India, MiddleEast, Ukraine };

        public int Occupant { get; set; }

        public int Armies { get; set; }
    }
}