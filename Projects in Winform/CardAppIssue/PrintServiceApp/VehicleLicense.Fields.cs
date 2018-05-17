using System;
using Newtonsoft.Json;

namespace PrintServiceApp
{
    public partial class VehicleLicense
    {
        [JsonIgnore]
        public bool IsIndividual { get; set; }

        [JsonIgnore]
        public string LastName { get; set; }

        [JsonIgnore]
        public string FirstName { get; set; }

        [JsonIgnore]
        public string MiddleName { get; set; }

        [JsonIgnore]
        public string CompanyName { get; set; }

        [JsonIgnore]
        public string Region { get; set; }

        [JsonIgnore]
        public string City { get; set; }

        [JsonIgnore]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "registration_number")]
        public string RegNumber { get; set; }

        [JsonProperty(PropertyName = "model")]
        public string Model { get; set; }

        [JsonProperty(PropertyName = "color")]
        public string Color { get; set; }

        [JsonProperty(PropertyName = "owner")]
        public string Owner { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string FullAddress { get; set; }

        [JsonProperty(PropertyName = "issue_date")]
        public DateTime DateOfIssue { get; set; }

        [JsonProperty(PropertyName = "ubdd_department")]
        public string PlaceOfIssue { get; set; }

        [JsonProperty(PropertyName = "personal_number")]
        public string PersonalNumber { get; set; }

        [JsonProperty(PropertyName = "vehicle_manufacture_year")]
        public string YearOfManufacture { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "vehicle_identification_number")]
        public string VehicleIdentificationNumber { get; set; }

        [JsonProperty(PropertyName = "gross_weight")]
        public float GrossWeight { get; set; }

        [JsonProperty(PropertyName = "curb_weight")]
        public float CurbWeight { get; set; }

        [JsonProperty(PropertyName = "engine_number")]
        public string EngineNumber { get; set; }

        [JsonProperty(PropertyName = "engine_power")]
        public string EnginePower { get; set; }

        [JsonProperty(PropertyName = "fuel_type")]
        public string FuelType { get; set; }

        [JsonProperty(PropertyName = "number_of_seats")]
        public int NumberOfSeats { get; set; }

        [JsonProperty(PropertyName = "number_of_standees")]
        public int NumberOfStandees { get; set; }

        [JsonProperty(PropertyName = "special_marks")]
        public string SpecialMarks { get; set; }
    }
}
