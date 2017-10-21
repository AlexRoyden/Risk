using System;
using System.Collections.Generic;

namespace Risk
{
    class BoardPopulator
    {
        public static void SelectTerritories()
        {
            var board = GameBoard.GetBoard();
            var player = board.GetCurrentPlayer();
            var selected = false;
            while (selected == false)
            {
                Console.Clear();
                Colour.SouthAmericaRed("\t     **** Risk! ****\n");
                Console.WriteLine("\t====================================");
                Colour.PrintPlayer(player.Colour, "\t" + player.Name);
                Console.WriteLine(" please select a territory you wish to occupy");

                Console.WriteLine("\n\tTerritory\t\tContinent\tOccupant\tSelect");
                Console.WriteLine("\t============================================================================");
                foreach (var territory in board.GetEarth().Territories)
                {
                    Console.Write("\t");
                    Colour.PrintLand(territory.Continent, territory.Name);
                    Console.Write(GameEngine.BufferBuilder(territory.Name.Length, 21));

                    Colour.PrintLand(territory.Continent, "\t" + territory.Continent);
                    Console.Write(GameEngine.BufferBuilder(territory.Continent.Length, 13));

                    if (territory.Occupant == "Empty") { Console.Write("\t" + territory.Occupant); }
                    else { Colour.PrintPlayer(GameEngine.GetPlayerColourIndex(territory.Occupant), "\t" + territory.Occupant); }
                    Console.Write(GameEngine.BufferBuilder(territory.Occupant.Length, 15));

                    Console.Write("Number : " + territory.TerriroryNumber + "\n");
                }
                var selection = GameEngine.UserInputTest("\n\tEnter territory number (1-42)>", "\tInvalid selection!", 1, 42);
                var result = FindTerritory(selection, board);
                if (CheckIfOccupied(result, player) == false)
                {
                    player = board.GetCurrentPlayer();
                }

                if (CheckMapIsFull(board))
                {
                    selected = true;
                }
            }
        }

        public static void DeployArmies()
        {
            var board = GameBoard.GetBoard();
            var player = board.GetCurrentPlayer();
            var finished = 0;

            while (finished < board.GetPlayerList().Count)
            {
                Console.Clear();
                Colour.SouthAmericaRed("\t     **** Risk! ****\n");
                Console.WriteLine("\t====================================");
                Colour.PrintPlayer(player.Colour, "\t" + player.Name);
                Console.WriteLine(" , add one army unit to a territory you occupy");
                Console.Write("\tYou have ");
                Colour.PrintPlayer(player.Colour, player.Armies.ToString());
                Console.Write(" armies left to deploy");
                Console.WriteLine("\n\tNumber Territory\t\tContinent\tOccupant\tArmies\tNeighbours\t\t   Occupant\t\tArmies");
                Console.WriteLine("\t======================================================================================================================");
                foreach (var territory in board.GetEarth().Territories)
                {
                    if (territory.Occupant == player.Name)
                    {
                        Console.Write("\n\t");

                        Colour.PrintLand(territory.Continent, territory.TerriroryNumber.ToString());
                        Console.Write(GameEngine.BufferBuilder(territory.TerriroryNumber.ToString().Length, 7));

                        Colour.PrintLand(territory.Continent, territory.Name);
                        Console.Write(GameEngine.BufferBuilder(territory.Name.Length, 21));

                        Colour.PrintLand(territory.Continent, "\t" + territory.Continent);
                        Console.Write(GameEngine.BufferBuilder(territory.Continent.Length, 13));

                        Colour.PrintPlayer(GameEngine.GetPlayerColourIndex(territory.Occupant), "\t" + territory.Occupant);
                        Console.Write(GameEngine.BufferBuilder(territory.Occupant.Length, 15));

                        Console.Write("\t" + territory.Armies);
                        Console.Write(GameEngine.BufferBuilder(territory.Armies.ToString().Length, 8));

                        foreach (var neighbour in territory.Neighbours)
                        {
                            Colour.PrintLand(neighbour.Continent, neighbour.Name);
                            Console.Write(GameEngine.BufferBuilder(neighbour.Name.Length, 21));

                            Colour.PrintPlayer(GameEngine.GetPlayerColourIndex(neighbour.Occupant), "\t" + neighbour.Occupant);
                            Console.Write(GameEngine.BufferBuilder(neighbour.Occupant.Length, 15));

                            Console.Write("\t" + neighbour.Armies);
                            Console.Write(GameEngine.BufferBuilder(neighbour.Armies.ToString().Length, 6));
                            Console.Write("\n");
                            Console.Write(GameEngine.BufferBuilder(0, 80));
                        }
                    }
                   
                }

                var isPlayersTerritory = false;
                while (isPlayersTerritory == false)
                {
                    var selection = GameEngine.UserInputTest("\n\tEnter territory number (1-42)>", "\tInvalid selection!", 1, 42);
                    var country = FindTerritory(selection, board);
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
                player = board.GetCurrentPlayer();
            }
        }

        public static void AutoPopulate()
        {
            var rnd = GameBoard.GetBoard().GetRandom();
            var list = GameBoard.GetBoard().GetEarth();
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
                var player = GameBoard.GetBoard().GetCurrentPlayer();
                var territory = queue.Dequeue();
                territory.Occupant = player.Name;
                territory.Armies = 1;
                player.Armies -= 1;
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

        private static bool CheckIfOccupied(Territory territoryMapperMapperMapper, Player player)
        {
            var occupied = false;
            if (territoryMapperMapperMapper.Occupant != "Empty")
            {
                Console.WriteLine("\tTerritory already occupied, please select another territory!");
                Console.WriteLine("\tPress any key to continue.....");
                Console.ReadKey();
                occupied = true;
            }

            territoryMapperMapperMapper.Occupant = player.Name;
            territoryMapperMapperMapper.Armies = 1;
            player.Armies -= 1;
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

        private static Territory FindTerritory(int selection, GameBoard board)
        {
            foreach (var territory in board.GetEarth().Territories)
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
