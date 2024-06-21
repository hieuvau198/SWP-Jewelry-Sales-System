using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using RazorTest.Models;
using System.Text.Json;

namespace RazorTest.Services
{
    public class CustomerService
    {
        private readonly ApiService _apiService;

        public CustomerService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _apiService.GetAsync<List<Customer>>("http://localhost:5071/api/customer");
        }

        public async Task<Customer> GetCustomerByIdAsync(string customerId)
        {
            return await _apiService.GetAsync<Customer>($"http://localhost:5071/api/customer/{customerId}");
        }

        public async Task<HttpResponseMessage> CreateCustomerAsync(Customer customer)
        {
            return await _apiService.PostAsJsonAsync("http://localhost:5071/api/customer", customer);
        }

        public async Task<HttpResponseMessage> UpdateCustomerAsync(Customer customer)
        {
            var url = "http://localhost:5071/api/customer";
            var json = JsonConvert.SerializeObject(customer, new JsonSerializerSettings
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

        public async Task<HttpResponseMessage> DeleteCustomerAsync(string customerId)
        {
            return await _apiService.DeleteAsync($"http://localhost:5071/api/customer/{customerId}");
        }

    }
}
