namespace Risk.Land.Territories.Asia
{
    class India : ITerritory
    {
        public enum Neighbours { China = 1, SoutheastAsia, MiddleEast, Afghanistan };

        public int Occupant { get; set; }

        public int Armies { get; set; }
    }
}