using System;

namespace Risk
{
    class Battle
    {
        public static void BeginBattle(Attack attack)
        {
            BattleOutcome singleDie = new DiceSingleBattle();
            BattleOutcome doubleDie = new DiceDoubleBattle();
            BattleOutcome trippleDie = new DiceTrippleBattle();

            singleDie.SetSuccessor(doubleDie);
            doubleDie.SetSuccessor(trippleDie);

            GameEngine.Timer("Rolling dice");

            singleDie.Fight(attack);

            if (attack.DefendingTerritory.Armies == 0)
            {

                TerritoryConquered(attack);
            }
        }

        private static void TerritoryConquered(Attack attack)
        {
            Console.Clear();
            Colour.SouthAmericaRed("\t     **** Risk! ****\n");
            Console.WriteLine("\t==========================");
            Console.WriteLine("\t       Victory!");
            Colour.PrintPlayer(attack.Attacker.Colour, "\t" + attack.Attacker.Name);
            Console.Write(", you have defeated all of the armies in ");
            Colour.PrintLand(attack.DefendingTerritory.Continent, attack.DefendingTerritory.Name);
            if (attack.AttackingTerritory.Armies == 2)
            {
                Console.WriteLine("\n\tOne army has been moved to {0}.", attack.Defender.Name);
                attack.AttackingTerritory.Armies -= 1;
                attack.DefendingTerritory.Armies += 1;
                attack.DefendingTerritory.Occupant = attack.Attacker.Name;
            }
            else
            {
                Console.WriteLine("\n\tSelect the number of armies you wish to move from {0}, to occupy {1} with.",
                    attack.AttackingTerritory.Name, attack.DefendingTerritory.Name);
                var armies = attack.AttackingTerritory.Armies - 1;
                var prompt = "\t(1-" + armies + ")>";
                var option = GameEngine.UserInputTest(prompt, "\tInvalid input, please try again!", 1, armies);
                attack.AttackingTerritory.Armies -= option;
                attack.DefendingTerritory.Armies += option;
                attack.DefendingTerritory.Occupant = attack.Attacker.Name;
            }
            GameBoard.GetBoard().CurrentPlayer.ConqueredDuringTurn += 1;
            Console.WriteLine("\tPress any key to continue....");
            Console.ReadKey();

            CheckUserHasTerritories(attack.Defender, attack.Attacker);
        }

        private static void CheckUserHasTerritories(Player loser, Player winner)
        {
            var board = GameBoard.GetBoard();
            var count = 0;

            foreach (var territory in board.GetEarth().Territories)
            {
                if (territory.Occupant == loser.Name)
                {
                    count++;
                }
            }

            if (count == 0)
            {
                Console.Clear();
                Colour.SouthAmericaRed("\t     **** Risk! ****\n");
                Console.WriteLine("\t==========================\n");
                Colour.PrintPlayer(loser.Colour, "\t" + loser.Name);
                Console.WriteLine(", You have no remaining territories.");
                Console.WriteLine("You have been annihilated, ");
                Colour.SouthAmericaRed("your game is over!!!!");
                Console.WriteLine("\tPress any key to continue....");
                Console.ReadKey();

                if (loser.Cards.Count > 0)
                {
                    foreach (var card in loser.Cards)
                    {
                        winner.Cards.Add(card);
                    }

                    Console.Clear();
                    Colour.SouthAmericaRed("\t     **** Risk! ****\n");
                    Console.WriteLine("\t==========================\n");
                    Colour.PrintPlayer(winner.Colour, "\t" + winner.Name);
                    Console.Write(", You have received all of ");
                    Colour.PrintPlayer(loser.Colour, loser.Name + "'s ");
                    Console.Write("game cards.");

                    if (winner.Cards.Count > 6)
                    {
                        Console.WriteLine("\tYou now have more than 6 game cards.");
                        Console.WriteLine("\tYou must trade cards now.");
                        Console.WriteLine("\tPress any key to continue....");
                        Console.ReadKey();
                        CardTradeingEngine.TradeMenu();
                    }
                    else
                    {
                        Console.WriteLine("\tPress any key to continue....");
                        Console.ReadKey();
                    }
                }

                var playerList = board.GetPlayerList();
                var index = GameEngine.GetPlayerIndex(loser.Name);
                playerList.RemoveAt(index);

                board.SetPlayerTurnQueue(GameEngine.CreateTurnQueue(board.CurrentPlayer));
            }
        }

        public static void BattleResolve(Attack attack, string round)
        {
            int attacker = attack.AttackDice1;
            int attackDice = 1;
            int defender = attack.DefendDice1;
            int defendDice = 1;

            if (attack.AttackDice2 > attacker)
            {
                attacker = attack.AttackDice2;
                attackDice = 2;
            }
            else if (attack.AttackDice3 > attacker)
            {
                attacker = attack.AttackDice3;
                attackDice = 3;
            }

            if (attack.DefendDice2 > defender)
            {
                defender = attack.DefendDice2;
                defendDice = 2;
            }

            if (attacker > defender)
            {
                attack.DefendingTerritory.Armies -= 1;
                Console.Clear();
                Colour.SouthAmericaRed("\t     **** Risk! ****\n");
                Console.WriteLine("\t==========================");
                Console.WriteLine("\t       Battle outcome");
                Console.WriteLine("\t       {0}\n", round);
                Colour.PrintPlayer(attack.Attacker.Colour, "\t" + attack.Attacker.Name + "'s");
                Console.Write(", Highest attacking roll was {0}.\n\t", attacker);
                Colour.PrintPlayer(attack.Defender.Colour, attack.Defender.Name + "'s");
                Console.Write(", Highest defending roll was {0}.\n", defender);
                Colour.PrintPlayer(attack.Defender.Colour, "\n\t" + attack.Defender.Name);
                Console.WriteLine(", was defeated and has lost 1 army.");
                Console.WriteLine("\tPress any key to continue....");
                Console.ReadKey();
            }
            else
            {
                attack.AttackingTerritory.Armies -= 1;
                Console.Clear();
                Colour.SouthAmericaRed("\t     **** Risk! ****\n");
                Console.WriteLine("\t==========================");
                Console.WriteLine("\t       Battle outcome");
                Console.WriteLine("\t       {0}\n", round);
                Colour.PrintPlayer(attack.Attacker.Colour, "\t" + attack.Attacker.Name + "'s");
                Console.Write(", Highest attacking roll was {0}.\n\t", attacker);
                Colour.PrintPlayer(attack.Defender.Colour, attack.Defender.Name + "'s");
                Console.Write(", Highest defending roll was {0}.\n", defender);
                Colour.PrintPlayer(attack.Attacker.Colour, "\n\t" + attack.Attacker.Name);
                Console.WriteLine(", was defeated and has lost 1 army.");
                Console.WriteLine("\tPress any key to continue....");
                Console.ReadKey();
            }

            if (attackDice == 1)
            {
                attack.AttackDice1 = 0;
            }
            else if (attackDice == 2)
            {
                attack.AttackDice2 = 0;
            }
            else if (attackDice == 3)
            {
                attack.AttackDice3 = 0;
            }

            if (defendDice == 1)
            {
                attack.DefendDice1 = 0;
            }
            else if (defendDice == 2)
            {
                attack.DefendDice2 = 0;
            }
        }
    }
}
