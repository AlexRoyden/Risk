using System;
using Risk.Menus;

namespace Risk
{
    class TeritoriesFortification
    {
        public static void FortificationMenu()
        {
            var complete = false;
            while (complete == false)
            {
                var player = GameBoard.GetBoard().CurrentPlayer;
                Console.Clear();
                Colour.SouthAmericaRed("\t     **** Risk! ****\n");
                Console.WriteLine("\t==========================");
                Console.WriteLine("\t    Fortification Menu");
                Console.Write("\tCurrently ");
                Colour.PrintPlayer(player.Colour, player.Name + "'s");
                Console.Write(" turn.\n");
                Console.WriteLine("\t1. Move Troops");
                Console.WriteLine("\t2. Game Menu");
                Console.WriteLine("\t3. End Turn");
                Console.WriteLine("\t==========================");
                var option = GameEngine.UserInputTest("\t(1-3)>", "\tInvalid input, please try again!", 1, 3);

                switch (option)
                {
                    case 1:
                        MoveTroops();
                        break;
                    case 2:
                        GamePlayMenus.PlayerTurnMenu();
                        break;
                    case 3:
                        complete = true;
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }
            }
        }

        public static void MoveTroops()
        {
            var supplier = PickSupplerTerritory();
            var receiver = PickReceiverTerritory(supplier);
            MovementOrders(supplier, receiver);
        }

        private static void MovementOrders(Territory supplier, Territory receiver)
        {
            Console.Clear();
            var player = GameBoard.GetBoard().CurrentPlayer;
            Colour.SouthAmericaRed("\t     **** Risk! ****\n");
            Console.WriteLine("\t====================================");
            Console.Write("\tCurrently ");
            Colour.PrintPlayer(player.Colour, player.Name + "'s");
            Console.Write(" turn.");
            Console.WriteLine("\n\tSelect the number of armies you wish to move from {0}, to fortify {1}?.",
                supplier.Name, receiver.Name);
            var armies = supplier.Armies - 1;
            var prompt = "\t(1-" + armies + ")>";
            var option = GameEngine.UserInputTest(prompt, "\tInvalid input, please try again!", 1, armies);

            supplier.Armies -= option;
            receiver.Armies += option;
        }

        private static Territory PickReceiverTerritory(Territory supplier)
        {
            var territory = new Territory();
            var confirmed = false;
            while (confirmed == false)
            {
                Console.Clear();
                var player = GameBoard.GetBoard().CurrentPlayer;
                Colour.SouthAmericaRed("\t     **** Risk! ****\n");
                Console.WriteLine("\t====================================");
                Console.Write("\tCurrently ");
                Colour.PrintPlayer(player.Colour, player.Name + "'s");
                Console.Write(" turn.");
                Console.Write("\n\tPlease select the territory you want to  ");
                Colour.SouthAmericaRed("Fortify.\n");

                var numberMap = MapBuilder.ShowTerritoriesNeighbours(supplier);
                var option = GameEngine.UserInputTest("\n\t(Territory number)>", "\tInvalid input, please try again!", 1,
                    numberMap.Count);
                int result;
                numberMap.TryGetValue(option, out result);

                territory = BoardPopulator.FindTerritory(result);
                if (territory != null && territory.Occupant == player.Name)
                {
                    confirmed = true;
                }
                else
                {
                    Console.WriteLine("\tCannot move troops into enemy territory!");
                    Console.WriteLine("\tPress any key to continue....");
                    Console.ReadKey();
                }
            }
            return territory;
        }

        private static Territory PickSupplerTerritory()
        {
            var territory = new Territory();
            var confirmed = false;
            while (confirmed == false)
            {
                var player = GameBoard.GetBoard().CurrentPlayer;
                Console.Clear();
                Colour.SouthAmericaRed("\t     **** Risk! ****\n");
                Console.WriteLine("\t====================================");
                Console.Write("\tCurrently ");
                Colour.PrintPlayer(player.Colour, player.Name + "'s");
                Console.Write(" turn.");
                Console.Write("\n\tPlease select the territory you want to  ");
                Colour.SouthAmericaRed("Move Troops From.\n");

                MapBuilder.ShowEntireWorld();
                var option = GameEngine.UserInputTest("\n\t(1-42)>", "\tInvalid input, please try again!", 1, 42);

                territory = BoardPopulator.FindTerritory(option);
                if (territory.Occupant != player.Name)
                {
                    Console.WriteLine("\tTerritory is occupied by another player.");
                    Console.WriteLine("\tPress any key to retry....");
                    Console.ReadKey();
                }
                else if (territory.Armies == 1)
                {
                    Console.WriteLine("\tTerritory must have more than 1 army.");
                    Console.WriteLine("\tPress any key to retry....");
                    Console.ReadKey();
                }
                else
                {
                    confirmed = true;
                }
            }
            return territory;
        }
    }
}
