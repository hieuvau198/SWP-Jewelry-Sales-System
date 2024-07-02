using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;
using System.Threading.Tasks;

namespace RazorTest.Pages.pinvoice
{
    public class CreateModel : PageModel
    {
        public const string SessionKeyAuthState = "_AuthState";
        public const string SessionKeyUserObject = "_UserObject";

        private readonly InvoiceService _invoiceService;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(InvoiceService invoiceService, ILogger<CreateModel> logger)
        {
            _invoiceService = invoiceService;
            _logger = logger;
        }

        [BindProperty]
        public Invoice Invoice { get; set; }

        public void OnGet()
        {
            // Initialize the Invoice with a new ID
            Invoice = new Invoice
            {
                InvoiceId = Guid.NewGuid().ToString()
            };
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

            // Check if InvoiceID is still empty and generate it
            if (string.IsNullOrEmpty(Invoice.InvoiceId))
            {
                Invoice.InvoiceId = Guid.NewGuid().ToString();
            }
            var response = await _invoiceService.CreateInvoiceAsync(Invoice);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/pinvoice/InvoiceDetail");
            }

            ModelState.AddModelError(string.Empty, "An error occurred while creating the invoice.");
            _logger.LogError($"Failed to create invoice. Status Code: {response.StatusCode}");
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
