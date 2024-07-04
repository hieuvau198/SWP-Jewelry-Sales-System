using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using RazorTest.Models;
using System.Text.Json;

namespace RazorTest.Services
{
    public class WarrantyService
    {
        private readonly ApiService _apiService;

        public WarrantyService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<List<Warranty>> GetWarrantysAsync()
        {
            return await _apiService.GetAsync<List<Warranty>>("https://hvjewel.azurewebsites.net/api/warranty");
        }

        public async Task<Warranty> GetWarrantyByIdAsync(string warrantyId)
        {
            return await _apiService.GetAsync<Warranty>($"https://hvjewel.azurewebsites.net/api/warranty/{warrantyId}");
        }

        public async Task<HttpResponseMessage> CreateWarrantyAsync(Warranty warranty)
        {
            return await _apiService.PostAsJsonAsync("https://hvjewel.azurewebsites.net/api/warranty", warranty);
        }

        public async Task<HttpResponseMessage> UpdateWarrantyAsync(Warranty warranty)
        {
            var url = "https://hvjewel.azurewebsites.net/api/warranty";
            var json = JsonConvert.SerializeObject(warranty, new JsonSerializerSettings
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

        public async Task<HttpResponseMessage> DeleteWarrantyAsync(string warrantyId)
        {
            return await _apiService.DeleteAsync($"https://hvjewel.azurewebsites.net/api/warranty/{warrantyId}");
        }

    }
}
