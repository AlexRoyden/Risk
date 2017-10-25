using System;

namespace Risk
{
    class MapBuilder
    {
        public static void ShowEntireWorld()
        {
            var board = GameBoard.GetBoard();
            Console.WriteLine("\n\tNumber Territory\t\tContinent\tOccupant\tArmies");
            Console.WriteLine("\t==========================================================================");
            foreach (var territory in board.GetEarth().Territories)
            {
                Console.Write("\n\t");

                Colour.PrintLand(territory.Continent, territory.TerriroryNumber.ToString());
                Console.Write(GameEngine.BufferBuilder(territory.TerriroryNumber.ToString().Length, 7));

                Colour.PrintLand(territory.Continent, territory.Name);
                Console.Write(GameEngine.BufferBuilder(territory.Name.Length, 21));

                Colour.PrintLand(territory.Continent, "\t" + territory.Continent);
                Console.Write(GameEngine.BufferBuilder(territory.Continent.Length, 13));

                if (territory.Occupant == "Empty") { Console.Write("\t" + territory.Occupant); }
                else { Colour.PrintPlayer(GameEngine.GetPlayerColourIndex(territory.Occupant), "\t" + territory.Occupant); }
                Console.Write(GameEngine.BufferBuilder(territory.Occupant.Length, 16));

                Console.Write(territory.Armies);
            }
        }

        public static void ShowCurrentPlayesTerritories()
        {
            var board = GameBoard.GetBoard();
            var player = board.CurrentPlayer;
            Console.WriteLine("\n\tNumber Territory\t\tContinent\tOccupant\tArmies");
            Console.WriteLine("\t==========================================================================");
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
                }
            }
        }
    }
}
