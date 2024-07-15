using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;

namespace RazorTest.Pages.pinvoice
{
    public class PrintModel : PageModel
    {
        public const string SessionKeyAuthState = "_AuthState";
        public const string SessionKeyUserObject = "_UserObject";

        public const string SessionKeyCustomerObject = "_CustomerObject";
        public const string SessionKeyInvoiceList = "_InvoiceList";
        public const string SessionKeyInvoiceItemList = "_InvoiceItemList";
        public const string SessionKeyViewDetailInvoiceObject = "_InvoiceViewDetail";

        public const string UrlInvoice = "http://localhost:5071/api/invoice";
        public const string UrlInvoiceItem = "http://localhost:5071/api/invoiceitem";

        private readonly ApiService _apiService;

        public PrintModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public User User { get; set; }

        public Invoice ViewDetailInvoiceObject { get; set; }

        public List<InvoiceItem> ViewDetailInvoiceItemList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                // Verify auth
                List<string> roles = new List<string>
                {
                    "Manager",
                    "Cashier",
                    "Sale",
                    "Admin"
                };
                if (!_apiService.VerifyAuth(HttpContext, roles))
                {
                    return RedirectToPage("/Authentication/AccessDenied");
                }

                // Process data
                User = HttpContext.Session.GetObject<User>(SessionKeyUserObject);

                ViewDetailInvoiceObject = HttpContext.Session.GetObject<Invoice>(SessionKeyViewDetailInvoiceObject);
                if (ViewDetailInvoiceObject != null)
                {
                    List<InvoiceItem> invoiceItems = HttpContext.Session.GetObject<List<InvoiceItem>>(SessionKeyInvoiceItemList)
                        ?? await _apiService.GetAsync<List<InvoiceItem>>(UrlInvoiceItem) ?? new List<InvoiceItem>();
                    ViewDetailInvoiceItemList = invoiceItems.Where(
                        x => (x.InvoiceId.Equals(ViewDetailInvoiceObject.InvoiceId))
                        ).ToList();
                }
                else
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
    }
}
