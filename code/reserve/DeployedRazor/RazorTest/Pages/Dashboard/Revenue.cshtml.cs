using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace RazorTest.Pages.Dashboard
{
    public class RevenueModel : PageModel
    {
        public const string SessionKeyUserObject = "_UserObject";

        private readonly InvoiceService _invoiceService;
        private readonly ApiService _apiService;

        public RevenueModel(InvoiceService invoiceService, ApiService apiService)
        {
            _invoiceService = invoiceService;
            _apiService = apiService;
        }
        public User User { get; set; }

        public string MonthlySalesJson { get; set; }
        public string MonthlyPurchasesJson { get; set; }
        public string TopStaffSalesJson { get; set; }
        public string BestStaffMonthlyJson { get; set; }

        public double TotalSales { get; set; }
        public double TotalPurchases { get; set; }
        public int TotalInvoices { get; set; }
        public string BestStaff { get; set; }
        public string BestSalesMonth { get; set; }
        public string BestPurchasesMonth { get; set; }
        public double BestSalesOfMonth { get; set; }
        public double BestPurchasesOfMonth { get; set; }
        public int TotalPendingInvoices { get; set; }
        public int TotalCompleteInvoices { get; set; }
        public int TotalInvoiceByStaff { get; set; }
        public double HighestSalesAmount { get; set; }
        public string BestStaffName { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                // Verify user
                if (!_apiService.VerifyAuth(HttpContext, "Admin"))
                {
                    return RedirectToPage("/Authentication/AccessDenied");
                }

                // Get data
                User = HttpContext.Session.GetObject<User>(SessionKeyUserObject);

                var invoices = await _invoiceService.GetInvoicesAsync();
                if (invoices == null)
                {
                    return RedirectToPage("/NotFound");
                }

                var monthlySales = invoices
                    .Where(i => i.InvoiceType.Equals("Sale", StringComparison.OrdinalIgnoreCase))
                    .OrderBy(g => g.InvoiceDate)
                    .GroupBy(i => new { i.InvoiceDate.Year, i.InvoiceDate.Month })
                    .Select(g => new
                    {
                        month = $"{g.Key.Year}-{CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(g.Key.Month)}",
                        total = g.Sum(i => i.EndTotalPrice)
                    })
                    .ToList();

                var monthlyPurchases = invoices
                    .Where(i => i.InvoiceType.Equals("Buy", StringComparison.OrdinalIgnoreCase))
                    .OrderBy(g => g.InvoiceDate)
                    .GroupBy(i => new { i.InvoiceDate.Year, i.InvoiceDate.Month })
                    .Select(g => new
                    {
                        month = $"{g.Key.Year}-{CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(g.Key.Month)}",
                        total = g.Sum(i => i.EndTotalPrice)
                    })
                    .ToList();

                var topStaffSales = invoices
                  .Where(i => i.InvoiceType.Equals("Sale", StringComparison.OrdinalIgnoreCase))
                  .OrderBy(g => g.InvoiceDate)
                  .GroupBy(i => i.UserFullname)
                  .Select(g => new
                  {
                      staffName = g.Key,
                      totalSales = g.Sum(i => i.EndTotalPrice)
                  })
                  .OrderByDescending(s => s.totalSales)
                  .ToList();

                var bestStaffMonthly = invoices
                    .Where(i => i.InvoiceType.Equals("Sale", StringComparison.OrdinalIgnoreCase))
                    .OrderBy(g => g.InvoiceDate)
                    .GroupBy(i => new { i.InvoiceDate.Year, i.InvoiceDate.Month, i.UserFullname })
                    .Select(g => new
                    {
                        month = $"{g.Key.Year}-{CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(g.Key.Month)}",
                        staffName = g.Key.UserFullname,
                        totalSales = g.Sum(i => i.EndTotalPrice)
                    })
                    .GroupBy(g => g.month)
                    .Select(g => g.OrderByDescending(s => s.totalSales).FirstOrDefault())
                    .ToList();

                var yearlySalesCount = invoices.Count(i => i.InvoiceType.Equals("Sale", StringComparison.OrdinalIgnoreCase));
                var yearlyPurchasesCount = invoices.Count(i => i.InvoiceType.Equals("Buy", StringComparison.OrdinalIgnoreCase));
                var totalPendingInvoices = invoices.Count(i => i.InvoiceStatus.Equals("Pending", StringComparison.OrdinalIgnoreCase));
                var totalCompleteInvoices = invoices.Count(i => i.InvoiceStatus.Equals("Complete", StringComparison.OrdinalIgnoreCase));
                var totalInvoiceByStaff = invoices.Count(i => i.UserFullname.Equals(BestStaff, StringComparison.OrdinalIgnoreCase));
                var bestStaffName = topStaffSales.FirstOrDefault()?.staffName ?? "N/A";
                var highestSalesAmount = topStaffSales.FirstOrDefault()?.totalSales ?? 0;
                
                TotalSales = monthlySales.Sum(s => s.total);
                TotalPurchases = monthlyPurchases.Sum(p => p.total);
                TotalInvoices = invoices.Count;
                BestStaff = topStaffSales.FirstOrDefault()?.staffName ?? "N/A";
                TotalPendingInvoices = totalPendingInvoices;
                TotalCompleteInvoices = totalCompleteInvoices;                
                BestStaffName = bestStaffName;
                HighestSalesAmount = highestSalesAmount;
                TotalInvoiceByStaff = invoices.Count(i => i.UserFullname.Equals(BestStaffName, StringComparison.OrdinalIgnoreCase));

                MonthlySalesJson = JsonSerializer.Serialize(monthlySales);
                MonthlyPurchasesJson = JsonSerializer.Serialize(monthlyPurchases);
                TopStaffSalesJson = JsonSerializer.Serialize(topStaffSales);
                BestStaffMonthlyJson = JsonSerializer.Serialize(bestStaffMonthly);
                ViewData["YearlySalesCount"] = yearlySalesCount;
                ViewData["YearlyPurchasesCount"] = yearlyPurchasesCount;
                ViewData["TotalPendingInvoices"] = totalPendingInvoices;
                ViewData["totalCompleteInvoices"] = totalCompleteInvoices;
                ViewData["BestStaffName"] = bestStaffName;
                ViewData["HighestSalesAmount"] = highestSalesAmount;
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error");
            }

            return Page();
        }

    }
}
