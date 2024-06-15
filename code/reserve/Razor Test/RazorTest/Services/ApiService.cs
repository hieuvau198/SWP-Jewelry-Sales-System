using System.Text.Json;
using System.Text;
using RazorTest.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;

namespace RazorTest.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> GetAsync<T>(string url)
        {
            return await _httpClient.GetFromJsonAsync<T>(url);
        }

        // Add other methods for POST, PUT, DELETE as needed

        public async Task<HttpResponseMessage> PostAsJsonAsync<T>(string url, T data)
        {
            return await _httpClient.PostAsJsonAsync(url, data);
        }

        public async Task<HttpResponseMessage> PutAsJsonAsync<T>(string url, T data)
        {
            return await _httpClient.PutAsJsonAsync(url, data);
        }

        public async Task<HttpResponseMessage> DeleteAsync(string url)
        {
            return await _httpClient.DeleteAsync(url);
        }

        public async Task<HttpResponseMessage> PutAsync(string url, HttpContent content)
        {
            return await _httpClient.PutAsync(url, content);
        }

        public async Task<HttpResponseMessage> PostAsync(string url, HttpContent content)
        {
            return await _httpClient.PostAsync(url, content);
        }

        public async Task<List<Product>> UpdatePrice(List<Product> products)
        {
            List<Gem> gems = await GetAsync<List<Gem>>("http://localhost:5071/api/gem");
            List<Gold> golds = await GetAsync<List<Gold>>("http://localhost:5071/api/gold");
            List<Product> results = products;
            foreach (Product product in results)
            {
                double gemPrice = 0;
                double goldPrice = 0;
                double unitPrice = 0;
                Gem gem = gems.Find(x => x.GemId == product.GemId);
                Gold gold = golds.Find(x => x.GoldId == product.GoldId);
                if (gem != null)
                {
                    gemPrice = gem.GemPrice * product.GemWeight;
                    unitPrice += gemPrice;
                }
                if (gold != null)
                {
                    goldPrice = gold.GoldPrice * product.GoldWeight;
                    unitPrice += goldPrice;
                }
                unitPrice += product.LaborCost;
                unitPrice = unitPrice * product.MarkupRate;
                product.UnitPrice = unitPrice;
                product.TotalPrice = unitPrice * product.ProductQuantity;
            }
            return results;
        }
        /*

                 // Discount-specific methods for convenience
                 public async Task<List<Discount>> GetDiscountsAsync()
                 {
                     return await GetAsync<List<Discount>>("http://localhost:5156/api/discount");
                 }

                 public async Task<Discount> GetDiscountByIdAsync(string discountId)
                 {
                     return await GetAsync<Discount>($"http://localhost:5156/api/discount/{discountId}");
                 }

                 public async Task<HttpResponseMessage> CreateDiscountAsync(Discount discount)
                 {
                     return await PostAsJsonAsync("http://localhost:5156/api/discount", discount);
                 }

                 public async Task<HttpResponseMessage> UpdateDiscountAsync(Discount discount)
                 {
                     var url = "http://localhost:5156/api/discount";
                     var json = JsonConvert.SerializeObject(discount, new JsonSerializerSettings
                     {
                         DateFormatString = "yyyy-MM-ddTHH:mm:ss.fffZ"
                     });

                     var content = new StringContent(json, Encoding.UTF8, "application/json");
                     return await _httpClient.PutAsync(url, content);
                 }

                 public async Task<HttpResponseMessage> DeleteDiscountAsync(string discountId)
                 {
                     return await DeleteAsync($"http://localhost:5156/api/discount/{discountId}");
                 }

                 // New login method
                 public async Task<HttpResponseMessage> Login(Login Input)
                 {
                     var loginJson = JsonConvert.SerializeObject(Input);
                     var content = new StringContent(loginJson, Encoding.UTF8, "application/json");

                     return await _httpClient.PostAsync("http://localhost:5156/api/auth/login", content);
                 }
         */
    }
}
