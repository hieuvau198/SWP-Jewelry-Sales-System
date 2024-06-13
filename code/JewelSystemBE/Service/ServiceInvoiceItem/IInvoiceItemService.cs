﻿using JewelSystemBE.Model;

namespace JewelSystemBE.Service.ServiceInvoiceItem
{
    public interface IInvoiceItemService
    {
        List<InvoiceItem> GetInvoiceItems();
        InvoiceItem GetInvoiceItem(string invoiceItemId);
        InvoiceItem AddInvoiceItem(InvoiceItem invoiceItem);
        bool RemoveInvoiceItem(string invoiceItemId);
        bool UpdateInvoiceItem(InvoiceItem invoiceItem);
    }
}
