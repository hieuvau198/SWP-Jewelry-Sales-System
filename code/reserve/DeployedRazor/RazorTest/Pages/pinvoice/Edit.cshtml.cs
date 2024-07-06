using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;
using System.Threading.Tasks;

namespace RazorTest.Pages.pinvoice
{
    public class EditModel : PageModel
    {
        public const string SessionKeyUserObject = "_UserObject";
        public const string SessionKeyAuthState = "_AuthState";

        private readonly InvoiceService _invoiceService;
        private readonly ApiService _apiService;
        private readonly ILogger<EditModel> _logger;
        public EditModel(ApiService apiService, ILogger<EditModel> logger, InvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
            _apiService = apiService;
            _logger = logger;
        }
        public User User { get; set; }

        [BindProperty]
        public Invoice Invoice { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            try
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
                // Process data
                User = HttpContext.Session.GetObject<User>(SessionKeyUserObject);

                if (id == null)
                {
                    return RedirectToPage("/NotFound");
                }

                Invoice = await _invoiceService.GetInvoiceByIdAsync(id);

                if (Invoice == null)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                foreach (var modelStateKey in ModelState.Keys)
                {
                    var modelStateVal = ModelState[modelStateKey];
                    foreach (var error in modelStateVal.Errors)
                    {
                        _logger.LogError($"Key: {modelStateKey}, Error: {error.ErrorMessage}");
                    }
                }

                return Page();
            }

            _logger.LogInformation($"Updating invoice with ID {Invoice.InvoiceId}");
            _logger.LogInformation($"Invoice details: {JsonConvert.SerializeObject(Invoice)}");
            if(HttpContext.Session.GetObject<bool>(SessionKeyAuthState))
            {
                User user = HttpContext.Session.GetObject<User>(SessionKeyUserObject);
                if (user != null && user.Role.Equals("Manager"))
                {
                    Invoice.InvoiceStatus = "Processing Payment";
                    Invoice.ManagerId = user.UserId;
                    Invoice.ManagerFullname = user.Fullname;
                }
                else if(user != null && user.Role.Equals("Cashier"))
                {
                    Invoice.InvoiceStatus = "Complete";
                    Invoice.CashierId = user.UserId;
                    Invoice.CashierFullname = user.Fullname;
                }
            }
            
            var response = await _invoiceService.UpdateInvoiceAsync(Invoice);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"Failed to update invoice. Status Code: {response.StatusCode}");
                ModelState.AddModelError(string.Empty, "An error occurred while updating the invoice.");
                return Page();
            }

            _logger.LogInformation("Successfully updated invoice");
            return RedirectToPage("./InvoiceDetail");
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
