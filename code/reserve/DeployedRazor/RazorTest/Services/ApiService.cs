using System.Text.Json;
using System.Text;
using RazorTest.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using RazorTest.Utilities;

namespace RazorTest.Services
{
    public class ApiService
    {
        // Session key
            private const string SessionKeyUserObject = "_UserObject";
            private const string SessionKeyAuthState = "_AuthState";

        private readonly HttpClient _httpClient;
        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public bool VerifyAuth(HttpContext httpContext, string role)
        {
            bool result = false;
            bool isAuthenticated = httpContext.Session.GetObject<bool>(SessionKeyAuthState);
            User user = httpContext.Session.GetObject<User>(SessionKeyUserObject);

            if (isAuthenticated && user != null && user.Role != null && user.Role == role)
            {
                result = true;
            }

            return result;
        }

        public bool VerifyAuth(HttpContext httpContext, List<string> roles)
        {
            bool result = false;
            bool isAuthenticated = httpContext.Session.GetObject<bool>(SessionKeyAuthState);
            User user = httpContext.Session.GetObject<User>(SessionKeyUserObject);

            foreach (string role in roles)
            {
                if (isAuthenticated && user != null && user.Role != null && user.Role == role)
                {
                    result = true;
                }
            }
            
            return result;
        }
        

        public async Task<T> GetAsync<T>(string url)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<T>(url);
            }
            catch (HttpRequestException httpRequestException)
            {
                // Log the exception (optional)
                Console.WriteLine($"Request error: {httpRequestException.Message}");

                // Return a default value or handle the exception as needed
                return default(T);
            }
            catch (NotSupportedException notSupportedException)
            {
                // Log the exception (optional)
                Console.WriteLine($"The content type is not supported: {notSupportedException.Message}");

                // Return a default value or handle the exception as needed
                return default(T);
            }
            catch (System.Text.Json.JsonException jsonException)
            {
                // Log the exception (optional)
                Console.WriteLine($"Invalid JSON: {jsonException.Message}");

                // Return a default value or handle the exception as needed
                return default(T);
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                Console.WriteLine($"Unexpected error: {ex.Message}");

                // Return a default value or handle the exception as needed
                return default(T);
            }
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
