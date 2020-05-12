using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Twinvision.BolRetailerApi
{
    public abstract class BolApiHttpRequestHandler
    {
        private const string BolApiUrl = "https://api.bol.com/retailer";
        private const string BolApiTestUrl = "https://api.bol.com/retailer-demo";
        private static bool UseDemoEnvironment { get; set; }
        private static string ClientId;
        private static string ClientSecret;
        private static Authorization Authorization;
        private static HttpClient httpClient { get; set; }
        public static HttpClient HttpClient
        {
            get
            {
                if (httpClient == null)
                {
                    httpClient = new HttpClient();
                }
                return httpClient;
            }
        }

        public static void Initialize(string clientId, string clientSecret, bool useDemoEnvironment = false)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            Authorization = GetAuthorization(ClientId, ClientSecret);
            UseDemoEnvironment = useDemoEnvironment;
        }

        private static Authorization GetAuthorization(string clientId, string clientSecret)
        {
            var authorizationString = clientId + ":" + clientSecret;
            HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(authorizationString)));
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(AcceptHeaders.V3Json));
            var htmlContent = new StringContent("", Encoding.ASCII, "application/json");
            var response = HttpClient.PostAsync(new Uri("https://login.bol.com/token?grant_type=client_credentials"), htmlContent).Result;
            var responseContent = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<Authorization>(responseContent);
        }

        protected async Task<HttpResponseMessage> Post(string path, HttpContent content, Dictionary<string, string> queryParameters = null, string acceptHeader = AcceptHeaders.V3Json)
        {
            return await ApiHttpRequest(path, (uri) => { return HttpClient.PostAsync(uri, content); }, queryParameters, acceptHeader);
        }

        protected async Task<HttpResponseMessage> Get(string path, Dictionary<string, string> queryParameters = null, string acceptHeader = AcceptHeaders.V3Json)
        {
            return await ApiHttpRequest(path, (uri) => { return HttpClient.GetAsync(uri); }, queryParameters, acceptHeader);
        }

        protected async Task<HttpResponseMessage> Put(string path, HttpContent content, Dictionary<string, string> queryParameters = null, string acceptHeader = AcceptHeaders.V3Json)
        {
            return await ApiHttpRequest(path, (uri) => { return HttpClient.PutAsync(uri, content); }, queryParameters, acceptHeader);
        }
        protected async Task<HttpResponseMessage> Delete(string path, Dictionary<string, string> queryParameters = null, string acceptHeader = AcceptHeaders.V3Json)
        {
            return await ApiHttpRequest(path, (uri) => { return HttpClient.DeleteAsync(uri); }, queryParameters, acceptHeader);
        }

        protected async Task<HttpResponseMessage> ApiHttpRequest(string path, Func<Uri, Task<HttpResponseMessage>> httpRequest, Dictionary<string, string> queryParameters = null, string acceptHeader = AcceptHeaders.V3Json)
        {
            string requestUrl = (UseDemoEnvironment ? BolApiTestUrl : BolApiUrl) + path;
            var builder = new UriBuilder(requestUrl);
            if (queryParameters != null)
            {
                foreach (var kvp in queryParameters)
                {
                    if (!builder.Query.Contains("?"))
                    {
                        builder.Query = "?" + kvp.Key + "=" + kvp.Value;
                    }
                    else
                    {
                        builder.Query += "&" + kvp.Key + "=" + kvp.Value;
                    }
                }
            }
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(acceptHeader));
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Authorization.Access_token);
            var response = await httpRequest(builder.Uri);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                Authorization = GetAuthorization(ClientId, ClientSecret);
                HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Authorization.Access_token);
                response = await httpRequest(builder.Uri);
            }
            if (!response.IsSuccessStatusCode)
            {
                var responseContentString = await response.Content.ReadAsStringAsync();
                ApiCallException apiCallException = null;
                try
                {
                    apiCallException = JsonConvert.DeserializeObject<ApiCallException>(responseContentString);
                }
                catch
                {
                    throw new BolRetailerApiException("StatusCode: " + response.StatusCode.ToString() + " Reason: " + response.ReasonPhrase + " Content: " + response.Content.ReadAsStringAsync().Result);
                }
                throw apiCallException;
            }
            return response;
        }
    }
}
