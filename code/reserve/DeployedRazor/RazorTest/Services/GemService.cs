using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using RazorTest.Models;
using System.Text.Json;

namespace RazorTest.Services
{
    public class GemService
    {
        private readonly ApiService _apiService;

        public GemService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<List<Gem>> GetGemsAsync()
        {
            return await _apiService.GetAsync<List<Gem>>("https://hvjewel.azurewebsites.net/api/gem");
        }

        public async Task<Gem> GetGemByIdAsync(string gemId)
        {
            return await _apiService.GetAsync<Gem>($"https://hvjewel.azurewebsites.net/api/gem/{gemId}");
        }

        public async Task<HttpResponseMessage> CreateGemAsync(Gem gem)
        {
            return await _apiService.PostAsJsonAsync("https://hvjewel.azurewebsites.net/api/gem", gem);
        }
        public async Task<HttpResponseMessage> UpdateGemAsync(Gem gem)
        {
            var url = "https://hvjewel.azurewebsites.net/api/gem";
            var json = JsonConvert.SerializeObject(gem, new JsonSerializerSettings
            {
                DateFormatString = "yyyy-MM-ddTHH:mm:ss.fffZ"
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            // In response to handle possible errors
            var response = await _apiService.PutAsync(url, content);

            // Check if the request was successful
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                // Log or handle the error as needed
                throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorContent}");
            }

            return response;
        }

        public async Task<HttpResponseMessage> DeleteGemAsync(string gemId)
        {
            return await _apiService.DeleteAsync($"https://hvjewel.azurewebsites.net/api/gem?gemId={gemId}");
        }

    }
}
