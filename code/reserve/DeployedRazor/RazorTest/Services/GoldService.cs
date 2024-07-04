using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using RazorTest.Models;
using System.Text.Json;

namespace RazorTest.Services
{
    public class GoldService
    {
        private readonly ApiService _apiService;

        public GoldService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<List<Gold>> GetGoldsAsync()
        {
            return await _apiService.GetAsync<List<Gold>>("https://hvjewel.azurewebsites.net/api/gold");
        }

        public async Task<Gold> GetGoldByIdAsync(string goldId)
        {
            return await _apiService.GetAsync<Gold>($"https://hvjewel.azurewebsites.net/api/gold/{goldId}");
        }

        public async Task<HttpResponseMessage> CreateGoldAsync(Gold gold)
        {
            return await _apiService.PostAsJsonAsync("https://hvjewel.azurewebsites.net/api/gold", gold);
        }

        public async Task<HttpResponseMessage> UpdateGoldAsync(Gold gold)
        {
            var url = "https://hvjewel.azurewebsites.net/api/gold";
            var json = JsonConvert.SerializeObject(gold, new JsonSerializerSettings
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

        public async Task<HttpResponseMessage> DeleteGoldAsync(string goldId)
        {
            return await _apiService.DeleteAsync($"https://hvjewel.azurewebsites.net/api/gold?goldId={goldId}");
        }

    }
}
