using System;

namespace Risk
{
    class GamePlayMenus
    {
        public static void PlayerTurnMenu()
        {
            var player = GameBoard.GetBoard().CurrentPlayer;
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
                        MapBuider.MapsMenu();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        var slot = SaveGameMenu("save");
                        if (slot != 7) { GameSaver.SaveGame(slot); }
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

        public static int SaveGameMenu(string gameOption)
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
                    return 1;
                case 2:
                    return 2;
                case 3:
                    return 3;
                case 4:
                    return 4;
                case 5:
                    return 5;
                case 6:
                    return 6;
                case 7:
                    return 7;
                default:
                    Console.WriteLine("Error");
                    return 0;
            }
        }
    }
}
