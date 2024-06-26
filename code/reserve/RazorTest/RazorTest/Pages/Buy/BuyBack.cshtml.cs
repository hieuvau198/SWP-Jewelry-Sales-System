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
        //declare session var - type Object
            public const string SessionKeyBuyInvoiceObject = "_BuyInvoiceObject";
            public const string SessionKeyBuyCustomerObject = "_BuyCustomerObject";
            public const string SessionKeyBuyInvoiceItemlist = "_BuyInvoiceItemList";
            public const string SessionKeyBuyInvoiceItemObject = "_BuyInvoiceItemObject";
            public const string SessionKeyBuyProductObject = "_BuyProductObject";
            public const string SessionKeyUserObject = "_UserObject";

            public const string SessionKeyBuyConfirmInvoiceObject = "_BuyConfirmInvoiceObject";
            public const string SessionKeyBuyConfirmInvoiceItemObject = "_BuyConfirmInvoiceItemObject";

        //declare session var = type List
            public const string SessionKeyInvoiceItemList = "_InvoiceItemList";
            public const string SessionKeyProductList = "_ProductList";

        //declare url
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
            BuyCustomerObject = HttpContext.Session.GetObject<Customer>(SessionKeyBuyCustomerObject);
            User user = HttpContext.Session.GetObject<User>(SessionKeyUserObject);
            InvoiceItemList = HttpContext.Session.GetObject<List<InvoiceItem>>(SessionKeyInvoiceItemList);
            InvoiceItem invoiceItem = InvoiceItemList.Find(x => x.InvoiceItemId.Equals(invoiceItemId));
            string customerId = "";
            string customerName = "";
            string userId = "";
            string userFullname = "";

            if (invoiceItem != null)
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

                    
                if (user != null)
                {
                    userId = user.UserId;
                    userFullname = user.Fullname;
                }
                else
                {
                    userId = "";
                    userFullname = "";
                }
                if(BuyCustomerObject != null)
                {
                    customerId = BuyCustomerObject.CustomerId;
                    customerName = BuyCustomerObject.CustomerName;
                }
                else 
                {
                    customerId = "";
                    customerName = "";
                }
                
                
                InvoiceItem resultInvoiceItem = new InvoiceItem
                {
                    InvoiceItemId = "",
                    InvoiceId = "",
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    StallId = "Updating Feature",
                    StallName = "Updating Feature",
                    Quantity = 1,
                    UnitPrice = product.BuyPrice,
                    DiscountId = "Not Applied",
                    DiscountRate = 0,
                    TotalPrice = product.BuyPrice,
                    EndTotalPrice = product.BuyPrice,
                    WarrantyId = "Not Applied"

                };
                Invoice resultInvoice = new Invoice
                {
                    InvoiceId = "",
                    InvoiceType = "Buy",
                    CustomerId = customerId,
                    CustomerName = customerName,
                    UserId = userId,
                    UserFullname = userFullname,
                    InvoiceDate = DateTime.Now,
                    CustomerVoucher = 0,
                    TotalPrice = product.BuyPrice,
                    EndTotalPrice = product.BuyPrice,
                    InvoiceStatus = "Pending"
                };

                HttpContext.Session.SetObject(SessionKeyBuyConfirmInvoiceObject, resultInvoice);
                HttpContext.Session.SetObject(SessionKeyBuyConfirmInvoiceItemObject, resultInvoiceItem);
            }
            else
            {
                return RedirectToPage();
            }
            return RedirectToPage("/Buy/Confirm");
        }



    }
}
