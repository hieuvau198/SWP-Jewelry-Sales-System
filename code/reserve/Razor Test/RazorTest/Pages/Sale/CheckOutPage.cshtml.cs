using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;

namespace RazorTest.Pages.Sale
{
    public class CheckOutPageModel : PageModel
    {
        public const string SessionKeySaleInvoiceObject = "_SaleInvoiceObject";
        public const string SessionKeyCart = "_Cart";
        public const string SessionKeyCustomerObject = "_CustomerObject";
        public const string SessionKeySaleInvoiceItemList = "_SaleInvoiceItemList";
        public const string SessionKeyUserObject = "_UserObject";
        public const string SessionKeySaleDiscountSelectedList = "_SaleDiscountSelectedList";

        private readonly ApiService _apiService;
        public CheckOutPageModel(ApiService apiService)
        {
            _apiService = apiService;
        }
        public List<Product> Cart { get; set; }
        public Customer Customer { get; set; }
        public User User { get; set; }
        public List<Discount> SelectedDiscounts { get; set; }
        public List<InvoiceItem> InvoiceItems { get; set; }
        public Invoice Invoice { get; set; }



        public async Task OnGet()
        {
            Cart = HttpContext.Session.GetObject<List<Product>>(SessionKeyCart);
            Customer = HttpContext.Session.GetObject<Customer>(SessionKeyCustomerObject);
            User = HttpContext.Session.GetObject<User>(SessionKeyUserObject);
            InvoiceItems = HttpContext.Session.GetObject<List<InvoiceItem>>(SessionKeySaleInvoiceItemList);
            SelectedDiscounts = HttpContext.Session.GetObject<List<Discount>>(SessionKeySaleDiscountSelectedList);
            Invoice = HttpContext.Session.GetObject<Invoice>(SessionKeySaleInvoiceObject);

            
        }
    }
}
