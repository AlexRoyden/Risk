using System.Collections.Generic;
using Newtonsoft.Json;

namespace Risk
{
    public class CardDeck
    {
        [JsonProperty("cards")]
        public List<Card> Cards { get; set; }
    }
}
