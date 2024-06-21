using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;

namespace RazorTest.Pages.Buy
{
    public class ConfirmModel : PageModel
    {
        public const string SessionKeyBuyInvoiceItemObject = "_BuyInvoiceItemObject";
        public const string SessionKeyBuyProductObject = "_BuyProductObject";
        public const string SessionKeyBuyConfirmInvoiceObject = "_BuyConfirmInvoiceObject";
        public const string SessionKeyBuyConfirmInvoiceItemObject = "_BuyConfirmInvoiceItemObject";

        private readonly ApiService _apiService;
        public ConfirmModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public InvoiceItem BuyInvoiceItemObject { get; set; }
        public Product BuyProductObject { get; set; }
        public async Task OnGet()
        {
            BuyInvoiceItemObject = HttpContext.Session.GetObject<InvoiceItem>(SessionKeyBuyInvoiceItemObject);
            BuyProductObject = HttpContext.Session.GetObject<Product>(SessionKeyBuyProductObject);
            

        }

        public async Task<IActionResult> OnPostConfirmBuying()
        {
            Invoice buyConfirmInvoiceObject = new Invoice();
            InvoiceItem buyConfirmInvoiceItemObject = new InvoiceItem();



            return RedirectToPage("/Buy/Processing");
        }


    }
}
