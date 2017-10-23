using System;

namespace Risk
{
    class MapBuider
    {
        public static void MapsMenu()
        {
            Console.Clear();
            var player = GameBoard.GetBoard().CurrentPlayer;
            Colour.SouthAmericaRed("\t     **** Risk! ****\n");
            Console.WriteLine("\t==========================");
            Console.WriteLine("\t       Map Menu");
            Console.Write("\tCurrently ");
            Colour.PrintPlayer(player.Colour, player.Name + "'s");
            Console.Write(" turn.\n");
            Console.WriteLine("\t1. world map");
            Console.WriteLine("\t2. Attack enemy territory");
            Console.WriteLine("\t3. Move your Troops");
            Console.WriteLine("\t4. Save Game");
            Console.WriteLine("\t5. Quit Game");
            Console.WriteLine("\t==========================");
            var option = GameEngine.UserInputTest("\t(1-5)>", "\tInvalid input, please try again!", 1, 5);

            switch (option)
            {
                case 1:
                    ShowWorld();
                    Console.WriteLine("\tPress any key to return to menu");
                    Console.ReadKey();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    Console.Clear();
                    Colour.SouthAmericaRed("\t     **** Risk! ****\n");
                    Console.WriteLine("\t==========================");
                    Console.WriteLine("\tThank you and goodbye!\n\tPress any key to exit.......");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }

        public static void ShowWorld()
        {
            var board = GameBoard.GetBoard();
            Console.Clear();
            Colour.SouthAmericaRed("\t\t**** Risk! ****\n");
            Console.WriteLine("\t====================================");

            Console.WriteLine("\n\tTerritory\t\tOccupant\tArmies");
            Console.WriteLine("\t===================================================");
            foreach (var territory in board.GetEarth().Territories)
            {
                var armies = territory.Armies.ToString();

                Console.Write("\t");
                Colour.PrintLand(territory.Continent, territory.Name);
                Console.Write(GameEngine.BufferBuilder(territory.Name.Length, 21));

                Colour.PrintPlayer(GameEngine.GetPlayerColourIndex(territory.Occupant), "\t" + territory.Occupant);
                Console.Write(GameEngine.BufferBuilder(territory.Occupant.Length, 16));

                Console.Write(armies + "\t");
                Console.Write("\n");
            }
        }
    }
}
