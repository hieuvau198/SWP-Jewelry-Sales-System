using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Pages.pinvoiceitem
{
    public class InvoiceItemListModel : PageModel
    {
        public const string SessionKeyUserObject = "_UserObject";
        public const string SessionKeyAuthState = "_AuthState";
        private readonly ApiService _apiService;

        public InvoiceItemListModel(ApiService apiService)
        {
            _apiService = apiService;
        }
        public User User { get; set; }

        public List<InvoiceItem> Invoiceitems { get; set; }

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
            var invoiceitems = await _apiService.GetAsync<List<InvoiceItem>>("https://hvjewel.azurewebsites.net/api/invoiceitem");

            if (invoiceitems != null)
            {
                Invoiceitems = invoiceitems.OrderBy(t => t.InvoiceItemId).ToList();
            }

            return Page();
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
