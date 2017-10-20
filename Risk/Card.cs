using Newtonsoft.Json;

namespace Risk
{
    public class Card
    {
        [JsonProperty("army")]
        public string Army { get; set; }
        [JsonProperty("territory")]
        public string Territory { get; set; }
    }
}
