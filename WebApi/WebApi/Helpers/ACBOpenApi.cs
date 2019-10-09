using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApi.Dtos.Base;

namespace WebApi.Helpers
{
    public static class ACBOpenApi
    {
        static readonly HttpClient client = new HttpClient();

        public static async Task<ResponseBase<T>> Call<T>(HttpMethod method, string requestUri, List<KeyValuePair<string, string>> formData = null, string body = null)
        {
            var result = new ResponseBase<T>();
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://id.acb.com.vn");
                var request = new HttpRequestMessage(HttpMethod.Post, requestUri);

                //var keyValues = new List<KeyValuePair<string, string>>();
                //keyValues.Add(new KeyValuePair<string, string>("site", "http://www.google.com"));
                //keyValues.Add(new KeyValuePair<string, string>("content", "This is some content"));
                if (formData != null)
                {
                    request.Content = new FormUrlEncodedContent(formData);
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
