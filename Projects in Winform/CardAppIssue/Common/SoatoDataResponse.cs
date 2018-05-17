
namespace Common
{
    using Newtonsoft.Json;

    public class SoatoDataResponse
    {
        [JsonProperty(PropertyName = "data")]
        public Soato[] Data { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        public static SoatoDataResponse Deserialize(string json)
        {
            SoatoDataResponse rs;
            try
            {
                var jss = new JsonSerializerSettings
                {
                    DateTimeZoneHandling = DateTimeZoneHandling.Local,
                    DateFormatString = "yyyyMMdd"
                };
                rs = JsonConvert.DeserializeObject<SoatoDataResponse>(json, jss);
            }
            catch
            {
                rs = new SoatoDataResponse();
            }
            return rs;
        }
    }
}
