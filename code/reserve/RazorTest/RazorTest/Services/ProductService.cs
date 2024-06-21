using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using RazorTest.Models;

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
            List <Product> results = await _apiService.GetAsync<List<Product>>("http://localhost:5071/api/product");
            return results;
        }

        public async Task<Product> GetProductByIdAsync(string productId)
        {
            return await _apiService.GetAsync<Product>($"http://localhost:5071/api/product/{productId}");
        }

        public async Task<HttpResponseMessage> CreateProductAsync(Product product)
        {
           
            var json = JsonConvert.SerializeObject(product, new JsonSerializerSettings
            {
                DateFormatString = "yyyy-MM-ddTHH:mm:ss.fffZ"
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _apiService.PostAsync("http://localhost:5071/api/product", content);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorContent}");
            }

            return response;
        }

        public async Task<HttpResponseMessage> UpdateProductAsync(Product product)
        {

            var json = JsonConvert.SerializeObject(product, new JsonSerializerSettings
            {
                DateFormatString = "yyyy-MM-ddTHH:mm:ss.fffZ"
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _apiService.PutAsync("http://localhost:5071/api/product", content);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorContent}");
            }
            return response;
        }

        public async Task<HttpResponseMessage> DeleteProductAsync(string productId)
        {
            var response = await _apiService.DeleteAsync($"http://localhost:5071/api/product/{productId}");

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorContent}");
            }
            return response;
        }
    }
}
