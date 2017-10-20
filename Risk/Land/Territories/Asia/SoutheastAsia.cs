namespace Risk.Land.Territories.Asia
{
    class SoutheastAsia : ITerritory
    {
        public enum Neighbours { China = 1, Indonesia, India };

        public int Occupant { get; set; }

        public int Armies { get; set; }
    }
}