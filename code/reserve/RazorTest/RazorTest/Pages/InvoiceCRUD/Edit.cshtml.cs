using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RazorTest.Models;
using RazorTest.Services;
using System.Threading.Tasks;

namespace RazorTest.Pages.InvoiceCRUD
{
    public class EditModel : PageModel
    {
        private readonly InvoiceService _invoiceService;
        private readonly ILogger<EditModel> _logger;
        public EditModel(InvoiceService apiService, ILogger<EditModel> logger, InvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
            _logger = logger;
        }

        [BindProperty]
        public Invoice Invoice { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                _logger.LogError("ID is null");
                return NotFound();
            }

            Invoice = await _invoiceService.GetInvoiceByIdAsync(id);

            if (Invoice == null)
            {
                _logger.LogError($"Invoice not found for ID {id}");
                return NotFound();
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
            Invoice.InvoiceStatus = "Confirmed By Manager";
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
    }
}
