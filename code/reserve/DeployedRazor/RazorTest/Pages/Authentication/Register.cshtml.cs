using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using RazorTest.Models;
using RazorTest.Services;

namespace RazorTest.Pages.Authentication
{
    public class RegisterModel : PageModel
    {

        private readonly ApiService _apiService;

        public const string UrlUser = "https://hvjewel.azurewebsites.net/api/user";
        

        public RegisterModel(ApiService apiService)
        {
            _apiService = apiService;
        }




        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostRegister(string username, string password, string email, string fullname)
        {
            List<User> users = await _apiService.GetAsync<List<User>>(UrlUser);
            if(!users.IsNullOrEmpty())
            {
                User user = users.Find(x => x.Username == username) ?? users.Find(x => x.Email == email);
                if(user != null)
                {
                    return Page();
                }
            }
            User registerUser = new User
            {
                UserId = username,
                Username = username,
                Password = password,
                Email = email,
                Role = "Unconfirmed",
                Fullname = fullname
            };
            _apiService.PostAsJsonAsync<User>(UrlUser, registerUser);

            return RedirectToPage("/Authentication/RegisterSuccess");
        }
    }
}
