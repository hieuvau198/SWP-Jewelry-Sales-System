using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;
using System.Threading.Tasks;

namespace RazorTest.Pages.pinvoiceitem
{
    public class DeleteModel : PageModel
    {
        public const string SessionKeyUserObject = "_UserObject";
        public const string SessionKeyAuthState = "_AuthState";
        private readonly InvoiceItemService _invoiceItemService;
        private readonly ApiService _apiService;

        public DeleteModel(InvoiceItemService invoiceItemService, ApiService apiService)
        {
            _invoiceItemService = invoiceItemService;
            _apiService = apiService;
        }
        public User User { get; set; }

        [BindProperty]
        public InvoiceItem InvoiceItem { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
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

            InvoiceItem = await _invoiceItemService.GetInvoiceItemByIdAsync(id);
            if (InvoiceItem == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var response = await _invoiceItemService.DeleteInvoiceItemAsync(InvoiceItem.InvoiceItemId);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/pinvoiceitem/InvoiceItemDetail");
            }

            ModelState.AddModelError(string.Empty, "An error occurred while deleting the invoice item.");
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