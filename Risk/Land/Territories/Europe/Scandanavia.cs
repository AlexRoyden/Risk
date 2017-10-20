namespace Risk.Land.Territories.Europe
{
    class Scandanavia : ITerritory
    {
        public enum Neighbours { Ukraine = 1, NorthernEurope, GreatBritain, Iceland };

        public int Occupant { get; set; }

        public int Armies { get; set; }
    }
}