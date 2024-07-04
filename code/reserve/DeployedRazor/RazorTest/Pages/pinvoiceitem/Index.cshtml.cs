using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Pages.pinvoiceitem
{
    public class IndexModel : PageModel
    {
        private readonly ApiService _apiService;

        public IndexModel(ApiService apiService)
        {
            _apiService = apiService;
        }

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

            var invoiceitems = await _apiService.GetAsync<List<InvoiceItem>>("https://hvjewel.azurewebsites.net/api/invoiceitem");

            if (invoiceitems != null)
            {
                Invoiceitems = invoiceitems.OrderBy(t => t.InvoiceItemId).ToList();
            }

            return Page();
        }
    }
}
