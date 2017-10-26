using System;
using System.Collections.Generic;

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
                Console.Write("\t");

                Colour.PrintLand(territory.Continent, territory.TerriroryNumber.ToString());
                Console.Write(GameEngine.BufferBuilder(territory.TerriroryNumber.ToString().Length, 7));

                Colour.PrintLand(territory.Continent, territory.Name);
                Console.Write(GameEngine.BufferBuilder(territory.Name.Length, 21));

                Colour.PrintLand(territory.Continent, "\t" + territory.Continent);
                Console.Write(GameEngine.BufferBuilder(territory.Continent.Length, 13));

                if (territory.Occupant == "Empty") { Console.Write("\t" + territory.Occupant); }
                else { Colour.PrintPlayer(GameEngine.GetPlayerColourIndex(territory.Occupant), "\t" + territory.Occupant); }
                Console.Write(GameEngine.BufferBuilder(territory.Occupant.Length, 16));

                Console.Write(territory.Armies + "\n");
            }
            Console.WriteLine("\t==========================================================================");
        }

        public static Dictionary<int, int> ShowTerritoriesNeighbours(Territory attacker)
        {
            Console.WriteLine("\n\tAttacker\t\tContinent\tOccupant\tArmies");
            Console.WriteLine("\t==========================================================================");

            Colour.PrintLand(attacker.Continent, "\t" + attacker.Name);
            Console.Write(GameEngine.BufferBuilder(attacker.Name.Length, 21));

            Colour.PrintLand(attacker.Continent, "\t" + attacker.Continent);
            Console.Write(GameEngine.BufferBuilder(attacker.Continent.Length, 13));

            if (attacker.Occupant == "Empty") { Console.Write("\t" + attacker.Occupant); }
            else { Colour.PrintPlayer(GameEngine.GetPlayerColourIndex(attacker.Occupant), "\t" + attacker.Occupant); }
            Console.Write(GameEngine.BufferBuilder(attacker.Occupant.Length, 16));

            Console.Write(attacker.Armies);
            Console.WriteLine("\n\t==========================================================================");

            Console.WriteLine("\n\tNumber neighbours\t\tContinent\tOccupant\tArmies");
            Console.WriteLine("\t==========================================================================");
            var option = 1;
            var numberMap = new Dictionary<int, int>();
            foreach (var neighbour in attacker.Neighbours)
            {
                Console.Write("\t");

                Colour.PrintLand(neighbour.Continent, option.ToString());
                numberMap.Add(option, neighbour.TerriroryNumber);
                option++;
                Console.Write(GameEngine.BufferBuilder(option.ToString().Length, 7));

                Colour.PrintLand(neighbour.Continent, neighbour.Name);
                Console.Write(GameEngine.BufferBuilder(neighbour.Name.Length, 21));

                Colour.PrintLand(neighbour.Continent, "\t" + neighbour.Continent);
                Console.Write(GameEngine.BufferBuilder(neighbour.Continent.Length, 13));

                if (neighbour.Occupant == "Empty") { Console.Write("\t" + neighbour.Occupant); }
                else { Colour.PrintPlayer(GameEngine.GetPlayerColourIndex(neighbour.Occupant), "\t" + neighbour.Occupant); }
                Console.Write(GameEngine.BufferBuilder(neighbour.Occupant.Length, 16));

                Console.Write(neighbour.Armies + "\n");
            }
            Console.WriteLine("\t==========================================================================");
            return numberMap;
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
