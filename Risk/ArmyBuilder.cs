using System;
using System.Collections.Generic;

namespace Risk
{
    public class ArmyBuilder
    {
        private static int _territoryCount;
        private static int _continentCount;
        public delegate void Del(int i);

        public static int ReinforcmentsCalculator(Earth earth, Player player)
        {
            var territory = ArmiesForTerritoriesOccupied(earth, player);
            var continent = ArmiesForContinentsOccupied(earth, player);
            var trades = TradeCards(player);
            var armies = territory + continent + trades;

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

        public static int ArmiesForTerritoriesOccupied(Earth earth, Player player)
        {
            var count = 0;
            int result;
            foreach (var territory in earth.Territories)
            {
                if (territory.Occupant == player.Name)
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

        public static int ArmiesForContinentsOccupied(Earth earth, Player player)
        {
            var asia = new List<string>();
            var europe = new List<string>();
            var northAmerica = new List<string>();
            var africa = new List<string>();
            var southAmerica = new List<string>();
            var australasia = new List<string>();
            int result = 0;

            foreach (var territory in earth.Territories)
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

            Del myLambda = x => result += x;
            if (CheckContinentForRuler(asia, player.Name)) { myLambda(7);}
            if (CheckContinentForRuler(europe, player.Name)) { myLambda(5);}
            if (CheckContinentForRuler(northAmerica, player.Name)) { myLambda(5);}
            if (CheckContinentForRuler(africa, player.Name)) { myLambda(3);}
            if (CheckContinentForRuler(southAmerica, player.Name)) { myLambda(2);}
            if (CheckContinentForRuler(australasia, player.Name)) { myLambda(2);}

            return result;
        }

        public static bool CheckContinentForRuler(List<string> continent, string player)
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

        public static int TradeCards(Player player)
        {
            var result = 0;
            if (player.Cards != null && player.Cards.Count >= 3 )
            {
                result = CardTradeingEngine.TradeMenu();
            }
            return result;
        }
    }
}
