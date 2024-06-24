using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
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
        private readonly InvoiceService _invoiceService;

        public RevenueModel(InvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        public string MonthlySalesJson { get; set; }
        public string MonthlyPurchasesJson { get; set; }
        public string TopStaffSalesJson { get; set; }

        public async Task OnGetAsync()
        {
            var invoices = await _invoiceService.GetInvoicesAsync();

            var monthlySales = invoices
                .Where(i => i.InvoiceType.Equals("Sale", StringComparison.OrdinalIgnoreCase))
                .GroupBy(i => new { i.InvoiceDate.Year, i.InvoiceDate.Month })
                .Select(g => new
                {
                    month = $"{g.Key.Year}-{CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(g.Key.Month)}",
                    total = g.Sum(i => i.EndTotalPrice)
                })
                .ToList();

            var monthlyPurchases = invoices
                .Where(i => i.InvoiceType.Equals("Buy", StringComparison.OrdinalIgnoreCase))
                .GroupBy(i => new { i.InvoiceDate.Year, i.InvoiceDate.Month })
                .Select(g => new
                {
                    month = $"{g.Key.Year}-{CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(g.Key.Month)}",
                    total = g.Sum(i => i.EndTotalPrice)
                })
                .ToList();

            var topStaffSales = invoices
              .Where(i => i.InvoiceType.Equals("Sale", StringComparison.OrdinalIgnoreCase))
              .GroupBy(i => i.UserFullname)
              .Select(g => new
              {
                  staffName = g.Key,
                  totalSales = g.Sum(i => i.EndTotalPrice)
              })
              .OrderByDescending(s => s.totalSales)
              .ToList();

            var yearlySalesCount = invoices.Count(i => i.InvoiceType.Equals("Sale", StringComparison.OrdinalIgnoreCase));
            var yearlyPurchasesCount = invoices.Count(i => i.InvoiceType.Equals("Buy", StringComparison.OrdinalIgnoreCase));

            MonthlySalesJson = JsonSerializer.Serialize(monthlySales);
            MonthlyPurchasesJson = JsonSerializer.Serialize(monthlyPurchases);
            TopStaffSalesJson = JsonSerializer.Serialize(topStaffSales);
            ViewData["YearlySalesCount"] = yearlySalesCount;
            ViewData["YearlyPurchasesCount"] = yearlyPurchasesCount;
        }

    }
}
