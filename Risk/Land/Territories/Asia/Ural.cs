namespace Risk.Land.Territories.Asia
{
    class Ural : ITerritory
    {
        public enum Neighbours { Siberia = 1, China, Afghanistan, Ukraine };

        public int Occupant { get; set; }

        public int Armies { get; set; }
    }
}