using System;

namespace Risk
{
    public class Dice
    {
        protected Random Rnd;

        public int Roll(Random rnd)
        {
            var result = Rnd.Next(1, 7);
            return result;
        }

        public Dice(Random rnd)
        {
            Rnd = rnd;
        }
    }
}
