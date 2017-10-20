namespace Risk.Land.Territories.Asia
{
    class Japan : ITerritory
    {
        public enum Neighbours { Kamchatka = 1, Mongolia };

        public int Occupant { get; set; }

        public int Armies { get; set; }
    }
}