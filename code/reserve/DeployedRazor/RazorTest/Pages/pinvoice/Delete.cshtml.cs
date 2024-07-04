using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;
using System.Threading.Tasks;

namespace RazorTest.Pages.pinvoice
{
    public class DeleteModel : PageModel
    {
        public const string SessionKeyAuthState = "_AuthState";
        public const string SessionKeyUserObject = "_UserObject";

        private readonly InvoiceService _invoiceService;
        private readonly ApiService _apiService;

        public DeleteModel(InvoiceService invoiceService, ApiService apiService)
        {
            _invoiceService = invoiceService;
            _apiService = apiService;
        }

        [BindProperty]
        public Invoice Invoice { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            // Verify auth
            List<string> roles = new List<string>
            {
                "Manager",
                "Cashier",
                "Admin"
            };
            if (!_apiService.VerifyAuth(HttpContext, roles))
            {
                return RedirectToPage("/Authentication/AccessDenied");
            }

            Invoice = await _invoiceService.GetInvoiceByIdAsync(id);
            if (Invoice == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var response = await _invoiceService.DeleteInvoiceAsync(Invoice.InvoiceId);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/pinvoice/InvoiceDetail");
            }

            ModelState.AddModelError(string.Empty, "An error occurred while deleting the invoice.");
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
