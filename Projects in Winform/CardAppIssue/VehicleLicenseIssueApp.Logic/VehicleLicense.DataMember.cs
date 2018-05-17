using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleLicenseIssueApp.Logic
{
    using Newtonsoft.Json;

    public partial class VehicleLicense
    {
        [JsonIgnore]
        public string ModelName { get { return Vehicle.ModelName; } }

        [JsonIgnore]
        public string Make { get { return Vehicle.MarkName; } }

        [JsonIgnore]
        public string Color { get { return Vehicle.ColorName; } }

        [JsonIgnore]
        public string StateNumberPlate { get { return Vehicle.RegNumber; } }

        [JsonIgnore]
        public string CompanyName { get { return Organization.Name; } }
    }
}
