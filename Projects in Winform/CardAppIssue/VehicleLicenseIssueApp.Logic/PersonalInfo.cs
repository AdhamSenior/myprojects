using System;
using System.Text;

namespace VehicleLicenseIssueApp.Logic
{
    using Common;
    using Newtonsoft.Json;

    public class PersonalInfo
    {
        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "middle_name")]
        public string MiddleName { get; set; }

        [JsonProperty(PropertyName = "region_name_birth")]
        public string PlaceOfBirth { get; set; }

        [JsonProperty(PropertyName = "date_of_birth")]
        public DateTime DateOfBirth { get; set; }

        [JsonProperty(PropertyName = "pinfl")]
        public string PersonalNumber { get; set; }
        
        [JsonProperty(PropertyName = "address")]
        public Location Address { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "identifier")]
        public string Identifier { get; set; }

        public PersonalInfo()
        {
            Address = new Location();
        }

        public string Validate()
        {
            var sb = new StringBuilder();
            LastName = LastName.ToSafeTrimmedString();
            if (String.IsNullOrEmpty(LastName))
                sb.AppendLine(String.Format(ErrorTexts.FieldIsEmpty, Texts.LastName));

            FirstName = FirstName.ToSafeTrimmedString();
            if (String.IsNullOrEmpty(FirstName))
                sb.AppendLine(String.Format(ErrorTexts.FieldIsEmpty, Texts.FirstName));

            MiddleName = MiddleName.ToSafeTrimmedString();
            if (String.IsNullOrEmpty(MiddleName))
                sb.AppendLine(String.Format(ErrorTexts.FieldIsEmpty, Texts.MiddleName));

            PlaceOfBirth = PlaceOfBirth.ToSafeTrimmedString();
            if (String.IsNullOrEmpty(PlaceOfBirth))
                sb.AppendLine(String.Format(ErrorTexts.FieldIsEmpty, Texts.PlaceOfBirth));

            PersonalNumber = PersonalNumber.ToSafeTrimmedString();
            if (String.IsNullOrEmpty(PersonalNumber))
                sb.AppendLine(String.Format(ErrorTexts.FieldIsEmpty, Texts.PersonalNumber));

            if (DateOfBirth == VehicleLicense.MinDate)
                sb.AppendLine(String.Format(ErrorTexts.FieldIsEmpty, Texts.DateOfBirth));

            var rs = Address.Validate();
            if (!String.IsNullOrEmpty(rs))
                sb.AppendLine(rs);
            return sb.ToString();
        }

        public string GetFullName()
        {
            var lastName = LastName.ToSafeTrimmedString();
            var firstName = FirstName.ToSafeTrimmedString();
            var middleName = MiddleName.ToSafeTrimmedString();
            return String.Format("{0} {1} {2}", lastName, firstName, middleName);
        }
    }
}
