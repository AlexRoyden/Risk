using System;
using System.Collections.Generic;

namespace Risk
{
    class PlayersCards
    {
        public List<Card> Infantry;
        public List<Card> Cavalry;
        public List<Card> Artillary;
        public List<Card> Wild;

        public PlayersCards(List<Card> playerCards)
        {
            foreach(var card in playerCards)
            {
                switch (card.Army)
                {
                    case "Infantry":
                        if (Infantry == null)
                        {
                            Infantry = new List<Card> {card};
                        }
                        else
                        {
                            Infantry.Add(card);
                        }
                        break;
                    case "Cavalry":
                        if (Cavalry == null)
                        {
                            Cavalry = new List<Card> { card };
                        }
                        else
                        {
                            Cavalry.Add(card);
                        }
                        break;
                    case "Artillery":
                        if (Artillary == null)
                        {
                            Artillary = new List<Card> { card };
                        }
                        else
                        {
                            Artillary.Add(card);
                        }
                        break;
                    case "Wild":
                        if (Wild == null)
                        {
                            Wild = new List<Card> { card };
                        }
                        else
                        {
                            Wild.Add(card);
                        }
                        break;
                    default:
                        Console.WriteLine("Card Error");
                        break;
                }
            }
        }

        /// <summary>
        /// retruns List<Card> containing ALL players cards
        /// </summary>
        public List<Card> GetPlayerCards()
        {
            var playerCards = new List<Card>();

            if (Infantry != null)
            {
                foreach (var card in Infantry)
                {
                    playerCards.Add(card);
                }
            }

            if (Cavalry != null)
            {
                foreach (var card in Cavalry)
                {
                    playerCards.Add(card);
                }
            }

            if (Artillary != null)
            {
                foreach (var card in Artillary)
                {
                    playerCards.Add(card);
                }
            }

            if (Wild != null)
            {
                foreach (var card in Wild)
                {
                    playerCards.Add(card);
                }
            }

            return playerCards;
        }
    }
}
