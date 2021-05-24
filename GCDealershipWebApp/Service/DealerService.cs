using GCDealershipWebApp.Models;
using GCDealershipWebApp.Service.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace GCDealershipWebApp.Service
{
    public class DealerService : IDealerService
    {
        private readonly HttpClient _client;

        public DealerService(HttpClient client)
        {
            _client = client;
        }

        public async Task<DealerModelData> GetDataAsync()
        {
            return await _client.GetFromJsonAsync<DealerModelData>($"https://localhost:44316/api/Cars");
        }

        public async Task<DealerModelData> Search(string query)
        {
            return await _client.GetFromJsonAsync<DealerModelData>($"/search?query=make={query}&model={query}&year={query}&color={query}");
        }

        public async Task<DealerModelData> SearchYear(int year)
        {
            return await _client.GetFromJsonAsync<DealerModelData>($"/search?query={year}");
        }




    }
}
