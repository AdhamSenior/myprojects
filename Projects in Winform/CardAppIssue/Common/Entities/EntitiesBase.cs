using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class EntitiesBase
    {
        [JsonProperty(PropertyName = "key")]
        public int Key { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        [JsonProperty(PropertyName = "parent_key")]
        public int? ParentKey { get; set; }
    }
}
