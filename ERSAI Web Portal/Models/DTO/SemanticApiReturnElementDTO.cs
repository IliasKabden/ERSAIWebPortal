using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERSAI_Web_Portal.Models.DTO
{
    public class SemanticApiReturnElementDTO
    {
        [JsonProperty("results")]
        public IEnumerable<ResultsItem> Results { get; set; }
        public class ResultsItem
        {
            [JsonProperty("value")]
            public string Value { get; set; }
            [JsonProperty("name")]
            public string Name { get; set; }
        }
    }
}