namespace Risk.Land.Territories.Australia
{
    class NewGuinea : ITerritory
    {
        public enum Neighbours { EastenAustralia = 1, WesternAustralia, Indonesia };

        public int Occupant { get; set; }

        public int Armies { get; set; }
    }
}