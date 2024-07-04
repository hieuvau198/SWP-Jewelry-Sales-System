using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using RazorTest.Models;
using System.Text.Json;

namespace RazorTest.Services
{
    public class InvoiceItemService
    {
        private readonly ApiService _apiService;

        public InvoiceItemService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<List<InvoiceItem>> GetInvoiceItemsAsync()
        {
            return await _apiService.GetAsync<List<InvoiceItem>>("https://hvjewel.azurewebsites.net/api/invoiceitem");
        }

        public async Task<InvoiceItem> GetInvoiceItemByIdAsync(string invoiceItemId)
        {
            return await _apiService.GetAsync<InvoiceItem>($"https://hvjewel.azurewebsites.net/api/invoiceitem/{invoiceItemId}");
        }

        public async Task<HttpResponseMessage> CreateInvoiceItemAsync(InvoiceItem invoiceItem)
        {
            return await _apiService.PostAsJsonAsync("https://hvjewel.azurewebsites.net/api/invoiceitem", invoiceItem);
        }

        public async Task<HttpResponseMessage> UpdateInvoiceItemAsync(InvoiceItem invoiceItem)
        {
            var url = "https://hvjewel.azurewebsites.net/api/invoiceitem";
            var json = JsonConvert.SerializeObject(invoiceItem, new JsonSerializerSettings
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

        public async Task<HttpResponseMessage> DeleteInvoiceItemAsync(string invoiceItemId)
        {
            return await _apiService.DeleteAsync($"https://hvjewel.azurewebsites.net/api/invoiceitem?invoiceItemId={invoiceItemId}");
        }

    }
}
