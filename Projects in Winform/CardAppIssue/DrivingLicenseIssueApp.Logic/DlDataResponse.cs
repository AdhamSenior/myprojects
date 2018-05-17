using System.Collections.Generic;

namespace DrivingLicenseIssueApp.Logic
{
    using Newtonsoft.Json;

    public class DlDataResponse
    {
        [JsonProperty(PropertyName = "data")]
        public DlData Data { get; set; }

        public static DlDataResponse Deserialize(string json)
        {
            DlDataResponse rs;
            try
            {
                var jss = new JsonSerializerSettings
                {
                    DateTimeZoneHandling = DateTimeZoneHandling.Local,
                    DateFormatString = "yyyyMMdd"
                };
                rs = JsonConvert.DeserializeObject<DlDataResponse>(json, jss);
            }
            catch
            {
                rs = new DlDataResponse();
            }
            return rs;
        }
    }

    public class DlData
    {
        [JsonProperty(PropertyName = "total_number")]
        public int TotalNumber { get; set; }

        [JsonProperty(PropertyName = "slice")]
        public List<DrivingLicense> Items { get; set; }
    }
}
