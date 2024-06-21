using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.IdentityModel.Tokens;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;

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

        public const string UrlInvoice = "http://localhost:5071/api/invoice";
        public const string UrlInvoiceItem = "http://localhost:5071/api/invoiceitem";
        public const string UrlCustomer = "http://localhost:5071/api/customer";

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


        public async Task OnGet()
        {
            //Get Data For Invoice on each Redirection
                InvoiceList = HttpContext.Session.GetObject<List<Invoice>>(SessionKeyInvoiceList)
                    ?? await _apiService.GetAsync<List<Invoice>>(UrlInvoice);
                BuyInvoiceList = HttpContext.Session.GetObject<List<Invoice>>(SessionKeyBuyInvoiceList);
                BuyInvoiceObject = HttpContext.Session.GetObject<Invoice> (SessionKeyBuyInvoiceObject);
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
        }

        public async Task<IActionResult> OnPostSearch(string buyInvoiceSearch, string buyCustomerSearch)
        {
            //Set data for search value
                if (string.IsNullOrEmpty(buyInvoiceSearch))
                { 
                    buyInvoiceSearch = ""; 
                }
                if (string.IsNullOrEmpty(buyCustomerSearch))
                { 
                    buyCustomerSearch = ""; 
                }

                HttpContext.Session.SetString(SessionKeyBuyInvoiceSearch, buyInvoiceSearch);
                HttpContext.Session.SetString(SessionKeyBuyCustomerSearch, buyCustomerSearch);

            //Get Invoice List, Customer List from Session or API
                InvoiceList = HttpContext.Session.GetObject<List<Invoice>>(SessionKeyInvoiceList)
                    ?? await _apiService.GetAsync<List<Invoice>>(UrlInvoice);
                CustomerList = HttpContext.Session.GetObject<List<Customer>>(SessionKeyCustomerList)
                    ?? await _apiService.GetAsync<List<Customer>>(UrlCustomer);
                BuyInvoiceList = new List<Invoice>();

            //Set Data If client search for InvoiceId 
                if (!buyInvoiceSearch.Equals(""))
                {
                    Invoice invoice = InvoiceList.Find(x => x.InvoiceId == buyInvoiceSearch);
                    if(invoice != null 
                        && invoice.InvoiceStatus.Equals("Complete")
                        && invoice.InvoiceType.Equals("Sale"))
                    {
                        BuyInvoiceList.Add(invoice);
                    }
                }
                if(!buyCustomerSearch.Equals(""))
                {
                    Customer customer = CustomerList.Find(x => x.CustomerPhone == buyCustomerSearch);
                    if(customer != null)
                    {
                        foreach(var invoice in InvoiceList)
                        {
                            if(invoice.CustomerId.Equals(customer.CustomerId) 
                                && invoice.InvoiceStatus.Equals("Complete")
                                && invoice.InvoiceType.Equals("Sale"))
                            {
                                BuyInvoiceList.Add(invoice);
                            }
                        }
                    }
                }
                HttpContext.Session.SetObject(SessionKeyBuyInvoiceList, BuyInvoiceList);

            return RedirectToPage();
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
