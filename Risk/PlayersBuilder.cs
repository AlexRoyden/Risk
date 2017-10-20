using System;
using System.Collections.Generic;

namespace Risk
{
    class PlayersBuilder
    {
        private static string[] _usedNames;
        private static Dictionary<int,int> _colourList;

        public static List<Player> CreatePlayers()
        {
            var playerList = new List<Player>();
            _usedNames = new string[6];
            _colourList = new Dictionary<int, int>
            {
                {1, 1},
                {2, 2},
                {3, 3},
                {4, 4},
                {5, 5},
                {6, 6}
            };

            Console.Clear();
            Colour.SouthAmericaRed("\t\t  **** Risk! ****\n");
            Console.WriteLine("\t====================================");
            Console.WriteLine("\tEnter the number of players");
            var playersCount = GameEngine.UserInputTest("\t(2-6)>", "\tInvalid selection, please try again.\n", 2, 6);

            for (int player = 1; player <= playersCount; player++)
            {
                Console.Clear();
                Colour.SouthAmericaRed("\t\t  **** Risk! ****\n");
                Console.WriteLine("\t====================================");
                var name = NameValidator(player);
                var colour = ColourPick();

                var armies = 0;
                switch (playersCount)
                {
                    case 2:
                        armies = 40;
                        break;
                    case 3:
                        armies = 35;
                        break;
                    case 4:
                        armies = 30;
                        break;
                    case 5:
                        armies = 25;
                        break;
                    case 6:
                        armies = 20;
                        break;
                }
                playerList.Add(new Player(name, armies, colour));
            }
            return playerList;
        }

        private static string NameValidator(int player)
        {
            var uniquie = false;
            var name = "";
           
            while (uniquie == false)
            {
                Console.Write("\tPlayer {0}, please enter your name: ", player);
                name = Console.ReadLine();

                foreach (var user in _usedNames)
                {
                    if (name != null && (name.Length < 1 || name.Length > 15 || name == ""))
                    {
                        Console.WriteLine("\tName must be between 1 and 15 charters in length!\n");
                    }
                    else if (name != null && (name == user))
                    {
                        Console.WriteLine("\tName already being used, please enter a different name!\n");
                    }
                    else
                    {
                        _usedNames[player - 1] = name;
                        uniquie = true;
                    }
                    break;
                }
            }

            return name;
        }

        public static int ColourPick()
        {
            var option = 0;
            var picked = false;
            while (picked == false)
            {
                Console.Clear();
                Colour.SouthAmericaRed("\t\t  **** Risk! ****\n");
                Console.WriteLine("\t====================================");
                Console.WriteLine("\tChoose your player colour");
                Console.Write("\t1. ");
                Colour.NorthAmericaYellow("Yellow\n");
                Console.Write("\t2. ");
                Colour.SouthAmericaRed("Red\n");
                Console.Write("\t3. ");
                Colour.EuropeBlue("Blue\n");
                Console.Write("\t4. ");
                Colour.AfricaMagenta("Magenta\n");
                Console.Write("\t5. ");
                Colour.AsiaGreen("Green\n");
                Console.Write("\t6. ");
                Colour.AustralasiaCyan("Cyan\n");
                Console.WriteLine("\t==========================");
                option = GameEngine.UserInputTest("\t(1-6)>", "\tInvalid input, please try again!", 1, 6);

                if (_colourList.ContainsKey(option))
                {
                    _colourList.Remove(option);
                    picked = true;
                }
                else {
                    Console.WriteLine("\tColour already in use, please choose a different colour.");
                    Console.WriteLine("\tPress any key to continue...");
                    Console.ReadKey();
                }
            }
            
            return option;
        }
    }
}
