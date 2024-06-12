using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Pages
{
    public class InvoiceListModel : PageModel
    {
        private readonly ApiService _apiService;

        public InvoiceListModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public List<Invoice> Invoices { get; set; }

        public async Task OnGetAsync()
        {
            var invoices = await _apiService.GetAsync<List<Invoice>>("http://localhost:5071/api/invoice");

            if (invoices != null)
            {
                Invoices = invoices.OrderBy(c => c.InvoiceId).ToList();
            }
        }
    }
}
