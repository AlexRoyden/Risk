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
                    SaveGameMenu("load");
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

        public static void PlayerTurnMenu()
        {
            var player = GameBoard.GetBoard().GetCurrentPlayer();
            var temp = false;
            while (temp == false)
            {
                Console.Clear();
                Colour.SouthAmericaRed("\t     **** Risk! ****\n");
                Console.WriteLine("\t==========================");
                Console.WriteLine("\t       Game Menu");
                Console.Write("\tCurrently ");
                Colour.PrintPlayer(player.Colour, player.Name + "'s");
                Console.Write(" turn.\n");
                Console.WriteLine("\t1. Maps menu");
                Console.WriteLine("\t2. Attack enemy territory");
                Console.WriteLine("\t3. Move your Troops");
                Console.WriteLine("\t4. Save Game");
                Console.WriteLine("\t5. Quit Game");
                Console.WriteLine("\t==========================");
                var option = GameEngine.UserInputTest("\t(1-5)>", "\tInvalid input, please try again!", 1, 5);

                switch (option)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        SaveGameMenu("save");
                        break;
                    case 5:
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

        public static void SaveGameMenu(string gameOption)
        {
            Console.Clear();
            var meta = SaveGameMetaData.Meta;
            Colour.SouthAmericaRed("\t     **** Risk! ****\n");
            Console.WriteLine("\t===========================================");
            Console.WriteLine("\t       Save Menu");
            Console.WriteLine("\t1. Slot 1 - " + meta.Save1Count + " Players...." + meta.Save1Date);
            Console.WriteLine("\t2. Slot 2 - " + meta.Save2Count + " Players...." + meta.Save2Date);
            Console.WriteLine("\t3. Slot 3 - " + meta.Save3Count + " Players...." + meta.Save3Date);
            Console.WriteLine("\t4. Slot 4 - " + meta.Save4Count + " Players...." + meta.Save4Date);
            Console.WriteLine("\t5. Slot 5 - " + meta.Save5Count + " Players...." + meta.Save5Date);
            Console.WriteLine("\t6. Slot 6 - " + meta.Save6Count + " Players...." + meta.Save6Date);
            Console.WriteLine("\t7. Return to previous Menu");
            Console.WriteLine("\t==========================");
            var option = GameEngine.UserInputTest("\t(1-7)>", "\tInvalid input, please try again!", 1, 7);

            switch (option)
            {
                case 1:
                    var path1 = @"..\..\SaveFiles\save1.json";
                    if (gameOption == "save")
                    {
                        GameSaver.SaveGame(path1, 1);
                    }
                    else if (gameOption == "load")
                    {
                        GameLoader.LoadGame(path1, 1);}
                    break;
                case 2:
                    var path2 = @"..\..\SaveFiles\save2.json";
                    if (gameOption == "save")
                    {
                        GameSaver.SaveGame(path2, 2);
                    }
                    else if (gameOption == "load")
                    {
                        GameLoader.LoadGame(path2, 2);
                    }
                    break;
                case 3:
                    var path3 = @"..\..\SaveFiles\save3.json";
                    if (gameOption == "save")
                    {
                        GameSaver.SaveGame(path3, 3);
                    }
                    else if (gameOption == "load")
                    {
                        GameLoader.LoadGame(path3, 3);
                    }
                    break;
                case 4:
                    var path4 = @"..\..\SaveFiles\save4.json";
                    if (gameOption == "save")
                    {
                        GameSaver.SaveGame(path4, 4);
                    }
                    else if (gameOption == "load")
                    {
                        GameLoader.LoadGame(path4, 4);
                    }
                    break;
                case 5:
                    var path5 = @"..\..\SaveFiles\save5.json";
                    if (gameOption == "save")
                    {
                        GameSaver.SaveGame(path5, 5);
                    }
                    else if (gameOption == "load")
                    {
                        GameLoader.LoadGame(path5, 5);
                    }
                    break;
                case 6:
                    var path6 = @"..\..\SaveFiles\save6.json";
                    if (gameOption == "save")
                    {
                        GameSaver.SaveGame(path6, 6);
                    }
                    else if (gameOption == "load")
                    {
                        GameLoader.LoadGame(path6, 6);
                    }
                    break;
                case 7:
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
    }
}
