using System;
using System.Collections.Generic;

namespace Risk
{
    class ArmyBuilder
    {
        private static int _territoryCount;
        private static int _continentCount;

        public static int ReinforcmentsCalculator()
        {
            var territory = CountByTerritories();
            var continent = CountByContinent();
            var trades = TradeCards();
            var armies = territory + continent + trades;
            var player = GameBoard.GetBoard().CurrentPlayer;

            Console.Clear();
            Colour.SouthAmericaRed("\t\t  **** Risk! ****\n");
            Console.WriteLine("\t=======================================");
            Colour.PrintPlayer(player.Colour, "\t\t" + player.Name + "'s ");
            Console.WriteLine("Reinforcements");
            Console.WriteLine("\t{0} Territories occupied = {1} armies", _territoryCount, territory);
            Console.WriteLine("\t{0} continents controlled = {1} armies", _continentCount, continent);
            Console.WriteLine("\tArmies earned from playing cards = {0}", trades);
            Console.WriteLine("\t=======================================");
            Console.WriteLine("\tTotal reinforcements this turn = {0}", armies);
            Console.WriteLine("\n\tPress any key to begin troop deployment....");
            Console.ReadKey();
            return armies;
        }

        private static int CountByTerritories()
        {
            var board = GameBoard.GetBoard();
            var count = 0;
            int result;
            foreach (var territory in board.GetEarth().Territories)
            {
                if (territory.Occupant == board.CurrentPlayer.Name)
                {
                    count += 1;
                }
            }

            _territoryCount = count;
            if (count < 9)
            {
                result = 3;
            }
            else
            {
                result = Convert.ToInt32(Math.Floor((double)count / 3));
            }
            return result;
        }

        private static int CountByContinent()
        {
            var board = GameBoard.GetBoard();
            var player = board.CurrentPlayer.Name;
            var asia = new List<string>();
            var europe = new List<string>();
            var northAmerica = new List<string>();
            var africa = new List<string>();
            var southAmerica = new List<string>();
            var australasia = new List<string>();
            int result = 0;

            foreach (var territory in board.GetEarth().Territories)
            {
                switch (territory.Continent)
                {
                    case "Asia":
                        asia.Add(territory.Occupant);
                        break;
                    case "Europe":
                        europe.Add(territory.Occupant);
                        break;
                    case "North America":
                        northAmerica.Add(territory.Occupant);
                        break;
                    case "Africa":
                        africa.Add(territory.Occupant);
                        break;
                    case "South America":
                        southAmerica.Add(territory.Occupant);
                        break;
                    case "Australasia":
                        australasia.Add(territory.Occupant);
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }
            }

            if (CheckContinentForRuler(asia, player)) { result += 7;}
            if (CheckContinentForRuler(europe, player)) { result += 5;}
            if (CheckContinentForRuler(northAmerica, player)) { result += 5;}
            if (CheckContinentForRuler(africa, player)) { result += 3;}
            if (CheckContinentForRuler(southAmerica, player)) { result += 2;}
            if (CheckContinentForRuler(australasia, player)) { result += 2;}

            return result;
        }

        private static bool CheckContinentForRuler(List<string> continent, string player)
        {
            var playerOccupied = 0;

            foreach (var occupant in continent)
            {
                if (occupant == player)
                {
                    playerOccupied++;
                }
            }

            if (continent.Count == playerOccupied)
            {
                _continentCount += 1;
                return true;
            }
            return false;
        }

        private static int TradeCards()
        {
            var player = GameBoard.GetBoard().CurrentPlayer;
            
            var result = 0;
            if (player.Cards != null && player.Cards.Count >= 3 )
            {
                result = CardTradeingEngine.TradeMenu();
            }
            return result;
        }
    }
}
