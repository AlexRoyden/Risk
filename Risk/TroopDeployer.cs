using System;

namespace Risk
{
    class TroopDeployer
    {
        public static void DeployTroops(Player player)
        {
            while (player.Armies > 0)
            {
                Console.Clear();
                Colour.SouthAmericaRed("\t     **** Risk! ****\n");
                Console.WriteLine("\t====================================");
                Colour.PrintPlayer(player.Colour, "\t" + player.Name);
                Console.WriteLine(" , add one or more army units to a territory you occupy");
                Console.Write("\tYou have ");
                Colour.PrintPlayer(player.Colour, player.Armies.ToString());
                Console.Write(" armies left to deploy");

                MapBuilder.ShowEntireWorld();

                var isPlayersTerritory = false;
                while (isPlayersTerritory == false)
                {
                    var selection = GameEngine.UserInputTest("\n\tEnter territory number (1-42)>",
                        "\tInvalid selection!", 1, 42);
                    var country = BoardPopulator.FindTerritory(selection);
                    if (country.Occupant == player.Name)
                    {
                        var troops = GameEngine.UserInputTest("\n\tEnter number of units you wish to send (1-" + player.Armies + ")>",
                        "\tInvalid selection!", 1, player.Armies);

                        country.Armies += troops;
                        player.Armies -= troops;
                        isPlayersTerritory = true;
                    }
                    else
                    {
                        Console.WriteLine("\tYou have selected a territory that is occupied by another player!\n");
                    }

                }
            }
        }
    }
}
