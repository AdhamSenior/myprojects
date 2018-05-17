using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class EntitiesCollections
    {
        static readonly EntitiesCollections entitiesCollections = new EntitiesCollections();

        public static EntitiesCollections Instance
        {
            get { return entitiesCollections; }
        }
        public List<Colors> Colors { get; set; }
        public List<Models> Models { get; set; }
        public List<Marks> Marks { get; set; }
        public List<Measurements> Measurements { get; set; }
        public List<Regions> Regions { get; set; }
        public List<Fuels> Fuels { get; set; }
        public List<Ubdds> Ubdd { get; set; }
        public List<VehicleTypes> VehicleTypes { get; set; }
    }
}
