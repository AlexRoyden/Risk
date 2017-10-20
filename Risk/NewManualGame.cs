using System;

namespace Risk
{
    public class NewManualGame : IGame
    {
        public void CreateGame()
        {
            InitializeBoard();
            AssignStartingPlayer();
            BoardPopulator.SelectTerritories();
            BoardPopulator.DeployArmies();
        }

        public void InitializeBoard()
        {
            var board = GameBoard.GetBoard();
            var players = PlayersBuilder.CreatePlayers();
            board.SetPlayerList(players);
        }

        public void AssignStartingPlayer()
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
