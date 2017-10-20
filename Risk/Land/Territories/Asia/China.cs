namespace Risk.Land.Territories.Asia
{
    class China : ITerritory
    {
        public enum Neighbours { Mongolia = 1, SoutheastAsia, India, Afghanistan, Ural, Siberia };

        public int Occupant { get; set; }

        public int Armies { get; set; }
    }
}