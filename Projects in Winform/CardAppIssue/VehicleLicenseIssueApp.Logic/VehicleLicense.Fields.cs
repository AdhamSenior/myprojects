using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleLicenseIssueApp.Logic
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public partial class VehicleLicense
    {
        [JsonProperty(PropertyName = "vl_id")]
        public long Id { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "owner")]
        public PersonalInfo Person { get; set; }

        [JsonProperty(PropertyName = "company")]
        public OrganizationInfo Organization { get; set; }

        [JsonProperty(PropertyName = "vehicle")]
        public VehicleInfo Vehicle { get; set; }

        [JsonProperty(PropertyName = "issue_date")]
        public DateTime DateOfIssue { get; set; }

        [JsonProperty(PropertyName = "ubdd_name")]
        public string UbddName { get; set; }

        [JsonProperty(PropertyName = "issue_region_id")]
        public int PlaceOfIssueId { get; set; }

        [JsonProperty(PropertyName = "issue_region")]
        public string PlaceOfIssue { get; set; }

        [JsonProperty(PropertyName = "license_number")]
        public string LicenseNumber { get; set; }

        [JsonProperty(PropertyName = "expire_date")]
        public DateTime? ExpireDate { get; set; }

        [JsonIgnore]
        public bool IsPersonal { get; set; }
        [JsonIgnore]
        public string Error
        {
            get { return LastError; }
        }

        public class VlPostContractResolver : DefaultContractResolver
        {
            readonly List<string> _ignoreProps = new List<string>();

            public VlPostContractResolver(string type, bool isPersonal)
            {
                switch (type)
                {
                    case "new":
                        _ignoreProps.Add("dl_id");
                        //_ignoreProps.Add("license_number");
                        //_ignoreProps.Add("photo");
                        //_ignoreProps.Add("signature");
                        //_ignoreProps.Add("status");
                        break;
                }

                _ignoreProps.Add(isPersonal ? "company" : "owner");
            }

            protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
            {
                var properties = base.CreateProperties(type, memberSerialization);
                properties = properties.Where(p => !p.Ignored && !_ignoreProps.Contains(p.PropertyName)).ToList();
                return properties;
            }
        }
    }
}
