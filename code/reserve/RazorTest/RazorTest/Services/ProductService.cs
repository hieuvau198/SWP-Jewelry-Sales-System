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
            List<Gem> gems = await _apiService.GetAsync<List<Gem>>("http://localhost:5071/api/gem");
            List<Gold> golds = await _apiService.GetAsync<List<Gold>>("http://localhost:5071/api/gold");
            List <Product> results = await _apiService.GetAsync<List<Product>>("http://localhost:5071/api/product");
            foreach (Product product in results)
            {
                double gemPrice = 0;
                double goldPrice = 0;
                double unitPrice = 0;
                Gem gem = gems.Find(x => x.GemId == product.GemId);
                Gold gold = golds.Find(x => x.GoldId == product.GoldId);
                if(gem != null)
                { 
                    gemPrice = gem.GemPrice; 
                    unitPrice += gemPrice;
                }
                if(gold != null)
                { 
                    goldPrice = gold.GoldPrice; 
                    unitPrice += goldPrice;
                }
                unitPrice += product.LaborCost;
                unitPrice = unitPrice * product.MarkupRate;
                product.UnitPrice = unitPrice;
            }
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
