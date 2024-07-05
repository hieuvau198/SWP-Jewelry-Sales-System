using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;

namespace RazorTest.Pages.Sale
{
    public class SelectDiscountPageModel : PageModel
    {
        public const string SessionKeyAuthState = "_AuthState";
        public const string SessionKeyUserObject = "_UserObject";

        public const string SessionKeySaleDiscountProductId = "_SaleDiscountProductId";
        public const string SessionKeyDiscountList = "_DiscountList";
        public const string SessionKeySaleDiscountSelectedId = "_SaleDiscountSelectedId";
        public const string SessionKeySaleDiscountSelectedList = "_SaleDiscountSelectedList";
        public const string SessionKeySaleInvoiceItemList = "_SaleInvoiceItemList";
        public const string SessionKeyProductList = "_ProductList";

        public const string UrlGetDiscounts = "https://hvjewel.azurewebsites.net/api/discount\r\n";
        public const string UrlGetProducts = "https://hvjewel.azurewebsites.net/api/product\r\n";

        private readonly ApiService _apiService;
        public SelectDiscountPageModel(ApiService apiService)
        {
            _apiService = apiService; 
        }
        public string ProductId {  get; set; } 
        public List<Discount> Discounts {  get; set; }
        public List<Discount> SelectedDiscounts { get; set; }
        public List<InvoiceItem> InvoiceItems { get; set; }
        public List<Product> ProductList { get; set; }
        public Product SelectedProduct { get; set; }
        public Discount SelectedDiscount { get; set; }
        public string TestMessage { get; set; }

        public async Task<IActionResult> OnGet()
        {
            // Verify auth
            List<string> roles = new List<string>
            {
                "Admin",
                "Sale",
                "Cashier"
            };
            if (!_apiService.VerifyAuth(HttpContext, roles))
            {
                return RedirectToPage("/Authentication/AccessDenied");
            }

            ProductId = HttpContext.Session.GetString(SessionKeySaleDiscountProductId) ?? "Fail";
            ProductList = HttpContext.Session.GetObject<List<Product>>(SessionKeyProductList);
            if(ProductList == null)
            {
                ProductList = await _apiService.GetAsync<List<Product>>(UrlGetProducts);
                HttpContext.Session.SetObject(SessionKeyProductList, ProductList);
            }
            SelectedProduct = ProductList.Find(x  => x.ProductId == ProductId);

            // Set basic data to the page

                if(SelectedProduct != null)
                {
                    Discounts = HttpContext.Session.GetObject<List<Discount>>(SessionKeyDiscountList);
                    if (Discounts == null)
                    {
                        Discounts = await _apiService.GetAsync<List<Discount>>(UrlGetDiscounts);
                        List<Discount> temp = new List<Discount>();
                        DateTime currentTime = DateTime.Now;
                        foreach (Discount discount in Discounts)
                        {
                            if (discount.ProductType.Equals("All")
                                || discount.ProductId.Equals(ProductId)
                                || (discount.ProductType.Equals(SelectedProduct.ProductType)
                                            && discount.ProductId.Equals("All"))
                                )
                            {
                                if (discount.PublicDate < currentTime
                                && discount.ExpireDate > currentTime)
                                {
                                    temp.Add(discount);
                                }

                            }
                        }
                        Discounts = temp.OrderByDescending(d => d.DiscountRate).ToList();
                    }
                    SelectedDiscounts = HttpContext.Session.GetObject<List<Discount>>(SessionKeySaleDiscountSelectedList) ?? new List<Discount>();

                    InvoiceItems = HttpContext.Session.GetObject<List<InvoiceItem>>(SessionKeySaleInvoiceItemList);
                    if(InvoiceItems != null)
                    {
                        InvoiceItem invoiceItem = InvoiceItems.Find(x => x.ProductId == SelectedProduct.ProductId);

                        if(invoiceItem != null)
                        {
                            SelectedDiscount = Discounts.Find(x => x.DiscountId == invoiceItem.DiscountId);
                        }
                    }

                    // Update data if user selected discount

                        string selectDiscountId = HttpContext.Session.GetString(SessionKeySaleDiscountSelectedId);
                    
                        if (!string.IsNullOrEmpty(selectDiscountId) && InvoiceItems != null)
                            {
                                Discount discount = Discounts.Find(x => x.DiscountId == selectDiscountId);
                                InvoiceItem invoiceItem = InvoiceItems.Find(x => x.ProductId == ProductId);
                                Discount discountRemove = SelectedDiscounts.Find(x => x.DiscountId == selectDiscountId);
                                if (discountRemove != null)
                                {
                                    SelectedDiscounts.Remove(discountRemove);
                                }
                                discount.ProductId = selectDiscountId;
                                SelectedDiscounts.Add(discount);
                                SelectedDiscount = discount;

                                InvoiceItems.Remove(invoiceItem);
                                invoiceItem.DiscountId = discount.DiscountId;
                                invoiceItem.DiscountRate = discount.DiscountRate;
                                invoiceItem.EndTotalPrice = invoiceItem.TotalPrice * (1 - discount.DiscountRate);
                                InvoiceItems.Add(invoiceItem);

                                HttpContext.Session.SetObject(SessionKeySaleInvoiceItemList, InvoiceItems);
                                HttpContext.Session.SetObject(SessionKeySaleDiscountSelectedList, InvoiceItems);
                                HttpContext.Session.Remove(SessionKeySaleDiscountSelectedId);
                            }

                }


            return Page();

        }

        public async Task<IActionResult> OnPostSelectDiscount(string discountId)
        {
            HttpContext.Session.SetString(SessionKeySaleDiscountSelectedId, discountId);
            return RedirectToPage();
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
