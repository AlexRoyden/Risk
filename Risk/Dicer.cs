using System;
using System.Collections.Generic;
using System.Threading;

namespace Risk
{
    class Dicer : Dice
    {
        private static Dicer _dicer;
        private List<Dice> _dice;
        private List<Random> _randoms;

        private Dicer(Random rnd) : base(rnd)
        {
            _dice = new List<Dice>();
            _randoms = new List<Random>();
            GenerateRandoms(rnd);
        }

        public int RandomRoll()
        {
            Thread.Sleep(157);
            var random = Rnd.Next(0, 5);
            var die = Rnd.Next(0, 5);

            var result = _dice[die].Roll(_randoms[random]);
            return result;
        }

        public static Dicer GetDice()
        {
            if (_dicer == null)
            {
                _dicer = new Dicer(new Random());
            }
            return _dicer;
        }

        private void GenerateRandoms(Random rnd)
        {
            var random1 = new Random();
            var dice1 = new Dice(random1);
            _randoms.Add(random1);
            _dice.Add(dice1);
            Thread.Sleep(376);

            var random2 = new Random();
            var dice2 = new Dice(random2);
            _randoms.Add(random2);
            _dice.Add(dice2);
            Thread.Sleep(875);

            var random3 = new Random();
            var dice3 = new Dice(random3);
            _randoms.Add(random3);
            _dice.Add(dice3);
            Thread.Sleep(1109);

            var random4 = new Random();
            var dice4 = new Dice(random4);
            _randoms.Add(random4);
            _dice.Add(dice4);
            Thread.Sleep(444);

            var random5 = new Random();
            var dice5 = new Dice(random5);
            _randoms.Add(random5);
            _dice.Add(dice5);
            Thread.Sleep(666);

            var random6 = new Random();
            var dice6 = new Dice(random6);
            _randoms.Add(random6);
            _dice.Add(dice6);
        }
    }
}
