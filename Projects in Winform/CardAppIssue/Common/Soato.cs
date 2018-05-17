using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Common
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using RestSharp;

    public class Soato
    {
        [JsonProperty(PropertyName = "key")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "parent_key", NullValueHandling = NullValueHandling.Ignore)]
        public int ParentId { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string NameUz { get; set; }

        [JsonIgnore]
        public int Code { get; set; }
        [JsonIgnore]
        public string NameRu { get; set; }
        [JsonIgnore]
        public string AdmincenterRu { get; set; }
        [JsonIgnore]
        public string AdmincenterUz { get; set; }
        [JsonIgnore]
        public string FullName
        {
            get { return ToString(); }
        }
        [JsonIgnore]
        public int IsDeleted { get; set; }

        public static List<Soato> Items = new List<Soato>();
        static Soato()
        {
            //LoadItems();
        }

        static void LoadItems()
        {
            var txt = File.ReadAllText("SOATO.json");
            var json = JObject.Parse(txt);
            var data = json["data"];
            if (ReferenceEquals(data, null))
                return;

            foreach (var d in data)
            {
                var id = 0;
                if (d["_id_"].Type != JTokenType.Null)
                    id = d["_id_"].Value<int>();
                if (id == 0)
                    continue;

                var parentId = 0;
                if (d["_parent_id_"].Type != JTokenType.Null)
                    parentId = d["_parent_id_"].Value<int>();

                var code = 0;
                if (d["code"].Type != JTokenType.Null)
                    code = d["code"].Value<int>();

                var isDeleted = 0;
                if (d["isdeleted"].Type != JTokenType.Null)
                    isDeleted = d["isdeleted"].Value<int>();

                var nameRu = String.Empty;
                if (d["name_ru"].Type != JTokenType.Null)
                    nameRu = d["name_ru"].Value<string>();

                var nameUz = String.Empty;
                if (d["name_uz"].Type != JTokenType.Null)
                    nameUz = d["name_uz"].Value<string>();

                var admincenterRu = String.Empty;
                if (d["admincenter_ru"].Type != JTokenType.Null)
                    admincenterRu = d["admincenter_ru"].Value<string>();

                var admincenterUz = String.Empty;
                if (d["admincenter_uz"].Type != JTokenType.Null)
                    admincenterUz = d["admincenter_uz"].Value<string>();

                Items.Add(new Soato
                {
                    Id = id,
                    ParentId = parentId,
                    Code = code,
                    NameRu = nameRu,
                    NameUz = nameUz,
                    AdmincenterRu = admincenterRu,
                    AdmincenterUz = admincenterUz,
                    IsDeleted = isDeleted
                });
            }
        }
        public override string ToString()
        {
            return String.Format("{0} : {1}", Id, NameUz);
        }
        public static async Task LoadRegions()
        {
            var url = String.Format("{0}/api/v1/refs/regions", Setting.ApiUrl);
            var response = await Server.GetEntity(url);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = response.Content;
                var obj = SoatoDataResponse.Deserialize(content);
                Items = obj.Data.ToList();
            }
            else
                Items = new List<Soato>();
        }

        public static List<Soato> GetRegions()
        {
            return Items.Where(wh => wh.ParentId == 0).ToList();
        }

        public static string FindById(int id)
        {
            var item = Items.FirstOrDefault(fi => fi.Id == id);
            if (!ReferenceEquals(item, null))
                return item.NameUz;
            return String.Empty;
        }
    }
}
