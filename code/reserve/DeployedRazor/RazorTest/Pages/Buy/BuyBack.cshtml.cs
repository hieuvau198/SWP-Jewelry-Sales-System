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

        public const string SessionKeyAuthState = "_AuthState";
        //declare session var = type List
        public const string SessionKeyInvoiceItemList = "_InvoiceItemList";
        public const string SessionKeyProductList = "_ProductList";

        //declare url
        public const string UrlInvoiceItem = "https://hvjewel.azurewebsites.net/api/invoiceitem";
        public const string UrlProduct = "https://hvjewel.azurewebsites.net/api/product";

        private readonly ApiService _apiService;

        public BuyBackModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public User User { get; set; }
        public Invoice BuyInvoiceObject { get; set; }
        public Customer BuyCustomerObject { get; set; }
        public List<InvoiceItem> BuyInvoiceItemList { get; set; }
        public List<InvoiceItem> InvoiceItemList { get; set; }

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

                // Get Data
                User = HttpContext.Session.GetObject<User>(SessionKeyUserObject);

                BuyInvoiceObject = HttpContext.Session.GetObject<Invoice>(SessionKeyBuyInvoiceObject);
                if (BuyInvoiceObject == null)
                {
                    return RedirectToPage("/Error");
                }
                BuyCustomerObject = HttpContext.Session.GetObject<Customer>(SessionKeyBuyCustomerObject);

                InvoiceItemList = HttpContext.Session.GetObject<List<InvoiceItem>>(SessionKeyInvoiceItemList);
                if (InvoiceItemList.IsNullOrEmpty())
                {
                    InvoiceItemList = await _apiService.GetAsync<List<InvoiceItem>>(UrlInvoiceItem);
                    HttpContext.Session.SetObject(SessionKeyInvoiceItemList, InvoiceItemList);
                }

                BuyInvoiceItemList = new List<InvoiceItem>();

                foreach (InvoiceItem item in InvoiceItemList)
                {
                    if (item.InvoiceId.Equals(BuyInvoiceObject.InvoiceId))
                    {
                        BuyInvoiceItemList.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error");
            }

            return Page();
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
                if (products.IsNullOrEmpty())
                {
                    products = await _apiService.GetAsync<List<Product>>(UrlProduct);
                    HttpContext.Session.SetObject(SessionKeyProductList, products);
                }
                Product product = products.Find(x => x.ProductId == invoiceItem.ProductId);
                if (product != null)
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
                if (BuyCustomerObject != null)
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
