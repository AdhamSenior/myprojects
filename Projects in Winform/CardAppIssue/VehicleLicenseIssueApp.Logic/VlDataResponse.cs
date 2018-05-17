using System.Collections.Generic;

namespace VehicleLicenseIssueApp.Logic
{
    using Newtonsoft.Json;
    using System;
    using VehicleLicenseIssueApp.Logic.Helper;

    public class VlDataResponse
    {
        [JsonProperty(PropertyName = "data")]
        public VlData Data { get; set; }

        public static VlDataResponse Deserialize(string json, bool isLegal)
        {
            VlDataResponse rs;
            try
            {
                var jss = new JsonSerializerSettings
                {
                    ContractResolver = new VLContractResolver(isLegal),
                    DateTimeZoneHandling = DateTimeZoneHandling.Local,
                    DateFormatString = "yyyyMMdd"
                };
                rs = JsonConvert.DeserializeObject<VlDataResponse>(json, jss);
            }
            catch (Exception ex)
            {
                rs = new VlDataResponse();
            }
            return rs;
        }
    }

    public class VlData
    {
        [JsonProperty(PropertyName = "total_number")]
        public int TotalNumber { get; set; }

        [JsonProperty(PropertyName = "slice")]
        public List<VehicleLicense> Items { get; set; }
    }
}