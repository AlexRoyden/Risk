using System;

namespace Risk
{
    public class Dice
    {
        public static int Roll(Random rnd)
        {
            var result = rnd.Next(1, 7);
            return result;
        }
    }
}
