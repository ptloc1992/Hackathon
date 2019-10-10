using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApi.Dtos.Base;
using WebApi.Enums;

namespace WebApi.Helpers
{
    public static class ACBOpenApi
    {
        static readonly HttpClient client = new HttpClient();

        public static async Task<ResponseBase<T>> Call<T>(HttpContext context, MethodBase method, string requestUri, List<KeyValuePair<string, string>> formData = null, string body = null, bool isLogin = false)
        {
            var result = new ResponseBase<T>();
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage();
                client.BaseAddress = isLogin ? new Uri("https://id.acb.com.vn") : new Uri("https://api.dev.acb.com.vn");
                if (context != null)
                {
                    var auth = context.Request.Headers.FirstOrDefault(x => x.Key == "Authorization");
                    if (auth.Value.ToString() != null)
                    {
                        client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", auth.Value.ToString()));
                    }
                }
                switch (method)
                {
                    case MethodBase.GET:
                        request = new HttpRequestMessage(HttpMethod.Get, requestUri);
                        break;
                    case MethodBase.POST:
                        request = new HttpRequestMessage(HttpMethod.Post, requestUri);
                        break;
                    case MethodBase.PUT:
                        break;
                    case MethodBase.PATH:
                        break;
                    case MethodBase.DELETE:
                        break;
                    default:
                        request = new HttpRequestMessage(HttpMethod.Post, requestUri);
                        break;
                }
                if (formData != null)
                {
                    request.Content = new FormUrlEncodedContent(formData);
                }
                if (!string.IsNullOrEmpty(body))
                {
                    request.Content = new StringContent(body, Encoding.UTF8, "application/json");
                }
                var response = await client.SendAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                    result.StatusCode = response.StatusCode;
                    result.Data = data;
                }
                else
                {
                    var error = JsonConvert.DeserializeObject<ErrorBase>(response.Content.ReadAsStringAsync().Result);
                    result.StatusCode = response.StatusCode;
                    result.Error = error;
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return result;
        }
    }
}
