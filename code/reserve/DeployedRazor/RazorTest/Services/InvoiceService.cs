using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using RazorTest.Models;
using System.Text.Json;

namespace RazorTest.Services
{
    public class InvoiceService
    {
        private readonly ApiService _apiService;

        public InvoiceService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<List<Invoice>> GetInvoicesAsync()
        {
            return await _apiService.GetAsync<List<Invoice>>("https://jewelsystembe20240701213216.azurewebsites.net/api/invoice");
        }

        public async Task<Invoice> GetInvoiceByIdAsync(string invoiceId)
        {
            return await _apiService.GetAsync<Invoice>($"https://jewelsystembe20240701213216.azurewebsites.net/api/invoice/{invoiceId}");
        }

        public async Task<HttpResponseMessage> CreateInvoiceAsync(Invoice invoice)
        {
            return await _apiService.PostAsJsonAsync("https://jewelsystembe20240701213216.azurewebsites.net/api/invoice", invoice);
        }

        public async Task<HttpResponseMessage> UpdateInvoiceAsync(Invoice invoice)
        {
            var url = "https://jewelsystembe20240701213216.azurewebsites.net/api/invoice";
            var json = JsonConvert.SerializeObject(invoice, new JsonSerializerSettings
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

        public async Task<HttpResponseMessage> DeleteInvoiceAsync(string invoiceId)
        {
            return await _apiService.DeleteAsync($"https://jewelsystembe20240701213216.azurewebsites.net/api/invoice?invoiceId={invoiceId}");
        }

    }
}
