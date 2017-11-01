using System.Collections.Generic;

namespace Risk
{
    public class Player
    {
        public string Name { get; set; }
        public int Armies { get; set; }
        public int Colour { get; set; }
        public List<Card> Cards { get; set; }
        public int ConqueredDuringTurn { get; set; }
        public int GameEntryPoint { get; set; }

        public Player(string name, int armies, int colour)
        {
            Name = name;
            Armies = armies;
            Colour = colour;
        }

        public Player()
        {
        }
    }
}
