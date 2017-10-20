namespace Risk.Land.Territories.Asia
{
    class Yakutsk : ITerritory
    {
        public enum Neighbours { Kamchatka = 1, Irkutsk, Siberia };

        public int Occupant { get; set; }

        public int Armies { get; set; }
    }
}