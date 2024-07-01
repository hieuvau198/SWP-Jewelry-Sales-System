using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using RazorTest.Models;
using System.Text.Json;
using RazorTest.Utilities;

namespace RazorTest.Services
{
    public class UserService
    {
        
        private readonly ApiService _apiService;

        public UserService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _apiService.GetAsync<List<User>>("https://jewelsystembe20240701213216.azurewebsites.net/api/user");
        }

        public async Task<User> GetUserByIdAsync(string userId)
        {
            return await _apiService.GetAsync<User>($"https://jewelsystembe20240701213216.azurewebsites.net/api/user/{userId}");
        }

        public async Task<HttpResponseMessage> CreateUserAsync(User user)
        {
            return await _apiService.PostAsJsonAsync("https://jewelsystembe20240701213216.azurewebsites.net/api/user", user);
        }

        public async Task<HttpResponseMessage> UpdateUserAsync(User user)
        {
            var url = "https://jewelsystembe20240701213216.azurewebsites.net/api/user";
            var json = JsonConvert.SerializeObject(user, new JsonSerializerSettings
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

        public async Task<HttpResponseMessage> DeleteUserAsync(string userId)
        {
            return await _apiService.DeleteAsync($"https://jewelsystembe20240701213216.azurewebsites.net/api/user/{userId}");
        }
        
    }
}
