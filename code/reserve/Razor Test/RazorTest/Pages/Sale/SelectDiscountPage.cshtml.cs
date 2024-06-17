using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;

namespace RazorTest.Pages.Sale
{
    public class SelectDiscountPageModel : PageModel
    {
        public const string SessionKeySaleDiscountProductId = "_SaleDiscountProductId";
        public const string SessionKeyDiscountList = "_DiscountList";
        public const string SessionKeySaleDiscountSelectedId = "_SaleDiscountSelectedId";
        public const string SessionKeySaleDiscountSelectedList = "_SaleDiscountSelectedList";
        public const string SessionKeySaleInvoiceItemList = "_SaleInvoiceItemList";

        public const string UrlGetDiscounts = "http://localhost:5071/api/discount\r\n";

        private readonly ApiService _apiService;
        public SelectDiscountPageModel(ApiService apiService)
        {
            _apiService = apiService; 
        }
        public string ProductId {  get; set; } 
        public List<Discount> Discounts {  get; set; }
        public List<Discount> SelectedDiscounts { get; set; }
        public List<InvoiceItem> InvoiceItems { get; set; }
        public string TestMessage { get; set; }

        public async Task OnGet()
        {
            ProductId = HttpContext.Session.GetString(SessionKeySaleDiscountProductId) ?? "Fail";

            Discounts = HttpContext.Session.GetObject<List<Discount>>(SessionKeyDiscountList);
            if(Discounts==null)
            {
                Discounts = await _apiService.GetAsync<List<Discount>>(UrlGetDiscounts);
                List<Discount> temp = new List<Discount>();
                foreach(Discount discount in Discounts)
                {
                    if(discount.ProductId.Equals("All") 
                        || discount.ProductId.Equals(ProductId) )
                    {
                        temp.Add(discount);
                    }
                }
                Discounts = temp;
            }
            SelectedDiscounts = HttpContext.Session.GetObject<List<Discount>>(SessionKeySaleDiscountSelectedList) ?? new List<Discount>();

            InvoiceItems = HttpContext.Session.GetObject<List<InvoiceItem>>(SessionKeySaleInvoiceItemList);

            TestMessage = InvoiceItems.Find(x => x.ProductId == ProductId).ProductName ?? "Fucking Fail";

            string selectDiscountId = HttpContext.Session.GetString(SessionKeySaleDiscountSelectedId);
            if(!string.IsNullOrEmpty(selectDiscountId) && InvoiceItems != null)
            {
                Discount discount = Discounts.Find(x => x.DiscountId == selectDiscountId);
                InvoiceItem invoiceItem = InvoiceItems.Find(x => x.ProductId == ProductId);
                Discount discountRemove = SelectedDiscounts.Find(x => x.DiscountId == selectDiscountId);
                if(discountRemove != null)
                {
                    SelectedDiscounts.Remove(discountRemove);
                }
                discount.ProductId = selectDiscountId;
                SelectedDiscounts.Add(discount);
                

                InvoiceItems.Remove(invoiceItem);
                invoiceItem.DiscountId = discount.DiscountId;
                invoiceItem.DiscountRate = discount.DiscountRate;
                InvoiceItems.Add(invoiceItem);
                
                HttpContext.Session.SetObject(SessionKeySaleInvoiceItemList, InvoiceItems);
                HttpContext.Session.SetObject(SessionKeySaleDiscountSelectedList, InvoiceItems);
                HttpContext.Session.Remove(SessionKeySaleDiscountSelectedId);
                TestMessage = "Success";
            }
            else { TestMessage = "Not Yet"; }
            

            
        }

        public async Task<IActionResult> OnPostSelectDiscount(string discountId)
        {
            HttpContext.Session.SetString(SessionKeySaleDiscountSelectedId, discountId);
            return RedirectToPage();
        }


    }
}