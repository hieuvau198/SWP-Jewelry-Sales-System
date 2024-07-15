using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;

namespace RazorTest.Pages.pinvoice
{
    public class ViewDetailModel : PageModel
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

        public ViewDetailModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public User User { get; set; }

        public Invoice ViewDetailInvoiceObject {  get; set; }

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

        // Confim stage 2 - Manager Approve
        public async Task<IActionResult> OnPostApprove(string invoiceId)
        {
            // Verify auth
            List<string> roles = new List<string>
                {
                    "Manager",
                    "Admin"
                };
            if (!_apiService.VerifyAuth(HttpContext, roles))
            {
                return RedirectToPage("/Authentication/AccessDenied");
            }

            // Process data

            User = HttpContext.Session.GetObject<User>(SessionKeyUserObject);

            List<Invoice> invoices = await _apiService.GetAsync<List<Invoice>>(UrlInvoice);
            if(invoices.IsNullOrEmpty())
            {
                return RedirectToPage("/Error");
            }
            Invoice invoice = invoices.Find(x => x.InvoiceId == invoiceId);
            if (invoice == null)
            {
                return RedirectToPage("/Error");
            }
            invoice.InvoiceStatus = "Processing Payment";
            invoice.ManagerId = User.UserId;
            invoice.ManagerFullname = User.Fullname;

            if(User.Role.Equals("Admin"))
            {
                invoice.ManagerFullname = $"Admin - {User.Fullname}";
            }

            var response = await _apiService.PutAsJsonAsync(UrlInvoice, invoice);
            if (!response.IsSuccessStatusCode)
            {
                return RedirectToPage("/Error");
            }

            return RedirectToPage("/pinvoice/InvoiceDetail");
        }

        // Confim stage 2 - Manager Disapprove
        public async Task<IActionResult> OnPostDisapprove(string invoiceId)
        {
            // Verify auth
            List<string> roles = new List<string>
                {
                    "Manager",
                    "Admin"
                };
            if (!_apiService.VerifyAuth(HttpContext, roles))
            {
                return RedirectToPage("/Authentication/AccessDenied");
            }

            // Process data

            User = HttpContext.Session.GetObject<User>(SessionKeyUserObject);

            List<Invoice> invoices = await _apiService.GetAsync<List<Invoice>>(UrlInvoice);
            if (invoices.IsNullOrEmpty())
            {
                return RedirectToPage("/Error");
            }
            Invoice invoice = invoices.Find(x => x.InvoiceId == invoiceId);
            if (invoice == null)
            {
                return RedirectToPage("/Error");
            }
            invoice.InvoiceStatus = "Manager Disapproved";
            invoice.ManagerId = User.UserId;
            invoice.ManagerFullname = User.Fullname;

            if (User.Role.Equals("Admin"))
            {
                invoice.InvoiceStatus = "Admin Disapproved";
                invoice.ManagerFullname = $"Admin - {User.Fullname}";
            }

            var response = await _apiService.PutAsJsonAsync(UrlInvoice, invoice);
            if (!response.IsSuccessStatusCode)
            {
                return RedirectToPage("/Error");
            }

            return RedirectToPage("/pinvoice/InvoiceDetail");
        }

        // Confim stage 3 - Cashier Confirm Payment
        public async Task<IActionResult> OnPostConfirmPayment(string invoiceId)
        {
            // Verify auth
            List<string> roles = new List<string>
                {
                    "Cashier",
                    "Admin"
                };
            if (!_apiService.VerifyAuth(HttpContext, roles))
            {
                return RedirectToPage("/Authentication/AccessDenied");
            }

            // Process data

            User = HttpContext.Session.GetObject<User>(SessionKeyUserObject);

            List<Invoice> invoices = await _apiService.GetAsync<List<Invoice>>(UrlInvoice);
            if (invoices.IsNullOrEmpty())
            {
                return RedirectToPage("/Error");
            }

            Invoice invoice = invoices.Find(x => x.InvoiceId == invoiceId);
            if (invoice == null)
            {
                return RedirectToPage("/Error");
            }
            invoice.InvoiceStatus = "Complete";
            invoice.CashierId = User.UserId;
            invoice.CashierFullname = User.Fullname;

            if(User.Role.Equals("Admin"))
            {
                invoice.CashierFullname = $"Admin - {User.Fullname}";
            }

            var response = await _apiService.PutAsJsonAsync(UrlInvoice, invoice);
            if (!response.IsSuccessStatusCode)
            {
                return RedirectToPage("/Error");
            }

            return RedirectToPage("/pinvoice/InvoiceDetail");
        }

        // Confim stage 3 - Cashier Cancel Order
        public async Task<IActionResult> OnPostCancelOrder(string invoiceId)
        {
            // Verify auth
            List<string> roles = new List<string>
                {
                    "Cashier",
                    "Admin"
                };
            if (!_apiService.VerifyAuth(HttpContext, roles))
            {
                return RedirectToPage("/Authentication/AccessDenied");
            }

            // Process data

            User = HttpContext.Session.GetObject<User>(SessionKeyUserObject);

            List<Invoice> invoices = await _apiService.GetAsync<List<Invoice>>(UrlInvoice);
            if (invoices.IsNullOrEmpty())
            {
                return RedirectToPage("/Error");
            }
            Invoice invoice = invoices.Find(x => x.InvoiceId == invoiceId);
            if (invoice == null)
            {
                return RedirectToPage("/Error");
            }
            invoice.InvoiceStatus = "Canceled";
            invoice.CashierId = User.UserId;
            invoice.CashierFullname = User.Fullname;

            if (User.Role.Equals("Admin"))
            {
                invoice.InvoiceStatus = "Admin Canceled";
                invoice.CashierFullname = $"Admin - {User.Fullname}";
            }

            var response = await _apiService.PutAsJsonAsync(UrlInvoice, invoice);
            if (!response.IsSuccessStatusCode)
            {
                return RedirectToPage("/Error");
            }

            return RedirectToPage("/pinvoice/InvoiceDetail");
        }

        // Print Invoice
        public async Task<IActionResult> OnPostPrintInvoice(string invoiceId)
        {
            if(invoiceId == null)
            {
                return RedirectToPage("/Error");
            }
            return RedirectToPage("/pinvoice/Print");
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
