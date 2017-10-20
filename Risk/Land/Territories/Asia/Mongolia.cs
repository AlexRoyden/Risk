namespace Risk.Land.Territories.Asia
{
    class Mongolia : ITerritory
    {
        public enum Neighbours { Irkutsk = 1, Kamchatka, Japan, China, Siberia };

        public int Occupant { get; set; }

        public int Armies { get; set; }
    }
}