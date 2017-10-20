using System;

namespace Risk
{
    public class NewGame
    {
        public static void CreateGame()
        {
            InitializeBoard();
            AssignStartingPlayer();
            MenuBuilder.GameSetupOptions();

            //Move these to a new method depening on gamesetup option
            BoardPopulator.SelectTerritories();
            BoardPopulator.DeployArmies();
        }

        private static void InitializeBoard()
        {
            var board = GameBoard.GetBoard();
            var players = PlayersBuilder.CreatePlayers();
            board.SetPlayerList(players);
        }

        private static void AssignStartingPlayer()
        {
            var starter = GameEngine.HighestRoll(GameBoard.GetBoard().GetPlayerList());
            GameEngine.Timer();
            Colour.PrintPlayer(starter.Colour, "\r\t" + starter.Name);
            Console.Write(" won the roll and will play first.\n");
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
            GameBoard.GetBoard().SetPlayerTurnQueue(GameEngine.CreateTurnQueue(starter));
        }
    }
}
