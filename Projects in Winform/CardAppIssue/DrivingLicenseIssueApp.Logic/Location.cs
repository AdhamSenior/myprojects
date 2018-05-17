using System;
using System.Text;

namespace DrivingLicenseIssueApp.Logic
{
    using Newtonsoft.Json;

    public class Location
    {
        [JsonProperty(PropertyName = "region_name")]
        public string Region { get; set; }

        [JsonProperty(PropertyName = "rayon_name")]
        public string District { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var region = Region.ToSafeTrimmedString();
            if (!String.IsNullOrEmpty(region))
                sb.Append(region + ", ");

            var district = District.ToSafeTrimmedString();
            if (!String.IsNullOrEmpty(district))
                sb.Append(district + ", ");

            var address = Address.ToSafeTrimmedString();
            if (!String.IsNullOrEmpty(address))
                sb.Append(address);

            return sb.ToString();
        }

        public string Validate()
        {
            var sb = new StringBuilder();
            var region = Region.ToSafeTrimmedString();
            if (String.IsNullOrEmpty(region))
                sb.AppendLine(String.Format(ErrorTexts.FieldIsEmpty, Texts.Region));

            var district = District.ToSafeTrimmedString();
            if (String.IsNullOrEmpty(district))
                sb.AppendLine(String.Format(ErrorTexts.FieldIsEmpty, Texts.District));

            var address = Address.ToSafeTrimmedString();
            if (String.IsNullOrEmpty(address))
                sb.AppendLine(String.Format(ErrorTexts.FieldIsEmpty, Texts.Address));

            return sb.ToString();
        }
    }
}
