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
        public async Task<T> PostAsJsonAndDeserializeAsync<T>(string url, T data)
        {
            var response = await _httpClient.PostAsJsonAsync(url, data);

            // Ensure the response is successful
            //response.EnsureSuccessStatusCode();

            // Deserialize the response content to the specified type
            var result = await response.Content.ReadFromJsonAsync<T>();
            return result;
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
        
    }
}
