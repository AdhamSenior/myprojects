using System.Collections.Generic;

namespace Common
{
    public class Citizenship
    {
        public int Id { get; set; }
        public CitizenshipTypes Type { get; set; }
        public string Name { get; set; }

        public static List<Citizenship> GetItems()
        {
            var rs = new List<Citizenship>
            {
                new Citizenship {Id = 1, Type = CitizenshipTypes.Citizen, Name = Texts.Citizen},
                new Citizenship {Id = 2, Type = CitizenshipTypes.Stateless, Name = Texts.Stateless},
                new Citizenship {Id = 3, Type = CitizenshipTypes.Foreign, Name = Texts.Foreign}
            };
            return rs;
        }
    }

    public enum CitizenshipTypes
    {
        Citizen = 1,
        Stateless = 2,
        Foreign = 3
    }
}
