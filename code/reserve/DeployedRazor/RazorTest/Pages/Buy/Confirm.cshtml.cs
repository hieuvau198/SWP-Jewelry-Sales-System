using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;

namespace RazorTest.Pages.Buy
{
    public class ConfirmModel : PageModel
    {
        public const string SessionKeyUserObject = "_UserObject";
        public const string SessionKeyAuthState = "_AuthState";

        public const string SessionKeyBuyInvoiceItemObject = "_BuyInvoiceItemObject";
        public const string SessionKeyBuyInvoiceObject = "_BuyInvoiceObject";
        public const string SessionKeyBuyProductObject = "_BuyProductObject";
        public const string SessionKeyBuyConfirmInvoiceObject = "_BuyConfirmInvoiceObject";
        public const string SessionKeyBuyConfirmInvoiceItemObject = "_BuyConfirmInvoiceItemObject";
        public const string SessionKeyBuyCustomerObject = "_BuyCustomerObject";

        public const string SessionKeyBuyInvoiceItemlist = "_BuyInvoiceItemList";
        public const string SessionKeyBuyInvoiceList = "_BuyInvoiceList";

        public const string SessionKeyBuyCustomerSearch = "_BuyCustomerSearch";
        public const string SessionKeyBuyInvoiceSearch = "_BuyInvoiceSearch";

        public const string UrlInvoice = "https://hvjewel.azurewebsites.net/api/invoice\r\n";
        public const string UrlInvoiceItem = "https://hvjewel.azurewebsites.net/api/invoiceitem\r\n";
        public const string UrlProduct = "https://hvjewel.azurewebsites.net/api/product";

        private readonly ApiService _apiService;
        public ConfirmModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public User User { get; set; }

        public InvoiceItem BuyInvoiceItemObject { get; set; }
        public Product BuyProductObject { get; set; }
        public Invoice BuyConfirmInvoiceObject { get; set; }
        public InvoiceItem BuyConfirmInvoiceItemObject { get; set; }
        public async Task<IActionResult> OnGet()
        {


            try
            {
                // Verify auth
                List<string> roles = new List<string>
                {
                    "Sale",
                    "Cashier",
                };
                if (!_apiService.VerifyAuth(HttpContext, roles))
                {
                    return RedirectToPage("/Authentication/AccessDenied");
                }

                // Process data
                User = HttpContext.Session.GetObject<User>(SessionKeyUserObject);

                BuyInvoiceItemObject = HttpContext.Session.GetObject<InvoiceItem>(SessionKeyBuyInvoiceItemObject);
                BuyProductObject = HttpContext.Session.GetObject<Product>(SessionKeyBuyProductObject);

                BuyConfirmInvoiceObject = HttpContext.Session.GetObject<Invoice>(SessionKeyBuyConfirmInvoiceObject);
                BuyConfirmInvoiceItemObject = HttpContext.Session.GetObject<InvoiceItem>(SessionKeyBuyConfirmInvoiceItemObject);

                if (BuyInvoiceItemObject == null
                    || BuyProductObject == null
                    || BuyConfirmInvoiceObject == null
                    || BuyConfirmInvoiceItemObject == null)
                {
                    return RedirectToPage("/Error");
                }
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostConfirmBuying()
        {
            BuyConfirmInvoiceObject = HttpContext.Session.GetObject<Invoice>(SessionKeyBuyConfirmInvoiceObject);
            BuyConfirmInvoiceItemObject = HttpContext.Session.GetObject<InvoiceItem>(SessionKeyBuyConfirmInvoiceItemObject);

            if (BuyConfirmInvoiceObject==null)
            {

                return RedirectToPage();
            }
            else if (BuyConfirmInvoiceItemObject==null)
            {
                return RedirectToPage();
            }
            else
            {
                //Set data before transfer it to API
                    BuyConfirmInvoiceObject.InvoiceId = Guid.NewGuid().ToString();
                    BuyConfirmInvoiceItemObject.InvoiceItemId = Guid.NewGuid().ToString();
                    BuyConfirmInvoiceItemObject.InvoiceId = BuyConfirmInvoiceObject.InvoiceId;
                
                //Call APIs to update data (remember to post items before invoice)
                    _apiService.PostAsJsonAsync<InvoiceItem>(UrlInvoiceItem, BuyConfirmInvoiceItemObject);
                    _apiService.PostAsJsonAsync<Invoice>(UrlInvoice, BuyConfirmInvoiceObject);

                //Remove Session data - type Object
                    HttpContext.Session.Remove(SessionKeyBuyConfirmInvoiceObject);
                    HttpContext.Session.Remove(SessionKeyBuyConfirmInvoiceItemObject);

                    HttpContext.Session.Remove(SessionKeyBuyInvoiceItemObject);
                    HttpContext.Session.Remove(SessionKeyBuyProductObject);
                    HttpContext.Session.Remove(SessionKeyBuyInvoiceObject);
                    HttpContext.Session.Remove(SessionKeyBuyCustomerObject);

                //Remove Session data - type List
                    HttpContext.Session.Remove(SessionKeyBuyInvoiceItemlist);
                    HttpContext.Session.Remove(SessionKeyBuyInvoiceList);

                //Remove Session data - type string
                    HttpContext.Session.Remove(SessionKeyBuyCustomerSearch);
                    HttpContext.Session.Remove(SessionKeyBuyInvoiceSearch);
                    
            }

            return RedirectToPage("/Buy/Processing");
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
