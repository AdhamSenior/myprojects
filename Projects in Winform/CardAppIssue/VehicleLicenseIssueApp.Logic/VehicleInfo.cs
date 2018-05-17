using System;
using System.Text;

namespace VehicleLicenseIssueApp.Logic
{
    using Newtonsoft.Json;

    public class VehicleInfo
    {
        [JsonProperty(PropertyName = "reg_number")]
        public string RegNumber { get; set; }

        [JsonProperty(PropertyName = "model_id")]
        public int ModelId { get; set; }

        [JsonProperty(PropertyName = "model_name")]
        public string ModelName { get; set; }
        
        [JsonProperty(PropertyName = "mark_id")]
        public int MarkId { get; set; }

        [JsonProperty(PropertyName = "mark_name")]
        public string MarkName { get; set; }

        [JsonProperty(PropertyName = "color_id")]
        public int ColorId { get; set; }

        [JsonProperty(PropertyName = "color_name")]
        public string ColorName { get; set; }

        [JsonProperty(PropertyName = "vehicle_manufacture_year")]
        public int YearOfManufacture { get; set; }

        [JsonProperty(PropertyName = "type_id")]
        public int TypeId { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "vehicle_identification_number_kuzov")]
        public string VehicleIdentificationNumberKuzov { get; set; }

        [JsonProperty(PropertyName = "vehicle_identification_number_shassi")]
        public string VehicleIdentificationNumberShassi { get; set; }

        [JsonProperty(PropertyName = "gross_weight")]
        public decimal GrossWeight { get; set; }

        [JsonProperty(PropertyName = "curb_weight")]
        public decimal CurbWeight { get; set; }

        [JsonProperty(PropertyName = "engine_number")]
        public string EngineNumber { get; set; }

        [JsonProperty(PropertyName = "engine_power")]
        public int EnginePower { get; set; }

        [JsonProperty(PropertyName = "fuel_type_id")]
        public int FuelTypeId { get; set; }

        [JsonProperty(PropertyName = "fuel_type")]
        public string FuelType { get; set; }

        [JsonProperty(PropertyName = "engine_measurement_id")]
        public int EngineMasurementId { get; set; }

        [JsonProperty(PropertyName = "number_of_seats")]
        public int NumberOfSeats { get; set; }

        [JsonProperty(PropertyName = "number_of_standees")]
        public int? NumberOfStandees { get; set; }

        [JsonProperty(PropertyName = "special_marks")]
        public string SpecialMarks { get; set; }

        public string Validate()
        {
            var sb = new StringBuilder();

            RegNumber = RegNumber.ToSafeTrimmedString();
            if (String.IsNullOrEmpty(RegNumber))
                sb.AppendLine(String.Format(ErrorTexts.FieldIsEmpty, Texts.StateNumberPlate));

            if (ModelId == 0)
                sb.AppendLine(String.Format(ErrorTexts.FieldIsEmpty, Texts.ModelName));

            if (ColorId == 0)
                sb.AppendLine(String.Format(ErrorTexts.FieldIsEmpty, Texts.Color));

            if (YearOfManufacture == 0)
                sb.AppendLine(String.Format(ErrorTexts.FieldIsEmpty, Texts.YearOfManufacture));

            if (TypeId == 0)
                sb.AppendLine(String.Format(ErrorTexts.FieldIsEmpty, Texts.Type));

            VehicleIdentificationNumberKuzov = VehicleIdentificationNumberKuzov.ToSafeTrimmedString();
            if (String.IsNullOrEmpty(VehicleIdentificationNumberKuzov))
                sb.AppendLine(String.Format(ErrorTexts.FieldIsEmpty, Texts.VehicleIdentificationNumber));

            if (GrossWeight == 0)
                sb.AppendLine(String.Format(ErrorTexts.FieldIsEmpty, Texts.GrossWeight));

            if (CurbWeight == 0)
                sb.AppendLine(String.Format(ErrorTexts.FieldIsEmpty, Texts.CurbWeight));

            EngineNumber = EngineNumber.ToSafeTrimmedString();
            if (String.IsNullOrEmpty(EngineNumber))
                sb.AppendLine(String.Format(ErrorTexts.FieldIsEmpty, Texts.EngineNumber));

            if (EnginePower == 0)
                sb.AppendLine(String.Format(ErrorTexts.FieldIsEmpty, Texts.EnginePower));

            if (EngineMasurementId == 0)
                sb.AppendLine(String.Format(ErrorTexts.FieldIsEmpty, Texts.EnginePower));

            if (FuelTypeId == 0)
                sb.AppendLine(String.Format(ErrorTexts.FieldIsEmpty, Texts.FuelType));

            if (NumberOfSeats == 0)
                sb.AppendLine(String.Format(ErrorTexts.FieldIsEmpty, Texts.NumberOfSeats));

            return sb.ToString();
        }
    }
}
