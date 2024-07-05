using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Pages.puser
{
    public class IndexModel : PageModel
    {
        public const string SessionKeyUserObject = "_UserObject";
        
        private readonly ApiService _apiService;

        public  IndexModel(ApiService apiService)
        {
            _apiService = apiService;
        }
        public User User { get; set; }

        public List<User> Users { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Verify auth
            List<string> roles = new List<string>
            {
                "Admin"
            };
            if (!_apiService.VerifyAuth(HttpContext, roles))
            {
                return RedirectToPage("/Authentication/AccessDenied");
            }

            // Process data
            User = HttpContext.Session.GetObject<User>(SessionKeyUserObject);

            var users = await _apiService.GetAsync<List<User>>("https://hvjewel.azurewebsites.net/api/user");

            if (users != null)
            {
                Users = users.OrderBy(u => u.UserId).ToList();
            }

            return Page();
        }
    }
}
