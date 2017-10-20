using Newtonsoft.Json;

namespace Risk.Mappers
{
    public class CardMapper
    {
        [JsonProperty("army")]
        public string Army { get; set; }
        [JsonProperty("territory")]
        public string Territory { get; set; }
    }
}
