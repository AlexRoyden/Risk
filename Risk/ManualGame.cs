using System;

namespace Risk
{
    public class ManualGame :Game
    {
        public override void CreateGame()
        {
            InitializeBoard();
            AssignStartingPlayer();
            BoardPopulator.SelectTerritories();
            BoardPopulator.DeployArmies();
            GamePlayMenus.PlayerTurnMenu();
        }

        public override void InitializeBoard()
        {
            var board = GameBoard.GetBoard();
            var players = PlayersBuilder.CreatePlayers();
            board.SetPlayerList(players);
            BoardBuilder.LoadTerritoryNeighbours();
        }

        public override void AssignStartingPlayer()
        {
            var board = GameBoard.GetBoard();
            var starter = GameEngine.HighestRoll(board.GetPlayerList());
            GameEngine.Timer("Rolling dice");
            Colour.PrintPlayer(starter.Colour, "\r\t" + starter.Name);
            Console.Write(" won the roll and will play first.\n");
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
            board.SetPlayerTurnQueue(GameEngine.CreateTurnQueue(starter));
            board.SetCurrentPlayer();
        }
    }
}
