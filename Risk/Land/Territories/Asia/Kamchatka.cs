namespace Risk.Land.Territories.Asia
{
    class Kamchatka : ITerritory
    {
        public enum Neighbours { Japan = 1, Mongolia, Irkutsk, Yakutsk };

        public int Occupant { get; set; }

        public int Armies { get; set; }
    }
}