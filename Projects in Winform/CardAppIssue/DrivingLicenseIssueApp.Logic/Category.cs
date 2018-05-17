using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrivingLicenseIssueApp.Logic
{
    using Newtonsoft.Json;

    public class Category
    {
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonIgnore]
        public bool IsChecked { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "issue_date")]
        public DateTime? DateOfIssue { get; set; }

        [JsonProperty(PropertyName = "expire_date")]
        public DateTime? DateOfExpiry { get; set; }

        [JsonProperty(PropertyName = "additional_info")]
        public string AdditionalInformation { get; set; }

        public Category()
        {
            AdditionalInformation = String.Empty;
        }

        public static List<Category> GetItems()
        {
            var items = new List<Category>
            {
                new Category {Name = "A"},
                new Category {Name = "B"},
                new Category {Name = "C"},
                new Category {Name = "D"},
                new Category {Name = "BE"},
                new Category {Name = "CE"},
                new Category {Name = "DE"}
            };
            return items;
        }
        public static List<Category> GetItems(string json)
        {
            List<Category> items;
            try
            {
                var jss = new JsonSerializerSettings
                {
                    DateTimeZoneHandling = DateTimeZoneHandling.Local,
                    DateFormatString = "yyyyMMdd"
                };
                items = JsonConvert.DeserializeObject<List<Category>>(json, jss);
            }
            catch
            {
                items = new List<Category>();
            }
            items.ForEach(fe => fe.IsChecked = true);

            var all = GetItems();
            return (from a in all let n = items.FirstOrDefault(wh => wh.Name == a.Name) select ReferenceEquals(n, null) ? a : n).ToList();
        }
        public static List<Category> Deserialize(string json)
        {
            List<Category> items;
            try
            {
                var jss = new JsonSerializerSettings
                {
                    DateTimeZoneHandling = DateTimeZoneHandling.Local,
                    DateFormatString = "yyyyMMdd"
                };
                items = JsonConvert.DeserializeObject<List<Category>>(json, jss);
            }
            catch
            {
                items = new List<Category>();
            }
            return items;
        }
        public string Validate()
        {
            var sb = new StringBuilder();
            if (!IsChecked)
                return sb.ToString();

            if (!DateOfIssue.HasValue)
                sb.AppendLine(String.Format(ErrorTexts.ForCategoryFieldIsEmpty, Name, Texts.DateOfIssue));

            return sb.ToString();
        }
    }
}
