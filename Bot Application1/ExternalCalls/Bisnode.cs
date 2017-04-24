using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BotApplication1
    
{
    class BisnodeAPÍ
    {
        private const string AuthenticationEndpoint = "https://login.bisnode.com/as/token.oauth2";

        public class bisnode
        {
            public string access_token { get; set; }
            public string token_type { get; set; }
            public int expires_in { get; set; }

            static HttpClient client = new HttpClient();
            //string bisnodeURL =

            public async Task RunAsync()
                {
                    client.BaseAddress = new Uri(AuthenticationEndpoint);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    //HttpResponseMessage response = null;

                }
            //static async Task<Product> GetProductAsync(string path)
            //{
            //    Product product = null;
            //    HttpResponseMessage response = await client.GetAsync(path);
            //    if (response.IsSuccessStatusCode)
            //    {
            //        product = await response.Content.ReadAsAsync<Product>();
            //    }
            //    return product;
            //}
        }
    }
}
