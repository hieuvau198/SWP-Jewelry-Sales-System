using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;

namespace RazorTest.Pages.Buy
{
    public class BuyBackModel : PageModel
    {
        public const string SessionKeyBuyInvoiceObject = "_BuyInvoiceObject";
        public const string SessionKeyBuyCustomerObject = "_BuyCustomerObject";
        public const string SessionKeyBuyInvoiceItemlist = "_BuyInvoiceItemList";
        public const string SessionKeyBuyInvoiceItemObject = "_BuyInvoiceItemObject";
        public const string SessionKeyBuyProductObject = "_BuyProductObject";

        public const string SessionKeyInvoiceItemList = "_InvoiceItemList";
        public const string SessionKeyProductList = "_ProductList";

        public const string UrlInvoiceItem = "http://localhost:5071/api/invoiceitem";
        public const string UrlProduct = "http://localhost:5071/api/product";

        private readonly ApiService _apiService;

        public BuyBackModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public Invoice BuyInvoiceObject { get; set; }
        public Customer BuyCustomerObject { get; set; }
        public List<InvoiceItem> BuyInvoiceItemList { get; set; }
        public List<InvoiceItem> InvoiceItemList { get; set; }

        public async Task OnGet()
        {
            //Get Data
            BuyInvoiceObject = HttpContext.Session.GetObject<Invoice>(SessionKeyBuyInvoiceObject);
            BuyCustomerObject = HttpContext.Session.GetObject<Customer>(SessionKeyBuyCustomerObject);

            InvoiceItemList = HttpContext.Session.GetObject<List<InvoiceItem>>(SessionKeyInvoiceItemList);
            if(InvoiceItemList.IsNullOrEmpty())
            {
                InvoiceItemList = await _apiService.GetAsync<List<InvoiceItem>>(UrlInvoiceItem);
                HttpContext.Session.SetObject(SessionKeyInvoiceItemList, InvoiceItemList);
            }

            BuyInvoiceItemList = new List<InvoiceItem>();
            foreach(InvoiceItem item in InvoiceItemList)
            {
                if(item.InvoiceId.Equals(BuyInvoiceObject.InvoiceId))
                {
                    BuyInvoiceItemList.Add(item);
                }
            }
            

        }

        public async Task<IActionResult> OnPostBuyItem(string invoiceItemId)
        {
            InvoiceItemList = HttpContext.Session.GetObject<List<InvoiceItem>>(SessionKeyInvoiceItemList);
            InvoiceItem invoiceItem = InvoiceItemList.Find(x => x.InvoiceItemId.Equals(invoiceItemId));
            if(invoiceItem != null)
            {
                HttpContext.Session.SetObject(SessionKeyBuyInvoiceItemObject, invoiceItem);
                List<Product> products = HttpContext.Session.GetObject<List<Product>>(SessionKeyProductList);
                if(products.IsNullOrEmpty())
                {
                    products = await _apiService.GetAsync<List<Product>>(UrlProduct);
                    HttpContext.Session.SetObject(SessionKeyProductList, products);
                }
                Product product = products.Find(x => x.ProductId == invoiceItem.ProductId);
                if(product != null)
                {
                    product.ProductQuantity = 1;
                    HttpContext.Session.SetObject(SessionKeyBuyProductObject, product);
                }
            }
            return RedirectToPage("/Buy/Confirm");
        }



    }
}
