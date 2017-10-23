using System.Collections.Generic;

namespace Risk
{
    public class Player
    {
        public string Name { get; set; }
        public int Armies { get; set; }
        public int Colour { get; set; }
        public List<Card> Infantry { get; set; }
        public List<Card> Cavalry { get; set; }
        public List<Card> Artillary { get; set; }
        public List<Card> Wild { get; set; }
        public int HighestRoll { get; set; }
        

        public Player(string name, int armies, int colour)
        {
            Name = name;
            Armies = armies;
            Colour = colour;
            Infantry = new List<Card>();
            Cavalry = new List<Card>();
            Artillary = new List<Card>();
            Wild = new List<Card>();
        }

        public Player()
        {
        }
    }
}
