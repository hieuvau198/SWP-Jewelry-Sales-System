using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using RazorTest.Models;
using System.Text.Json;
using JewelBO;

namespace RazorTest.Services
{
    public class ProductService
    {
        private readonly ApiService _apiService;

        public ProductService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _apiService.GetAsync<List<Product>>("http://localhost:5156/api/product");
        }

        public async Task<Product> GetProductByIdAsync(string productId)
        {
            return await _apiService.GetAsync<Product>($"http://localhost:5156/api/product/{productId}");
        }

        public async Task<HttpResponseMessage> CreateProductAsync(Product product)
        {
            return await _apiService.PostAsJsonAsync("http://localhost:5156/api/product", product);
        }

        public async Task<HttpResponseMessage> UpdateProductAsync(Product product)
        {
            var url = "http://localhost:5156/api/product";
            var json = JsonConvert.SerializeObject(product, new JsonSerializerSettings
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

        public async Task<HttpResponseMessage> DeleteProductAsync(string productId)
        {
            return await _apiService.DeleteAsync($"http://localhost:5156/api/product/{productId}");
        }

    }
}
