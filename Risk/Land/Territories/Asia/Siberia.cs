namespace Risk.Land.Territories.Asia
{
    class Siberia : ITerritory
    {
        public enum Neighbours { Yakutsk = 1, Irkutsk, Mongolia, China, Ural };

        public int Occupant { get; set; }

        public int Armies { get; set; }
    }
}