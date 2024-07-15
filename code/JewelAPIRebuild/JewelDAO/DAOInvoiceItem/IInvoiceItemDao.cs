using JewelBO;

namespace JewelDAO.DAOInvoiceItem
{
    public interface IInvoiceItemDao
    {
        List<InvoiceItem> GetInvoiceItems();
        InvoiceItem GetInvoiceItem(string invoiceItemId);
        InvoiceItem AddInvoiceItem(InvoiceItem invoiceItem);
        bool RemoveInvoiceItem(string invoiceItemId);
        bool UpdateInvoiceItem(InvoiceItem invoiceItem);
    }
}
