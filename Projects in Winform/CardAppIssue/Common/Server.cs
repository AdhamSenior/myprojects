using System;
using System.Threading;
using System.Threading.Tasks;

namespace Common
{
    using RestSharp;

    public class Server
    {
        public static async Task<IRestResponse> PostData(string json, string url)
        {
            return await SendData(json, url, Method.POST);
        }

        public static async Task<IRestResponse> PatchData(string json, string url)
        {
            return await SendData(json, url, Method.PATCH);
        }

        public static async Task<IRestResponse> GetDataList(string url, int page, int pageSize)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            FillHeader(request);
            request.AddParameter("p", page);
            request.AddParameter("s", pageSize);
            request.AddParameter("ubdd_id", User.Instance.UbddId);
            var response = await client.ExecuteGetTaskAsync(request);
            return response;
        }

        public static async Task<IRestResponse> GetEntity(string url)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            FillHeader(request);
            var response = await client.ExecuteGetTaskAsync(request);
            return response;
        }

        static async Task<IRestResponse> SendData(string json, string url, Method method)
        {
            var client = new RestClient(url);
            var request = new RestRequest(method);
            FillHeader(request);
            request.AddParameter("application/json", json, ParameterType.RequestBody);

            var cancelToken = new CancellationTokenSource();
            var response = await client.ExecuteTaskAsync(request, cancelToken.Token);
            return response;
        }

        static void FillHeader(RestRequest r)
        {
            if (!String.IsNullOrEmpty(User.Instance.AuthToken))
                r.AddHeader("X-Authorization", User.Instance.AuthToken);
            r.AddHeader("cache-control", "no-cache");
            r.AddHeader("content-type", "application/json");
        }
    }
}
