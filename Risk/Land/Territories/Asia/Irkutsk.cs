namespace Risk.Land.Territories.Asia
{
    class Irkutsk : ITerritory
    {
        public enum Neighbours { Yakutsk = 1, Kamchatka, Mongolia, Siberia };

        public int Occupant { get; set; }

        public int Armies { get; set; }
    }
}