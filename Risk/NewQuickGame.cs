using System;

namespace Risk
{
    public class NewQuickGame : IGame
    {
        public void CreateGame()
        {
            InitializeBoard();
            AssignStartingPlayer();
            Populate();
            BoardBuilder.LoadTerritoryNeighbours();
            MenuBuilder.PlayerTurnMenu();
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
            GameEngine.Timer("Rolling dice");
            Colour.PrintPlayer(starter.Colour, "\r\t" + starter.Name);
            Console.Write(" won the roll and will play first.\n");
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
            GameBoard.GetBoard().SetPlayerTurnQueue(GameEngine.CreateTurnQueue(starter));
        }

        public void Populate()
        {
            var confirmed = false;
            while (confirmed == false)
            {
                var armyCount = GameBoard.GetBoard().GetPlayerByIndex(0).Armies;
                BoardPopulator.AutoPopulate();
                MenuBuilder.ShowWorld();
                Console.WriteLine("\t==========================");
                Console.WriteLine("\t1. Confirm board layout");
                Console.WriteLine("\t2. Change board layout");
                Console.WriteLine("\t3. Quit Game");
                Console.WriteLine("\t==========================");
                var option = GameEngine.UserInputTest("\t(1-3)>", "\tInvalid input, please try again!", 1, 3);

                switch (option)
                {
                    case 1:
                        confirmed = true;
                        break;
                    case 2:
                        GameEngine.Timer("Building new board");
                        Console.WriteLine("\r\tPress any key to continue.");
                        Console.ReadKey();
                        foreach (var player in GameBoard.GetBoard().GetPlayerList())
                        {
                            player.Armies = armyCount;
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("\tThank you and goodbye!\n\tPress any key to exit.......");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }
            }
        }
    }
}
