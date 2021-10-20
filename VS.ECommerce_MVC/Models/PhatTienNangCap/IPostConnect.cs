using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PhatTienNangCap
{
    //public class ServiceConnect
    //{
    //    public interface IPostConnect
    //    {
    //        Task<T> CallAsync<T>(string host, string url, string token, HttpMethod httpMethod, string content);
    //    }

    //    public class PostConnect : IPostConnect
    //    {
    //        public PostConnect()
    //        {
    //        }

    //        //public async Task<T> CallAsync<T>(string host, string url, string token, HttpMethod httpMethod, string content)
    //        //{
    //        //    using (var httpClientHandler = new HttpClientHandler())
    //        //    {
    //        //        httpClientHandler.PreAuthenticate = true;
    //        //        httpClientHandler.UseDefaultCredentials = true;

    //        //        var basicCredCache = new CredentialCache();
    //        //        var basicCredentials = new NetworkCredential();
    //        //        basicCredCache.Add(new Uri(new Uri(host), url), "Basic", basicCredentials);
    //        //        httpClientHandler.Credentials = basicCredCache;

    //        //        using (var client = new HttpClient(httpClientHandler))
    //        //        {
    //        //            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", token);
    //        //            client.DefaultRequestHeaders.Add("Token", token);
    //        //            client.BaseAddress = new Uri(host);
    //        //            using (var request = new HttpRequestMessage(httpMethod, url))
    //        //            {
    //        //                if (!string.IsNullOrWhiteSpace(content))
    //        //                    request.Content = new StringContent(content, Encoding.UTF8, "application/json");
    //        //                try
    //        //                {
    //        //                    var response = await client.SendAsync(request);
    //        //                    if (response.IsSuccessStatusCode)
    //        //                    {
    //        //                        string strResponse = await response.Content.ReadAsStringAsync();
    //        //                        return JsonConvert.DeserializeObject<T>(strResponse, new JsonSerializerSettings
    //        //                        {
    //        //                            ContractResolver = new CamelCasePropertyNamesContractResolver()
    //        //                        });
    //        //                    }
    //        //                    else
    //        //                    {
    //        //                        throw new Exception(response.Content.ToString());
    //        //                    }
    //        //                }
    //        //                catch (Exception ex)
    //        //                {
    //        //                    throw new Exception(ex.Message);
    //        //                }
    //        //            }
    //        //        }
    //        //    }
    //        //}
    //    }
    //}
}