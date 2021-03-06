﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Risk
{
    class GameStateMapper
    {
        [JsonProperty("earth")]
        public Earth Earth { get; set; }
        [JsonProperty("cards")]
        public Queue<Card> Cards { get; set; }
        [JsonProperty("used Cards")]
        public CardDeck UsedCards { get; set; }
        [JsonProperty("traded card sets")]
        public int TradedCardSets { get; set; }
        [JsonProperty("players")]
        public List<Player> Players { get; set; }
        [JsonProperty("current player")]
        public Player CurrentPlayer { get; set; }
        [JsonProperty("player turn queue")]
        public Queue<Player> PlayerTurnQueue { get; set; }
    }
}
