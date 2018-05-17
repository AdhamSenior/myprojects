using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace DrivingLicenseIssueApp.Logic
{
    using Common;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public partial class DrivingLicense
    {
        [JsonProperty(PropertyName = "driver")]
        public HolderInfo Holder { get; set; }

        [JsonProperty(PropertyName = "categories")]
        public Category[] CategoryList { get; set; }

        [JsonProperty(PropertyName = "issue_date")]
        public DateTime DateOfIssue { get; set; }

        [JsonProperty(PropertyName = "expire_date")]
        public DateTime DateOfExpiry { get; set; }

        [JsonProperty(PropertyName = "issue_region_id")]
        public int PlaceOfIssueId { get; set; }

        [JsonProperty(PropertyName = "issue_region_name")]
        public string PlaceOfIssue { get; set; }

        [JsonProperty(PropertyName = "license_number")]
        public string CardNumber { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "dl_id")]
        public long Id { get; set; }

        [JsonIgnore]
        public string CardSn { get; set; }

        [JsonIgnore]
        public string Category { get; set; }

        [JsonIgnore]
        public Image Photo { get; set; }

        [JsonIgnore]
        public Image Signature { get; set; }
        [JsonIgnore]
        public string Error
        {
            get { return LastError; }
        }
    }

    public class DlPostContractResolver : DefaultContractResolver
    {
        readonly Dictionary<Type, List<string>> _ignoreProps = new Dictionary<Type, List<string>>();

        public DlPostContractResolver(string type)
        {
            var dl = new List<string> { "status" };
            var dr = new List<string> { "driver_id" };
            var passportProps = new List<string> { "passport_id", "serialNumber" };
            var locationProps = new List<string> { "address_id" };
            var categoryProps = new List<string> { "id", "additional_info" };

            switch (type)
            {
                case "new":
                    dl.Add("dl_id");
                    dl.Add("license_number");
                    dl.Add("issue_region_name");
                    dr.Add("photo");
                    dr.Add("signature");
                    break;
                case "card":
                    dl.Add("issue_region_id");
                    break;
            }

            switch (type)
            {
                case "new":
                case "card":
                    _ignoreProps.Add(typeof(DrivingLicense), dl);
                    _ignoreProps.Add(typeof(HolderInfo), dr);
                    break;
                case "edit":
                    _ignoreProps.Add(typeof(DrivingLicense), dl);
                    break;
            }
            _ignoreProps.Add(typeof(Passport), passportProps);
            _ignoreProps.Add(typeof(Location), locationProps);
            _ignoreProps.Add(typeof(Category), categoryProps);
        }

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var properties = base.CreateProperties(type, memberSerialization);
            if (_ignoreProps.ContainsKey(type))
            {
                var ignoreList = _ignoreProps[type];
                properties = properties.Where(p => !p.Ignored && !ignoreList.Contains(p.PropertyName)).ToList();
            }
            else
                properties = properties.Where(p => !p.Ignored).ToList();
            return properties;
        }
    }
}
