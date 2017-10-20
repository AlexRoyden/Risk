using System.Collections.Generic;
using Newtonsoft.Json;

namespace Risk.Mappers
{
    public class EarthMapper
    {
        [JsonProperty("earth")]
        public List<TerritoryMapper> Territories { get; set; }
    }
}
