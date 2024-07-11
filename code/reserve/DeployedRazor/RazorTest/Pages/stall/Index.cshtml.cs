using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;

namespace RazorTest.Pages.stall
{
    public class IndexModel : PageModel
    {
        public const string SessionKeyAuthState = "_AuthState";
        public const string SessionKeyUserObject = "_UserObject";
        public const string SessionKeyStallObject = "_StallObject";

        public const string UrlStall = "https://hvjewel.azurewebsites.net/api/stall";
        public const string UrlStallEmployee = "https://hvjewel.azurewebsites.net/api/stallemployee";
        public const string UrlStallItem = "https://hvjewel.azurewebsites.net/api/stallitem";

        private readonly ApiService _apiService;
        public IndexModel(ApiService apiService)
        {
            _apiService = apiService;
        }
        public User User { get; set; }
        public List<Stall> Stalls { get; set; }
        public async Task<IActionResult> OnGet()
        {
            try 
            {
                // Verify Auth
                List<string> roles = new List<string>{"Admin", "Manager"};
                if (!_apiService.VerifyAuth(HttpContext, roles))
                {
                    return RedirectToPage("/Authentication/Accessdenied");
                }

                // Process data
                User = HttpContext.Session.GetObject<User>(SessionKeyUserObject);
                Stalls = await _apiService.GetAsync<List<Stall>>(UrlStall);
                if (Stalls.IsNullOrEmpty())
                {
                    return RedirectToPage("/NotFound");
                }
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error");
            }
            return Page();
        }
        public async Task<IActionResult> OnPostViewDetail(string stallId)
        {
            if(stallId.IsNullOrEmpty())
            {
                return RedirectToPage("/Error");
            }
            Stalls = await _apiService.GetAsync<List<Stall>>(UrlStall);
            if (Stalls.IsNullOrEmpty())
            {
                return RedirectToPage("/Error");
            }
            Stall stall = Stalls.Find(x => x.StallId == stallId);
            if(stall == null)
            {
                return RedirectToPage("/NotFound");
            }
            HttpContext.Session.SetObject(SessionKeyStallObject, stall);

            return RedirectToPage("/stall/detail");
        }
    }
}
