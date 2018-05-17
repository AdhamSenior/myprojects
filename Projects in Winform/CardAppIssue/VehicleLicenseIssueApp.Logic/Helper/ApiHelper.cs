using Common;
using Common.Entities;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VehicleLicenseIssueApp.Logic.Helper
{
    public class ApiHelper
    {
        public static async Task<VlData> PrivateLicenses(int page, int size, Dictionary<string, string> SearchParametrs)
        {
            var url = String.Format("{0}/api/v1/vl/private", Setting.ApiUrl);

            return await SendData(url, Method.GET, page, size, false, SearchParametrs);
        }

        public static async Task<VlData> LegalLicenses(int page, int size,Dictionary<string,string> SearchParametrs)
        {
            var url = String.Format("{0}/api/v1/vl/legal", Setting.ApiUrl);

            return await SendData(url, Method.GET, page, size, true, SearchParametrs);
        }

        public static async Task<IRestResponse> CreatePrivateLicense(VehicleLicense license)
        {
            string json = SerializeObject(license);
            var url = String.Format("{0}/api/v1/vl/private", Setting.ApiUrl);

            return await SendData(json, url, Method.POST);
        }


        public static async Task<List<Regions>> GetRegions()
        {
            var url = String.Format("{0}/api/v1/refs/regions", Setting.ApiUrl);

            return await SendData<Regions>(url, Method.GET);
        }

        public static List<Regions> GetRayons(int regionId)
        {
            var url = String.Format("{0}/api/v1/refs/regions/{1}/rayons", Setting.ApiUrl, regionId);

            var response = SendDataNotAsync(url, Method.GET);
            RegionsResponse regionsResponse = new RegionsResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                regionsResponse = DeserializeObject<RegionsResponse>(response.Content);
            }

            return regionsResponse.Data;
        }

        public static async Task<List<Colors>> GetColors()
        {
            var url = String.Format("{0}/api/v1/refs/colors", Setting.ApiUrl);

            return await SendData<Colors>(url, Method.GET);
        }

        public static async Task<List<Models>> GetModels()
        {
            var url = String.Format("{0}/api/v1/refs/models", Setting.ApiUrl);

            return await SendData<Models>(url, Method.GET);            
        }

        public static async Task<List<Measurements>> GetMeasurements()
        {
            var url = String.Format("{0}/api/v1/refs/measurements", Setting.ApiUrl);

            return await SendData<Measurements>(url, Method.GET);
        }

        public static async Task<List<Marks>> GetMarks()
        {
            var url = String.Format("{0}/api/v1/refs/marks", Setting.ApiUrl);

            return await SendData<Marks>(url, Method.GET);
        }

        public static async Task<List<Fuels>> GetFuels()
        {
            var url = String.Format("{0}/api/v1/refs/fuels", Setting.ApiUrl);

            return await SendData<Fuels>(url, Method.GET);
        }

        public static async Task<List<Ubdds>> GetUbdds()
        {
            var url = String.Format("{0}/api/v1/refs/ubdds", Setting.ApiUrl);

            return await SendData<Ubdds>(url, Method.GET);
        }

        public static async Task<List<VehicleTypes>> GetVehicleTypes()
        {
            var url = String.Format("{0}/api/v1/refs/types", Setting.ApiUrl);

            return await SendData<VehicleTypes>(url, Method.GET);
        }


        public static async Task<IRestResponse> CreateLegalLicense(VehicleLicense license)
        {
            string json = SerializeObject(license, true);
            var url = String.Format("{0}/api/v1/vl/legal", Setting.ApiUrl);

            return await SendData(json, url, Method.POST);
        }

        private static string SerializeObject<T>(T obj)
        {
            var jss = new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Local,
                DateFormatString = "yyyyMMdd"
            };

            return JsonConvert.SerializeObject(obj, Formatting.Indented, jss);
        }

        private static string SerializeObject<T>(T obj, bool isLegal)
        {
            var jss = new JsonSerializerSettings
            {
                ContractResolver = new VLContractResolver(isLegal),
                DateTimeZoneHandling = DateTimeZoneHandling.Local,
                DateFormatString = "yyyyMMdd"
            };

            return JsonConvert.SerializeObject(obj, Formatting.Indented, jss);
        }


        private static T DeserializeObject<T>(string obj)
        {
            var jss = new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Local,
                DateFormatString = "yyyyMMdd"
            };

            return JsonConvert.DeserializeObject<T>(obj, jss);
        }

        private static async Task<IRestResponse> SendData(string json, string url, Method method)
        {
            var client = new RestClient(url);
            var request = new RestRequest(method);
            request.AddHeader("X-Authorization", User.Instance.AuthToken);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", json, ParameterType.RequestBody);

    
            var cancelToken = new CancellationTokenSource();
            var response = await client.ExecuteTaskAsync(request, cancelToken.Token);
            return response;
        }

        private static async Task<List<T>> SendData<T>(string url, Method method)
        {
            var client = new RestClient(url);
            var request = new RestRequest(method);
            request.AddHeader("X-Authorization", User.Instance.AuthToken);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            
            var cancelToken = new CancellationTokenSource();
            var response = await client.ExecuteTaskAsync(request, cancelToken.Token);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return DeserializeObject<ResponseBase<T>>(response.Content).Data;
            }

            return null;
        }

        
        private static IRestResponse SendDataNotAsync(string url, Method method)
        {
            var client = new RestClient(url);
            var request = new RestRequest(method);
            request.AddHeader("X-Authorization", User.Instance.AuthToken);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");

            var cancelToken = new CancellationTokenSource();
            var response = client.Execute(request);
            return response;
        }

        private static async Task<VlData> SendData(string url, Method method, int page, int size, bool isLegal, Dictionary<string, string> SearchParametrs)
        {
            var client = new RestClient(url);
            var request = new RestRequest(method);
            request.AddHeader("X-Authorization", User.Instance.AuthToken);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddParameter("p", page);
            request.AddParameter("s", size);
            request.AddParameter("ubdd_id", User.Instance.UbddId);
            foreach (var item in SearchParametrs)
            {
                request.AddParameter(item.Key, item.Value);
            }
            var cancelToken = new CancellationTokenSource();
            var response = await client.ExecuteTaskAsync(request, cancelToken.Token);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = response.Content;
                var obj = VlDataResponse.Deserialize(content, isLegal);
                return obj.Data;
            }
            else
                return null;
        }
    }
}
