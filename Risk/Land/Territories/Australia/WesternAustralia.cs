namespace Risk.Land.Territories.Australia
{
    class WesternAustralia : ITerritory
    {
        public enum Neighbours { NewGuinea = 1, EasternAustralia };

        public int Occupant { get; set; }

        public int Armies { get; set; }
    }
}