using Newtonsoft.Json;

namespace Risk
{
    class SaveMetaMapper
    {
        [JsonProperty("save1count")]
        public int Save1Count { get; set; }
        [JsonProperty("save1date")]
        public string Save1Date { get; set; }
        [JsonProperty("save2count")]
        public int Save2Count { get; set; }
        [JsonProperty("save2date")]
        public string Save2Date { get; set; }
        [JsonProperty("save3count")]
        public int Save3Count { get; set; }
        [JsonProperty("save3date")]
        public string Save3Date { get; set; }
        [JsonProperty("save4count")]
        public int Save4Count { get; set; }
        [JsonProperty("save4date")]
        public string Save4Date { get; set; }
        [JsonProperty("save5count")]
        public int Save5Count { get; set; }
        [JsonProperty("save5date")]
        public string Save5Date { get; set; }
        [JsonProperty("save6count")]
        public int Save6Count { get; set; }
        [JsonProperty("save6date")]
        public string Save6Date { get; set; }
    }
}
