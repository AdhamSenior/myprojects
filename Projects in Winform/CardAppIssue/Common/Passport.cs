using System;
using System.Text;

namespace Common
{
    using Newtonsoft.Json;

    public class Passport
    {
        [JsonProperty(PropertyName = "passport_id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "seria")]
        public string Seria { get; set; }

        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        [JsonProperty(PropertyName = "serialNumber")]
        public string SerialNumber { get; set; }

        public string Validate()
        {
            var sb = new StringBuilder();
            var ser = Seria.ToSafeTrimmedString();
            if (String.IsNullOrEmpty(ser))
                sb.AppendLine(String.Format(ErrorTexts.FieldIsEmpty, Texts.PassportSeries));

            if (Number == 0)
                sb.AppendLine(String.Format(ErrorTexts.FieldIsEmpty, Texts.PassportNumber));

            return sb.ToString();
        }
    }
}
