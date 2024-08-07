﻿using System.Collections.Generic;
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
            return await _apiService.GetAsync<List<Invoice>>("http://localhost:5071/api/invoice");
        }

        public async Task<Invoice> GetInvoiceByIdAsync(string invoiceId)
        {
            return await _apiService.GetAsync<Invoice>($"http://localhost:5071/api/invoice/{invoiceId}");
        }

        public async Task<HttpResponseMessage> CreateInvoiceAsync(Invoice invoice)
        {
            return await _apiService.PostAsJsonAsync("http://localhost:5071/api/invoice", invoice);
        }

        public async Task<HttpResponseMessage> UpdateInvoiceAsync(Invoice invoice)
        {
            var url = "http://localhost:5071/api/invoice";
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
            return await _apiService.DeleteAsync($"http://localhost:5071/api/invoice?invoiceId={invoiceId}");
        }

    }
}
