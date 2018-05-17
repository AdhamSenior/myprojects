using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Common
{
    using Database;

    public class UserSettings
    {
        public bool IsDrivingLicense { get; set; }

        static readonly UserSettings UserSetting = new UserSettings();
        public static UserSettings Instance
        {
            get { return UserSetting; }
        }
        public Dictionary<string, string> Items { get; set; }

        Dictionary<string, string> Read()
        {
            var rs = new Dictionary<string, string>();
            var path = Setting.DlDbPath;
            if (!IsDrivingLicense)
                path = Setting.VlDbPath;

            var db = new DbHelper(path);
            var src = db.FetchAll("UserSettings");
            if (ReferenceEquals(src, null))
                return rs;

            for (var i = 0; i < src.Rows.Count; i++)
            {
                var r = src.Rows[i];
                var key = r["Name"].ConvertTo<string>();
                var val = r["Value"].ConvertTo<string>();
                rs.Add(key, val);
            }

            return rs;
        }

        public void Save(Dictionary<string, string> data)
        {
            var path = Setting.DlDbPath;
            if (!IsDrivingLicense)
                path = Setting.VlDbPath;

            var db = new DbHelper(path);
            db.InsertOrReplaceMany("UserSettings", data.Select(d => new ParametersCollection
            {
                {"Name", d.Key, DbType.String}, 
                {"Value", d.Value, DbType.String}
            }).ToArray());
        }

        public void Load()
        {
            Items = Read();
        }
    }
}
