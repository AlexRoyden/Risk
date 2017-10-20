using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Risk
{
    public class BoardBuilder
    {
        public static Earth LoadNewTerritories()
        {
            //path += @"\WorldMapConfig.json";
            var path = @"..\..\ConfigFiles\WorldMapConfig.json";
            Earth earth;

            using (var stream = new StreamReader(path))
            {
                var json = stream.ReadToEnd();
                earth = JsonConvert.DeserializeObject<Earth>(json);
            }
            return earth;
        }

        public static Queue<Card> LoadCards(Random rnd)
        {
            var path = @"..\..\ConfigFiles\CardDeckConfig.json";
            CardDeck cardDeck;

            using (var stream = new StreamReader(path))
            {
                var json = stream.ReadToEnd();
                cardDeck = JsonConvert.DeserializeObject<CardDeck>(json);
            }

            int n = 44;
            while (n > 1)
            {
                int k = (rnd.Next(0, n) % n);
                n--;
                var value = cardDeck.Cards[k];
                cardDeck.Cards[k] = cardDeck.Cards[n];
                cardDeck.Cards[n] = value;
            }

            return new Queue<Card>(cardDeck.Cards);
        }

        public static Queue<Card> UsedCardsQueueMaker(CardDeck usedCards, Random rnd)
        {
            int n = usedCards.Cards.Count;
            while (n > 1)
            {
                int k = (rnd.Next(0, n) % n);
                n--;
                var value = usedCards.Cards[k];
                usedCards.Cards[k] = usedCards.Cards[n];
                usedCards.Cards[n] = value;
            }

            var cardQueue = new Queue<Card>(usedCards.Cards);
            return cardQueue;
        }

        public static void LoadTerritoryNeighbours(List<Territory> territoryList)
        {
            foreach (var territory in territoryList)
            {
                territory.Neighbours = new List<Territory>();
                foreach (var neighbour in territory.NeighboursNames)
                {
                    territory.Neighbours.Add(GameBoard.GetBoard().GetTerritoryByName(neighbour));
                }
            }
        }
    }
}
