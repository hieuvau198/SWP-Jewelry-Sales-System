using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.IdentityModel.Tokens;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;
using System.Drawing.Printing;

namespace RazorTest.Pages.Buy
{
    public class ProcessingModel : PageModel
    {
        
        public const string SessionKeyBuyInvoiceObject = "_BuyInvoiceObject";
        public const string SessionKeyBuyCustomerObject = "_BuyCustomerObject";

        public const string SessionKeyInvoiceList = "_InvoiceList";
        public const string SessionKeyBuyInvoiceList = "_BuyInvoiceList";
        public const string SessionKeyCustomerList = "_CustomerList";
        public const string SessionKeyInvoiceItemList = "_InvoiceItemList";
        public const string SessionKeyBuyInvoiceItemList = "_BuyInvoiceItemList";

        public const string SessionKeyBuyInvoiceSearch = "_BuyInvoiceSearch";
        public const string SessionKeyBuyCustomerSearch = "_BuyCustomerSearch";

        public const string SessionKeyMessage = "_Message";

        public const string UrlInvoice = "https://hvjewel.azurewebsites.net/api/invoice";
        public const string UrlInvoiceItem = "https://hvjewel.azurewebsites.net/api/invoiceitem";
        public const string UrlCustomer = "https://hvjewel.azurewebsites.net/api/customer";

        private readonly ApiService _apiService;

        public ProcessingModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public List<Invoice> InvoiceList { get; set; }
        public List<Invoice> BuyInvoiceList { get; set; }
        public Invoice BuyInvoiceObject { get; set; }
        public string BuyInvoiceSearch { get; set; }

        public List<Customer> CustomerList { get; set; }
        public Customer BuyCustomerObject { get; set; }
        public string BuyCustomerSearch { get; set; }

        public List<InvoiceItem> InvoiceItemList { get; set; }
        public List<InvoiceItem> BuyInvoiceItemList { get; set; }
        public string Message { get; set; }

        public PaginatedList<Invoice> PaginatedBuyInvoiceList { get; set; }

        public async Task<IActionResult> OnGet(int pageIndex = 1, int pageSize = 6)
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

                //Get Data For Invoice on each Redirection
                InvoiceList = HttpContext.Session.GetObject<List<Invoice>>(SessionKeyInvoiceList)
                        ?? await _apiService.GetAsync<List<Invoice>>(UrlInvoice);
                BuyInvoiceList = HttpContext.Session.GetObject<List<Invoice>>(SessionKeyBuyInvoiceList);
                BuyInvoiceObject = HttpContext.Session.GetObject<Invoice>(SessionKeyBuyInvoiceObject);
                BuyInvoiceSearch = HttpContext.Session.GetString(SessionKeyBuyInvoiceSearch)
                    ?? "";

                //Get Data For Customer on each Redirection
                CustomerList = HttpContext.Session.GetObject<List<Customer>>(SessionKeyCustomerList)
                ?? await _apiService.GetAsync<List<Customer>>(UrlCustomer);
                BuyCustomerObject = HttpContext.Session.GetObject<Customer>(SessionKeyBuyCustomerObject);
                BuyCustomerSearch = HttpContext.Session.GetString(SessionKeyBuyCustomerSearch)
                    ?? "";

                //Get Data For InvoiceItem on each Redirection
                InvoiceItemList = HttpContext.Session.GetObject<List<InvoiceItem>>(SessionKeyInvoiceItemList);
                BuyInvoiceItemList = HttpContext.Session.GetObject<List<InvoiceItem>>(SessionKeyBuyInvoiceItemList);

                //Test Message
                Message = HttpContext.Session.GetString(SessionKeyMessage) ?? "Not Yet";

                // Paginate the filtered list if BuyInvoiceList is not null
                if (BuyInvoiceList != null)
                {
                    PaginatedBuyInvoiceList = PaginatedList<Invoice>.Create(BuyInvoiceList.AsQueryable(), pageIndex, pageSize);
                }else
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

