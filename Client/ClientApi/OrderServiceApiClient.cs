using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ClientApi.Models;
using Newtonsoft.Json;

namespace ClientApi
{
    public class OrderServiceApiClient
    {
        private readonly string _url;
        private const string GET_ROUTES_FOR_RESPONSE_URL_PART = "GetRoutesToProcess";

        public OrderServiceApiClient(string url)
        {
            _url = url;
        }

        public async Task<IReadOnlyCollection<RouteToProcess>> GetRoutesToProcess(int page, int pageSize)
        {
            try
            {
                var client = new HttpClient();
                var response = client
                    .GetAsync($"{_url}{GET_ROUTES_FOR_RESPONSE_URL_PART}?page={page}&pageSize={pageSize}").Result;
                if (response.IsSuccessStatusCode)
                {
                    var pp = await response.Content.ReadAsStringAsync();
                    var t = JsonConvert.DeserializeObject<List<RouteToProcess>>(pp);

                    return t;
                }

                return new List<RouteToProcess>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}