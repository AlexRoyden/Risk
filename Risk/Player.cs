namespace Risk
{
    public class Player
    {
        public string Name { get; set; }
        public int Armies { get; set; }
        public int HighestRoll { get; set; }
        public int Colour { get; set; }

        public Player(string name, int armies, int colour)
        {
            Name = name;
            Armies = armies;
            Colour = colour;
        }
    }
}
