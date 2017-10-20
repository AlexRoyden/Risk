namespace Risk.Land.Territories.Europe
{
    class GreatBritain : ITerritory
    {
        public enum Neighbours { Scandanavia = 1, NorthenEurope, WesternEurope, Iceland };

        public int Occupant { get; set; }

        public int Armies { get; set; }
    }
}