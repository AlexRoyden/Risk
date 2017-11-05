using System;

namespace Risk
{
    class GameCreationMenus
    {
        public static void StartMenu()
        {
            Console.Clear();
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
                    Game builder = new LoadedGame();
                    var risk = new Risk();
                    risk.Construct(builder);
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
                    Game manualBuilder = new ManualGame();
                    var manualGame = new Risk();
                    manualGame.Construct(manualBuilder);
                    break;
                case 2:
                    Game quickBuilder = new QuickGame();
                    var quickGame = new Risk();
                    quickGame.Construct(quickBuilder);
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
    }
}
