using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GetRequest
{
    public class Requestor
    {
        private readonly HttpClient _client = new HttpClient();

        public async Task<T> Get<T>(string resource)
        {
            HttpResponseMessage response = await _client.GetAsync(resource);
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
