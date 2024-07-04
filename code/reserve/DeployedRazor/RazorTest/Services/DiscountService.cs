using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using RazorTest.Models;
using System.Text.Json;

namespace RazorTest.Services
{
    public class DiscountService
    {
        private readonly ApiService _apiService;

        public DiscountService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<List<Discount>> GetDiscountsAsync()
        {
            return await _apiService.GetAsync<List<Discount>>("https://hvjewel.azurewebsites.net/api/discount");
        }

        public async Task<Discount> GetDiscountByIdAsync(string discountId)
        {
            return await _apiService.GetAsync<Discount>($"https://hvjewel.azurewebsites.net/api/discount/{discountId}");
        }

        public async Task<HttpResponseMessage> CreateDiscountAsync(Discount discount)
        {
            return await _apiService.PostAsJsonAsync("https://hvjewel.azurewebsites.net/api/discount", discount);
        }

        public async Task<HttpResponseMessage> UpdateDiscountAsync(Discount discount)
        {
            var url = "https://hvjewel.azurewebsites.net/api/discount";
            var json = JsonConvert.SerializeObject(discount, new JsonSerializerSettings
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

        public async Task<HttpResponseMessage> DeleteDiscountAsync(string discountId)
        {
            return await _apiService.DeleteAsync($"https://hvjewel.azurewebsites.net/api/discount/{discountId}");
        }

    }
}
