using System;
using System.Threading.Tasks;

namespace Common
{
    using Newtonsoft.Json;
    using RestSharp;

    public class User
    {
        [JsonProperty(PropertyName = "login")]
        public string Login { get; set; }
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        [JsonIgnore]
        public int DepartmentId { get; set; }
        [JsonIgnore]
        public string Department { get; set; }
        [JsonIgnore]
        public string AuthToken { get; set; }
        [JsonIgnore]
        public bool IsDrivingLicense { get; set; }
        [JsonIgnore]
        public bool IsAuthorized
        {
            get { return !String.IsNullOrEmpty(AuthToken); }
        }
        [JsonIgnore]
        public bool IsInitDepartment
        {
            get { return !String.IsNullOrEmpty(Department); }
        }
        [JsonIgnore]
        public int UbddId { get; set; }

        static readonly User CurrentUser = new User();
        public static User Instance
        {
            get { return CurrentUser; }
        }

        public async Task<IRestResponse> PostLogin()
        {
            //if (Instance.IsDrivingLicense)
            return await PostLoginDl();
        }

        async Task<IRestResponse> PostLoginDl()
        {
            var jss = new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Local,
                DateFormatString = "yyyyMMdd"
            };

            var json = JsonConvert.SerializeObject(Instance, Formatting.Indented, jss);
            var url = String.Format("{0}/api/v1/login", Setting.ApiUrl);
            return await Server.PostData(json, url);
        }
    }
}
