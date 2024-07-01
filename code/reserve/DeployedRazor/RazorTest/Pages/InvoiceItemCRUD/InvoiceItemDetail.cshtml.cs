using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Pages.InvoiceItemCRUD
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
            var invoiceitems = await _apiService.GetAsync<List<InvoiceItem>>("https://jewelsystembe20240701213216.azurewebsites.net/api/invoiceitem");

            if (invoiceitems != null)
            {
                Invoiceitems = invoiceitems.OrderBy(t => t.InvoiceItemId).ToList();
            }
        }
    }
}
