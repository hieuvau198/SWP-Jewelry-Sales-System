using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;

namespace RazorTest.Pages.Sale
{
    public class CheckOutPageModel : PageModel
    {
        public const string SessionKeyAuthState = "_AuthState";

        public const string SessionKeyCart = "_Cart";

        public const string SessionKeyCustomerObject = "_CustomerObject";
        public const string SessionKeyCustomerId = "_CustomerId";
        public const string SessionKeySearchCustomer = "_SearchCustomer";

        public const string SessionKeySaleInvoiceObject = "_SaleInvoiceObject";
        public const string SessionKeySaleInvoiceItemList = "_SaleInvoiceItemList";

        public const string SessionKeyDiscountList = "_DiscountList";
        public const string SessionKeySaleDiscountSelectedList = "_SaleDiscountSelectedList";
        public const string SessionKeySaleDiscountProductId = "_SaleDiscountProductId";
        public const string SessionKeySaleDiscountSelectedId = "_SaleDiscountSelectedId";

        public const string SessionKeyUserObject = "_UserObject";

        public const string UrlInvoice = "http://localhost:5071/api/invoice\r\n";
        public const string UrlInvoiceItem = "http://localhost:5071/api/invoiceitem\r\n";

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

        public async Task<IActionResult> OnGet()
        {
            try
            {
                // Verify auth
                List<string> roles = new List<string>
                {
                    "Sale",
                    "Cashier",
                    "Admin"
                };
                if (!_apiService.VerifyAuth(HttpContext, roles))
                {
                    return RedirectToPage("/Authentication/AccessDenied");
                }

                Cart = HttpContext.Session.GetObject<List<Product>>(SessionKeyCart);
                Customer = HttpContext.Session.GetObject<Customer>(SessionKeyCustomerObject) ?? new Customer { CustomerName = "Anonymous" };
                User = HttpContext.Session.GetObject<User>(SessionKeyUserObject);
                InvoiceItems = HttpContext.Session.GetObject<List<InvoiceItem>>(SessionKeySaleInvoiceItemList);
                SelectedDiscounts = HttpContext.Session.GetObject<List<Discount>>(SessionKeySaleDiscountSelectedList);
                Invoice = HttpContext.Session.GetObject<Invoice>(SessionKeySaleInvoiceObject);

                if(Cart == null || InvoiceItems == null || Invoice == null)
                {
                    return RedirectToPage("/NotFound");
                }
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostConfirm()
        {
            List<InvoiceItem> invoiceItems = HttpContext.Session.GetObject<List<InvoiceItem>>(SessionKeySaleInvoiceItemList);
            Invoice invoice = HttpContext.Session.GetObject<Invoice>(SessionKeySaleInvoiceObject);
            string invoiceId = Guid.NewGuid().ToString();

            if(invoiceItems != null && invoice != null)
            {
                invoice.InvoiceId = invoiceId;
                //   invoice.InvoiceDate = DateTime.Now;
                
                // Get server time and time zone
                DateTime serverTime = DateTime.Now;
                TimeZoneInfo serverTimeZone = TimeZoneInfo.Local;
                Console.WriteLine($"Server time: {serverTime}, Server time zone: {serverTimeZone.DisplayName}");

                // Specify the time zone you want to use (e.g., SE Asia Standard Time)
                TimeZoneInfo targetTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTime(serverTime, targetTimeZone);
                Console.WriteLine($"Converted local time: {localTime}, Target time zone: {targetTimeZone.DisplayName}");

                invoice.InvoiceDate = localTime;

                foreach (var invoiceItem in invoiceItems)
                {
                    invoiceItem.InvoiceId = invoiceId;
                    _apiService.PostAsJsonAsync<InvoiceItem>(UrlInvoiceItem, invoiceItem);
                    
                }
                _apiService.PostAsJsonAsync<Invoice>(UrlInvoice, invoice);

                HttpContext.Session.Remove(SessionKeyCart);

                HttpContext.Session.Remove(SessionKeyCustomerObject);
                HttpContext.Session.Remove(SessionKeyCustomerId);
                HttpContext.Session.Remove(SessionKeySearchCustomer);

                HttpContext.Session.Remove(SessionKeySaleInvoiceItemList);
                HttpContext.Session.Remove(SessionKeySaleInvoiceObject);
                
                HttpContext.Session.Remove(SessionKeyDiscountList);
                HttpContext.Session.Remove(SessionKeySaleDiscountSelectedList) ;
                HttpContext.Session.Remove(SessionKeySaleDiscountSelectedId);
                HttpContext.Session.Remove(SessionKeySaleDiscountProductId);
            }
            else
            {
                return RedirectToPage();
            }
            


            return RedirectToPage("/Index");
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
