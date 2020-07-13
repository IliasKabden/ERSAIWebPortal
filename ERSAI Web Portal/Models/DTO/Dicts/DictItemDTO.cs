using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERSAI_Web_Portal.Models.DTO.Dicts
{
    public class DictItemDTO : DictItemDTO<string> { }
    public class CountryDTO : DictItemDTO
    {
        public string NationalityName { get; set; }
        public string CSSIconClass { get; set; }
    }
    public class DictItemDTO<IDType>
    {
        public IDType ID { get; set; }
        public string Name { get; set; }
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool IsNotActive { get; set; }
    }
}