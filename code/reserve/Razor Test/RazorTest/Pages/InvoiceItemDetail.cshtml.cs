using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Pages
{
    public class InvoiceItemListModel : PageModel
    {
        private readonly ApiService _apiService;

        public InvoiceItemListModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public List<InvoiceItem> Invoiceitems { get; set; }

        public async Task OnGetAsync()
        {
            var invoiceitems = await _apiService.GetAsync<List<InvoiceItem>>("http://localhost:5071/api/invoiceitem");

            if (invoiceitems != null)
            {
                Invoiceitems = invoiceitems.OrderBy(t => t.InvoiceItemId).ToList();
            }
        }
    }
}
