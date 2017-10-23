using System;
using System.Collections.Generic;

namespace Risk
{
    class ArmyBuilder
    {
        private static int _armies;

        public static int Counter()
        {
            CountByTerritories();
            CountByContinent();
            TradeCards();

            return _armies;
        }

        private static void CountByTerritories()
        {
            var board = GameBoard.GetBoard();
            var count = 0;

            foreach (var territory in board.GetEarth().Territories)
            {
                if (territory.Occupant == board.CurrentPlayer.Name)
                {
                    count += 1;
                }

                if (count < 9)
                {
                    _armies += 3;
                }
                else
                {
                    _armies += Convert.ToInt32(Math.Floor((double) count / 3));
                }
            }
        }

        private static void CountByContinent()
        {
            var board = GameBoard.GetBoard();
            var player = board.CurrentPlayer.Name;
            var asia = new List<string>();
            var europe = new List<string>();
            var northAmerica = new List<string>();
            var africa = new List<string>();
            var southAmerica = new List<string>();
            var australasia = new List<string>();

            foreach (var territory in board.GetEarth().Territories)
            {
                switch (territory.Continent)
                {
                    case "Asia":
                        asia.Add(territory.Occupant);
                        break;
                    case "europe":
                        europe.Add(territory.Occupant);
                        break;
                    case "northAmerica":
                        northAmerica.Add(territory.Occupant);
                        break;
                    case "africa":
                        africa.Add(territory.Occupant);
                        break;
                    case "southAmerica":
                        southAmerica.Add(territory.Occupant);
                        break;
                    case "australasia":
                        australasia.Add(territory.Occupant);
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }
            }

            if (CheckContinentForRuler(asia, player)) {_armies += 7;}
            if (CheckContinentForRuler(europe, player)) { _armies += 5;}
            if (CheckContinentForRuler(northAmerica, player)) { _armies += 5;}
            if (CheckContinentForRuler(africa, player)) { _armies += 3;}
            if (CheckContinentForRuler(southAmerica, player)) { _armies += 2;}
            if (CheckContinentForRuler(australasia, player)) { _armies += 2;}
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
                return true;
            }
            return false;
        }

        private static void TradeCards()
        {
            var player = GameBoard.GetBoard().CurrentPlayer;
            var count = player.Infantry.Count + player.Cavalry.Count + player.Artillary.Count + player.Wild.Count;

            if (player.Infantry.Count >= 3 || player.Cavalry.Count >= 3 || player.Artillary.Count >= 3)
            {
                _armies = CardTradeingEngine.TradeMenu(count);
            }
            else if (player.Infantry.Count >= 1 && player.Cavalry.Count >= 1 && player.Artillary.Count >= 1)
            {
                _armies = CardTradeingEngine.TradeMenu(count);
            }
            if (player.Infantry.Count >= 2 || player.Cavalry.Count >= 2 || player.Artillary.Count >= 2 && player.Wild.Count > 0)
            {
                _armies = CardTradeingEngine.TradeMenu(count);
            }
        }
    }
}
