using System.Collections.Generic;
using Newtonsoft.Json;

namespace Risk
{
    public class Territory : ITerritory
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("continent")]
        public string Continent { get; set; }
        [JsonProperty("occupant")]
        public string Occupant { get; set; }
        [JsonProperty("armies")]
        public int Armies { get; set; }
        [JsonProperty("neighbours")]
        public List<string> NeighboursNames { get; set; }
        public List<Territory> Neighbours { get; set; }
        [JsonProperty("territory number")]
        public int TerriroryNumber { get; set; }
    }
}
