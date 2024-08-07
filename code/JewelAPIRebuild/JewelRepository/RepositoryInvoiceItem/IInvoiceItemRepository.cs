﻿

using JewelBO;

namespace JewelRepository.RepositoryInvoiceItem
{
    public interface IInvoiceItemRepository
    {
        List<InvoiceItem> GetInvoiceItems();
        InvoiceItem GetInvoiceItem(string invoiceItemId);
        InvoiceItem AddInvoiceItem(InvoiceItem invoiceItem);
        bool RemoveInvoiceItem(string invoiceItemId);
        bool UpdateInvoiceItem(InvoiceItem invoiceItem);
    }
}
