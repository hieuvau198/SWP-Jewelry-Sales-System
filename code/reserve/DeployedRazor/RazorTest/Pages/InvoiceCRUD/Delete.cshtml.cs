using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using System.Threading.Tasks;

namespace RazorTest.Pages.InvoiceCRUD
{
    public class DeleteModel : PageModel
    {
        private readonly InvoiceService _invoiceService;

        public DeleteModel(InvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [BindProperty]
        public Invoice Invoice { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
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
                return RedirectToPage("/InvoiceCRUD/InvoiceDetail");
            }

            ModelState.AddModelError(string.Empty, "An error occurred while deleting the invoice.");
            return Page();
        }
    }
}
