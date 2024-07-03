using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Pages
{
    public class GoldModel : PageModel
    {
        public const string SessionKeyAuthState = "_AuthState";
        public const string SessionKeyUserObject = "_UserObject";

        private readonly ApiService _apiService;

        public GoldModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public List<Gold> Golds { get; set; }

        public async Task OnGetAsync()
        {
            var golds = await _apiService.GetAsync<List<Gold>>("http://localhost:5071/api/gold");

            if (golds != null)
            {
                Golds = golds.OrderBy(b => b.GoldId).ToList();
            }
        }

        public bool VerifyAuth(string role)
        {
            bool result = false;
            bool isAuthenticated = HttpContext.Session.GetObject<bool>(SessionKeyAuthState);
            User user = HttpContext.Session.GetObject<User>(SessionKeyUserObject);
            if (isAuthenticated && user != null)
            {
                if (user.Role == role)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
