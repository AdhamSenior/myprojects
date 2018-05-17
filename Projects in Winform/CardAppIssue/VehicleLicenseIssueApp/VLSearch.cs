using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleLicenseIssueApp
{
    public class VLSearch
    {
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public string INN { get; set; }
        public string StateNumber { get; set; }
        public bool IsLegal { get; set; }
    }
}
