using System;
using System.Collections.Generic;

namespace Common.Ext
{
    using Newtonsoft.Json.Linq;

    public class ApiResponse
    {
        public static string ParseError(string msg)
        {
            JObject json;
            try
            {
                json = JObject.Parse(msg);
            }
            catch
            {
                return msg;
            }

            var status = String.Empty;
            var tStatus = json.SelectToken("$.status");
            if (!ReferenceEquals(tStatus, null))
                status = tStatus.Value<string>();

            if (status.ToLower() == "success")
                return String.Empty;

            var data = String.Empty;
            var tData = json.SelectToken("$.data");
            if (!ReferenceEquals(tData, null))
                data = tData.Value<object>().ToSafeTrimmedString();

            var errorCode = String.Empty;
            var tErrorCode = json.SelectToken("$.error_code");
            if (!ReferenceEquals(tErrorCode, null))
                errorCode = tErrorCode.Value<string>();

            return String.Format("Status - {0}, Code - {1}, Data - {2}", status, errorCode, data);
        }

        public static Dictionary<string, string> ParseAuth(string msg)
        {
            var rs = new Dictionary<string, string>();
            JObject json;
            try
            {
                json = JObject.Parse(msg);
            }
            catch
            {
                return rs;
            }

            var tToken = json.SelectToken("$.data.token");
            if (!ReferenceEquals(tToken, null))
                rs.Add("token", tToken.Value<string>());

            var tRegion = json.SelectToken("$.data.ubdd.region_id");
            if (!ReferenceEquals(tRegion, null))
                rs.Add("region_id", tRegion.Value<string>());

            var id = json.SelectToken("$.data.ubdd.id");
            if (!ReferenceEquals(id, null))
                rs.Add("id", id.Value<string>());

            var tStatus = json.SelectToken("$.status");
            if (!ReferenceEquals(tStatus, null))
                rs.Add("status", tStatus.Value<string>());

            return rs;
        }
    }
}
