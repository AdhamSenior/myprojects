using System.Collections.Generic;

namespace Common
{
    public class Sex
    {
        public SexTypes Type { get; set; }
        public string Name { get; set; }

        public static List<Sex> GetItems()
        {
            var rs = new List<Sex>
            {
                new Sex {Type = SexTypes.Male, Name = Texts.Male},
                new Sex {Type = SexTypes.Female, Name = Texts.Female}
            };
            return rs;
        }
    }

    public enum SexTypes
    {
        Male = 1,
        Female = 2
    }
}
