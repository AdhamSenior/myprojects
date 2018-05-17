using System;

namespace DrivingLicenseIssueApp.Logic
{
    using Newtonsoft.Json;

    public partial class DrivingLicense
    {
        [JsonIgnore]
        public string LastName { get { return Holder.LastName; } }

        [JsonIgnore]
        public string FirstName { get { return Holder.FirstName; } }

        [JsonIgnore]
        public string MiddleName { get { return Holder.MiddleName; } }

        [JsonIgnore]
        public DateTime DateOfBirth { get { return Holder.DateOfBirth; } }

        [JsonIgnore]
        public string PlaceOfBirth { get { return Holder.PlaceOfBirth; } }
    }
}
