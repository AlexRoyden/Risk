using System;
using System.Collections.Generic;

namespace Risk
{
    class BoardPopulator
    {
        public static void SelectTerritories()
        {
            var board = GameBoard.GetBoard();
            var selected = false;
            while (selected == false)
            {
                var player = board.CurrentPlayer;
                Console.Clear();
                Colour.SouthAmericaRed("\t     **** Risk! ****\n");
                Console.WriteLine("\t====================================");
                Colour.PrintPlayer(player.Colour, "\t" + player.Name);
                Console.WriteLine(" please select a territory you wish to occupy");

                MapBuilder.ShowEntireWorld();

                var selection = GameEngine.UserInputTest("\n\tEnter territory number (1-42)>", "\tInvalid selection!", 1, 42);
                var result = FindTerritory(selection);
                if (CheckIfOccupied(result, player) == false)
                {
                    board.SetCurrentPlayer();
                }

                if (CheckMapIsFull(board))
                {
                    selected = true;
                }
            }

            Console.Clear();
            Colour.SouthAmericaRed("\t     **** Risk! ****\n");
            Console.WriteLine("\t===========================================");
            Console.WriteLine("\tAll territories are now occupied.");
            Console.WriteLine("\tDeploy remaining armies to your territories.");
            Console.WriteLine("\tPress any key to continue....");
            Console.ReadKey();
        }

        public static void DeployArmies()
        {
            var board = GameBoard.GetBoard();
            var finished = 0;

            while (finished < board.GetPlayerList().Count)
            {
                var player = board.CurrentPlayer;
                Console.Clear();
                Colour.SouthAmericaRed("\t     **** Risk! ****\n");
                Console.WriteLine("\t====================================");
                Colour.PrintPlayer(player.Colour, "\t" + player.Name);
                Console.WriteLine(" , add one army unit to a territory you occupy");
                Console.Write("\tYou have ");
                Colour.PrintPlayer(player.Colour, player.Armies.ToString());
                Console.Write(" armies left to deploy");
                
                MapBuilder.ShowEntireWorld();

                var isPlayersTerritory = false;
                while (isPlayersTerritory == false)
                {
                    var selection = GameEngine.UserInputTest("\n\tEnter territory number (1-42)>", "\tInvalid selection!", 1, 42);
                    var country = FindTerritory(selection);
                    if (country.Occupant == player.Name)
                    {
                        country.Armies += 1;
                        player.Armies -= 1;
                        isPlayersTerritory = true;
                    }
                    else
                    {
                        Console.WriteLine("\tYou have selected a territory that is occupied by another player!\n");
                    }
                }
                
                if (player.Armies == 0)
                {
                    finished++;
                }
                board.SetCurrentPlayer();
            }
        }

        public static void AutoPopulate()
        {
            var board = GameBoard.GetBoard();
            var rnd = board.GetRandom();
            var list = board.GetEarth();
            var tempEarth = new List<Territory>();

            foreach (var territory in list.Territories)
            {
                tempEarth.Add(territory);
            }

            int n = 42;
            while (n > 1)
            {
                int k = (rnd.Next(0, n) % n);
                n--;
                var value = tempEarth[k];
                tempEarth[k] = tempEarth[n];
                tempEarth[n] = value;
            }
            var queue = new Queue<Territory>(tempEarth);

            while (queue.Count > 0)
            {
                var player = board.CurrentPlayer;
                var territory = queue.Dequeue();
                territory.Occupant = player.Name;
                territory.Armies = 1;
                player.Armies -= 1;
                board.SetCurrentPlayer();
            }
            AutoTroopDeploy();
        }

        private static void AutoTroopDeploy()
        {
            var allDeployed = false;
            var rnd = GameBoard.GetBoard().GetRandom();
            var earth = GameBoard.GetBoard().GetEarth();
            var players = new List<Player>();

            foreach (var player in GameBoard.GetBoard().GetPlayerList())
            {
                players.Add(player);
            }

            while (allDeployed == false)
            {
                var index = rnd.Next(0, 41);
                var territory = earth.Territories[index];
                var player = GameBoard.GetBoard().GetPlayerByName(territory.Occupant);

                if (player.Armies < 1)
                {
                    players.Remove(player);
                }
                else
                {
                    territory.Armies += 1;
                    player.Armies -= 1;
                }
                if (players.Count < 1)
                {
                    allDeployed = true;
                }
            }

        }

        private static bool CheckIfOccupied(Territory territory, Player player)
        {
            var occupied = false;
            if (territory.Occupant != "Empty")
            {
                Console.WriteLine("\tTerritory already occupied, please select another territory!");
                Console.WriteLine("\tPress any key to continue.....");
                Console.ReadKey();
                occupied = true;
            }
            else if (territory.Occupant == player.Name)
            {
                Console.WriteLine("\tYou already occupy that territory, please select another territory!");
                Console.WriteLine("\tPress any key to continue.....");
                Console.ReadKey();
                occupied = true;
            }
            else
            {
                territory.Occupant = player.Name;
                territory.Armies = 1;
                player.Armies -= 1;
            }
            
            return occupied;
        }

        private static bool CheckMapIsFull(GameBoard board)
        {
            var count = 0;

            foreach (var territory in board.GetEarth().Territories)
            {
                if (territory.Occupant != "Empty")
                {
                    count++;
                }
            }

            if (count == 42)
            {
                return true;
            }
            return false;
        }

        public static Territory FindTerritory(int selection)
        {
            var territories = GameBoard.GetBoard().GetEarth().Territories;
            foreach (var territory in territories)
            {
                if (territory.TerriroryNumber == selection)
                {
                    return territory;
                }
            }
            return null;
        }
    }
}
