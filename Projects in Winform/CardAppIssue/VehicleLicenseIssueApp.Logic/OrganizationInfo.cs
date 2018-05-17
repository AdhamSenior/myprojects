using System;
using System.Text;

namespace VehicleLicenseIssueApp.Logic
{
    using Common;
    using Newtonsoft.Json;

    public class OrganizationInfo
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "inn")]
        public string Inn { get; set; }

        [JsonProperty(PropertyName = "address")]
        public Location Address { get; set; }

        public OrganizationInfo()
        {
            Address = new Location();
        }

        public string Validate()
        {
            var sb = new StringBuilder();
            Name = Name.ToSafeTrimmedString();
            if (String.IsNullOrEmpty(Name))
                sb.AppendLine(String.Format(ErrorTexts.FieldIsEmpty, Texts.CompanyName));

            Inn = Inn.ToSafeTrimmedString();
            if (String.IsNullOrEmpty(Inn))
                sb.AppendLine(String.Format(ErrorTexts.FieldIsEmpty, Texts.Inn));

            var rs = Address.Validate();
            if (!String.IsNullOrEmpty(rs))
                sb.AppendLine(rs);
            return sb.ToString();
        }

        public string GetFullName()
        {
            return Name;
        }
    }
}
