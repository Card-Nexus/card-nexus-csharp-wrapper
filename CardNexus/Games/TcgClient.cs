using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CardNexus.Games
{
    public class TcgClient
    {
        private readonly string baseUrl = "http://localhost:3000/v1/tcg";

        private readonly HttpClient httpClient;

        public TcgClient()
        {
            httpClient = new HttpClient();
        }

        public async Task<dynamic> GetAllTcg()
        {
            return await GetJsonAsync("/");
        }

        public async Task<dynamic> GetTcgByIdentifier(string identifier)
        {
            return await GetJsonAsync($"/{identifier}");
        }

        private async Task<dynamic> GetJsonAsync(string endpoint)
        {
            var response = await httpClient.GetStringAsync(baseUrl + endpoint);
            return JsonConvert.DeserializeObject<dynamic>(response);
        }
    }
}