        public async Task<IActionResult> OnPostSearch(string buyInvoiceSearch, string buyCustomerSearch, int pageIndex = 1, int pageSize = 6)
        {
            // Set data for search value
            buyInvoiceSearch ??= "";
            buyCustomerSearch ??= "";

            HttpContext.Session.SetString(SessionKeyBuyInvoiceSearch, buyInvoiceSearch);
            HttpContext.Session.SetString(SessionKeyBuyCustomerSearch, buyCustomerSearch);

            // Get Invoice List, Customer List from Session or API
            InvoiceList = HttpContext.Session.GetObject<List<Invoice>>(SessionKeyInvoiceList)
                          ?? await _apiService.GetAsync<List<Invoice>>(UrlInvoice);
            CustomerList = HttpContext.Session.GetObject<List<Customer>>(SessionKeyCustomerList)
                           ?? await _apiService.GetAsync<List<Customer>>(UrlCustomer);
            BuyInvoiceList = new List<Invoice>();

            // Search by InvoiceId
            if (!string.IsNullOrEmpty(buyInvoiceSearch))
            {
                foreach (var invoice in InvoiceList)
                {
                    if (invoice.InvoiceId.Contains(buyInvoiceSearch, StringComparison.OrdinalIgnoreCase)
                        && invoice.InvoiceStatus.Equals("Complete", StringComparison.OrdinalIgnoreCase)
                        && invoice.InvoiceType.Equals("Sale", StringComparison.OrdinalIgnoreCase))
                    {
                        BuyInvoiceList.Add(invoice);
                    }
                }
            }

            // Search by CustomerPhone
            if (!string.IsNullOrEmpty(buyCustomerSearch))
            {
                var matchedCustomers = CustomerList.Where(x => x.CustomerPhone.Contains(buyCustomerSearch, StringComparison.OrdinalIgnoreCase)).ToList();

                foreach (var customer in matchedCustomers)
                {
                    var customerInvoices = InvoiceList.Where(x => x.CustomerId.Equals(customer.CustomerId)
                                                                && x.InvoiceStatus.Equals("Complete", StringComparison.OrdinalIgnoreCase)
                                                                && x.InvoiceType.Equals("Sale", StringComparison.OrdinalIgnoreCase));

                    BuyInvoiceList.AddRange(customerInvoices);
                }
            }
            // Paginate the filtered list
            PaginatedBuyInvoiceList = PaginatedList<Invoice>.Create(BuyInvoiceList.AsQueryable(), pageIndex, pageSize);

            // Store paginated list in session
            HttpContext.Session.SetObject(SessionKeyBuyInvoiceList, BuyInvoiceList);
            
            return RedirectToPage(new { pageIndex }); // Redirect back to the page with current page index
    }


        public async Task<IActionResult> OnPostSelectInvoice(string buyInvoiceId)
        {
            BuyInvoiceList = HttpContext.Session.GetObject<List<Invoice>>(SessionKeyBuyInvoiceList);
            if(!BuyInvoiceList.IsNullOrEmpty<Invoice>())
            {
                Invoice invoice = BuyInvoiceList.Find(x => x.InvoiceId.Equals(buyInvoiceId));
                if(invoice != null)
                {
                    HttpContext.Session.SetObject(SessionKeyBuyInvoiceObject, invoice);
                    CustomerList = HttpContext.Session.GetObject<List<Customer>>(SessionKeyCustomerList)
                ?? await _apiService.GetAsync<List<Customer>>(UrlCustomer);
                    Customer customer = CustomerList.Find(x => x.CustomerId.Equals(invoice.CustomerId));
                    if(customer != null)
                    {
                        HttpContext.Session.SetObject(SessionKeyBuyCustomerObject, customer);
                    }
                }
            }
            
            return RedirectToPage("/Buy/Buyback");
        }
    }
}
