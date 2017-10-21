using System;

namespace Risk
{
    class MenuBuilder
    {
        public static void StartMenu()
        {
            Colour.SouthAmericaRed("\t     **** Risk! ****\n");
            Console.WriteLine("\t==========================");
            Console.WriteLine("\t       Main Menu");
            Console.WriteLine("\t1. Start New Game");
            Console.WriteLine("\t2. Load Game");
            Console.WriteLine("\t3. Quit Game");
            Console.WriteLine("\t==========================");
            var option = GameEngine.UserInputTest("\t(1-3)>", "\tInvalid input, please try again!", 1, 3);

            switch (option)
            {
                case 1:
                    GameSetupOptions();
                    break;
                case 2:
                    Console.WriteLine("Case 2");
                    break;
                case 3:
                    Console.WriteLine("\tThank you and goodbye!\n\tPress any key to exit.......");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
            Console.ReadKey();
        }

        public static void GameSetupOptions()
        {
            Console.Clear();
            Colour.SouthAmericaRed("\t     **** Risk! ****\n");
            Console.WriteLine("\t==========================");
            Console.WriteLine("\t       Main Menu");
            Console.WriteLine("\t1. Manual setup (players choose territories)");
            Console.WriteLine("\t2. Quick Setup (Territories are assigned)");
            Console.WriteLine("\t3. Quit Game");
            Console.WriteLine("\t==========================");
            var option = GameEngine.UserInputTest("\t(1-3)>", "\tInvalid input, please try again!", 1, 3);

            switch (option)
            {
                case 1:
                    var manualGame = new NewManualGame();
                    manualGame.CreateGame();
                    break;
                case 2:
                    var quickGame = new NewQuickGame();
                    quickGame.CreateGame();
                    break;
                case 3:
                    Console.WriteLine("\tThank you and goodbye!\n\tPress any key to exit.......");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
            Console.ReadKey();
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
