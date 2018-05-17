using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleLicenseIssueApp.Logic.Helper
{
    public class VLContractResolver : DefaultContractResolver
    {
        bool _isLegal;
        readonly Dictionary<Type, List<string>> _ignoreProps = new Dictionary<Type, List<string>>();
        public VLContractResolver(bool isLegal)
        {
            var dl = new List<string> { "owner" };
            var dl1 = new List<string> { "company" };
            if (isLegal)
                _ignoreProps.Add(typeof(VehicleLicense), dl);
            else
                _ignoreProps.Add(typeof(VehicleLicense), dl1);
        }

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            // Let the base class create all the JsonProperties 
            IList<JsonProperty> list = base.CreateProperties(type, memberSerialization);

            var properties = base.CreateProperties(type, memberSerialization);
            if (_ignoreProps.ContainsKey(type))
            {
                var ignoreList = _ignoreProps[type];
                properties = properties.Where(p => !p.Ignored && !ignoreList.Contains(p.PropertyName)).ToList();
            }
            else
                properties = properties.Where(p => !p.Ignored).ToList();
            
            // assign the C# property name
            foreach (JsonProperty prop in properties)
            {
                if (prop.PropertyName == "company")
                {
                    prop.PropertyName = "owner";
                }
            }

            return properties;
        }
    }
}
