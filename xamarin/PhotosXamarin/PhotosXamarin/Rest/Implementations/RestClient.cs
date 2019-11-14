using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PhotosXamarin.Rest
{
    public class RestClient : IRestClient
    {
        internal const string ACCEPT_VERSION = "Accept-Version";
        internal const string ACCEPT_VERSION_VALUE = "v1";
        internal const string AUTHORIZATION = "Authorization";
        internal const string AUTHORIZATION_VALUE = "Client-ID";

        public async Task<TResult> MakeApiCall<TResult>(string url, HttpMethod method, object data = null) where TResult : class
        {
            url = url.Replace("http://", "https://");

            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage { RequestUri = new Uri(url), Method = method })
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue(AUTHORIZATION, AUTHORIZATION_VALUE);
                    request.Headers.Add(ACCEPT_VERSION, ACCEPT_VERSION_VALUE);

                    if (method != HttpMethod.Get)
                    {
                        var json = JsonConvert.SerializeObject(data);
                        request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                    }

                    HttpResponseMessage response = new HttpResponseMessage();
                    try
                    {
                        response = await httpClient.SendAsync(request).ConfigureAwait(false);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception();
                    }

                    var stringSerialized = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<TResult>(stringSerialized);
                }
            }
        }
    }
}
