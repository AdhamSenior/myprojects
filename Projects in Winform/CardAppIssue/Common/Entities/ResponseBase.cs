using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class ResponseBase<T>
    {
        public ResponseBase()
        {
            Data = new List<T>();
        }

        [JsonProperty(PropertyName = "data")]
        public List<T> Data { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    }
}
