namespace Risk.Land.Territories.Australia
{
    class Indonesia : ITerritory
    {
        public enum Neighbours { NewGuinea = 1, SoutheastAsia };

        public int Occupant { get; set; }

        public int Armies { get; set; }
    }
}