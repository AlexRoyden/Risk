using System.Collections.Generic;
using Newtonsoft.Json;

namespace Risk.Mappers
{
    public class CardDeckMapper
    {
        [JsonProperty("cards")]
        public List<CardMapper> Cards { get; set; }
    }
}
