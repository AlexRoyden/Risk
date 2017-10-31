using System;
using Risk.Menus;

namespace Risk
{
    class BattleBuilder
    {
        public static void BattleMenu()
        {
            var complete = false;
            while (complete == false)
            {
                //End game event
                if (GameBoard.GetBoard().GetPlayerList().Count < 2)
                {
                    
                }
                var player = GameBoard.GetBoard().CurrentPlayer;
                Console.Clear();
                Colour.SouthAmericaRed("\t     **** Risk! ****\n");
                Console.WriteLine("\t==========================");
                Console.WriteLine("\t       Battle Menu");
                Console.Write("\tCurrently ");
                Colour.PrintPlayer(player.Colour, player.Name + "'s");
                Console.Write(" turn.\n");
                Console.WriteLine("\t1. Select territory to attack");
                Console.WriteLine("\t2. Game Menu");
                Console.WriteLine("\t3. Finish Fighting");
                Console.WriteLine("\t==========================");
                var option = GameEngine.UserInputTest("\t(1-3)>", "\tInvalid input, please try again!", 1, 3);

                switch (option)
                {
                    case 1:
                        var attack = BuildBattle();
                        Battle.BeginBattle(attack);
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

        private static Attack BuildBattle()
        {
            var board = GameBoard.GetBoard();
            var attackingTerritory = ChooseAttacker();
            var defendingTerritory = ChooseDefender(attackingTerritory);
            var attacker = board.GetPlayerByName(attackingTerritory.Occupant);
            var defender = board.GetPlayerByName(defendingTerritory.Occupant);
            var attack = new Attack(attacker, defender, attackingTerritory, defendingTerritory);

            ArrangeBattle(attack);
            BattleRollOptions(attack);
            return attack;
        }

        private static void BattleRollOptions(Attack attack)
        {
            var rnd = GameBoard.GetBoard().GetRandom();
            if (attack.AttackDiceCount == 1)
            {
                attack.AttackDice1 = Dice.Roll(rnd);
            }
            else if (attack.AttackDiceCount == 2)
            {
                attack.AttackDice1 = Dice.Roll(rnd);
                attack.AttackDice2 = Dice.Roll(rnd);
            }
            else if (attack.AttackDiceCount == 3)
            {
                attack.AttackDice1 = Dice.Roll(rnd);
                attack.AttackDice2 = Dice.Roll(rnd);
                attack.AttackDice3 = Dice.Roll(rnd);
            }

            if (attack.DefendDiceCount == 1)
            {
                attack.DefendDice1 = Dice.Roll(rnd);
            }
            else if (attack.DefendDiceCount == 2)
            {
                attack.DefendDice1 = Dice.Roll(rnd);
                attack.DefendDice2 = Dice.Roll(rnd);
            }
        }

        private static void ArrangeBattle(Attack attack)
        {
            Console.Clear();
            Colour.SouthAmericaRed("\t     **** Risk! ****\n");
            Console.WriteLine("\t==========================");
            Console.WriteLine("\t       Battle Options");
            Colour.PrintLand(attack.AttackingTerritory.Continent, "\n\t" + attack.AttackingTerritory.Name);
            Console.Write(", Occupied by ");
            Colour.PrintPlayer(attack.Attacker.Colour, attack.Attacker.Name);
            Console.Write(" is Attacking with ");
            Colour.SouthAmericaRed(attack.AttackingTerritory.Armies.ToString());
            Console.Write(" armies.");

            Colour.PrintLand(attack.DefendingTerritory.Continent, "\n\t" + attack.DefendingTerritory.Name);
            Console.Write(", Occupied by ");
            Colour.PrintPlayer(attack.Defender.Colour, attack.Defender.Name);
            Console.Write(" is Defending with ");
            Colour.SouthAmericaRed(attack.DefendingTerritory.Armies.ToString());
            Console.Write(" armies.\n");

            var first = false;
            while (first == false)
            {
                Colour.PrintPlayer(attack.Attacker.Colour, "\n\t" + attack.Attacker.Name);
                var attackDie = GameEngine.UserInputTest("\n\tHow many Dice would you like to attack with (1-3) : ",
                    "\tInvalid input, please try again!", 1, 3);
                if (CheckDieOption(attackDie, "attacker", attack.AttackingTerritory))
                {
                    attack.AttackDiceCount = attackDie;
                    first = true;
                }
            }

            var second = false;
            while (second == false)
            {
                Colour.PrintPlayer(attack.Defender.Colour, "\n\t" + attack.Defender.Name);
                var defendDie = GameEngine.UserInputTest("\n\tHow many Dice would you like to to defend with (1-2) : ",
                    "\tInvalid input, please try again!", 1, 2);
                if (CheckDieOption(defendDie, "defender", attack.DefendingTerritory))
                {
                    attack.DefendDiceCount = defendDie;
                    second = true;
                }
            }
        }

        private static bool CheckDieOption(int dieCount, string playerType, Territory territory)
        {
            var diceAllowed = false;
            if (playerType == "attacker")
            {
                if (territory.Armies + 1 > dieCount)
                {
                    diceAllowed = true;
                }
                else
                {
                    Console.WriteLine("\tYour territory must have at least one more army than the number of dice you are rolling.");
                }
            }
            else if (playerType == "defender")
            {
                if (dieCount <= 2 && territory.Armies >= 2)
                {
                    diceAllowed = true;
                }
                else if (dieCount == 1 && territory.Armies == 1)
                {
                    diceAllowed = true;
                }
                else { Console.WriteLine("\tMust have more than one army if selecting 2 dice!");}
            }
            return diceAllowed;
        }

        private static Territory ChooseAttacker()
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
                Colour.SouthAmericaRed("attack with.\n");

                MapBuilder.ShowEntireWorld();
                var option = GameEngine.UserInputTest("\n\t(1-42)>", "\tInvalid input, please try again!", 1, 42);

                territory =  BoardPopulator.FindTerritory(option);
                if (territory.Occupant != player.Name)
                {
                    Console.WriteLine("\tTerritory is occupied by another player.");
                    Console.WriteLine("\tPress any key to retry....");
                    Console.ReadKey();
                }
                else if (territory.Armies < 2)
                {
                    Console.WriteLine("\tTerritory must have at least 2 armies to attack with.");
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

        private static Territory ChooseDefender(Territory attacker)
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
                Colour.SouthAmericaRed("Attack.\n");

                var numberMap = MapBuilder.ShowTerritoriesNeighbours(attacker);
                var option = GameEngine.UserInputTest("\n\t(Territory number)>", "\tInvalid input, please try again!", 1,
                    numberMap.Count);
                int result;
                numberMap.TryGetValue(option, out result);
                territory = BoardPopulator.FindTerritory(result);
                if (territory != null && territory.Occupant != player.Name)
                {
                    confirmed = true;
                }
                else
                {
                    Console.WriteLine("\tCannot attack a territory which you occupy!");
                    Console.WriteLine("\tPress any key to continue....");
                    Console.ReadKey();
                }
            }
            return territory;
        }
    }
}
