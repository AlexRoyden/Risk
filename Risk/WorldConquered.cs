using System;

namespace Risk
{
    class WorldConquered
    {
        private readonly Battle _battle;

        public WorldConquered(Battle battle)
        {
            _battle = battle;
            SubscribeToBattle();
        }

        public void SubscribeToBattle()
        {
            _battle.GameCompleted += OnGameCompleted;
        }

        private void OnGameCompleted(Object sender, EventArgs e)
        {
            var player = GameBoard.GetBoard().CurrentPlayer;
            Console.Clear();
            Colour.SouthAmericaRed("\t     **** Risk! ****\n");
            Console.WriteLine("\t==========================");
            Console.WriteLine("\t    !!!!!Victory!!!!!");
            Colour.PrintPlayer(player.Colour, "\n\t" + player.Name);
            Console.Write(", You have destroyed your enemies and conquered the world!");
            Console.WriteLine("\n\tCongratulations, you are the Winner!!!");
            Console.WriteLine("\tThank you for playing");
            Console.WriteLine("\tPress any key to continue....");
            Console.ReadKey();

            Environment.Exit(0);
        }
    }
}
