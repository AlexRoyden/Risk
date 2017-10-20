using System.Collections.Generic;
using Newtonsoft.Json;

namespace Risk
{
    public class Earth
    {
        [JsonProperty("earth")]
        public List<Territory> Territories { get; set; }
    }
}
