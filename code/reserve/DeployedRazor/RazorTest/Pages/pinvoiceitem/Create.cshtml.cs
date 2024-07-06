using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;
using System.Threading.Tasks;

namespace RazorTest.Pages.pinvoiceitem
{
    public class CreateModel : PageModel
    {
        public const string SessionKeyUserObject = "_UserObject";
        public const string SessionKeyAuthState = "_AuthState";
        private readonly InvoiceItemService _invoiceItemService;
        private readonly ApiService _apiService;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(InvoiceItemService invoiceItemService, ILogger<CreateModel> logger, ApiService apiService)
        {
            _invoiceItemService = invoiceItemService;
            _logger = logger;
            _apiService = apiService;
        }
        public User User { get; set; }

        [BindProperty]
        public InvoiceItem InvoiceItem { get; set; }

        public IActionResult OnGet()
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
            // Initialize the InvoiceItem with a new ID
            InvoiceItem = new InvoiceItem
            {
                InvoiceItemId = Guid.NewGuid().ToString()
            };

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

            // Check if InvoiceID is still empty and generate it
            if (string.IsNullOrEmpty(InvoiceItem.InvoiceItemId))
            {
                InvoiceItem.InvoiceItemId = Guid.NewGuid().ToString();
            }

            var response = await _invoiceItemService.CreateInvoiceItemAsync(InvoiceItem);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/pinvoiceitem/InvoiceItemDetail");
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