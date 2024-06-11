

using JewelBO;
using JewelDAO.DAOInvoiceItem;

namespace JewelRepository.RepositoryInvoiceItem
{
    public class InvoiceItemRepository : IInvoiceItemRepository
    {
        private IInvoiceItemDao _invoiceItemDao;
        public InvoiceItemRepository (IInvoiceItemDao invoiceItemDao)
        {
            _invoiceItemDao = invoiceItemDao;
        }
        public bool AddInvoiceItem(InvoiceItem invoiceItem)
        {
            return _invoiceItemDao.AddInvoiceItem(invoiceItem);
        }

        public InvoiceItem GetInvoiceItem(string invoiceItemId)
        {
            return _invoiceItemDao.GetInvoiceItem(invoiceItemId);
        }

        public List<InvoiceItem> GetInvoiceItems()
        {
            return _invoiceItemDao.GetInvoiceItems();
        }

        public bool RemoveInvoiceItem(string invoiceItemId)
        {
            return _invoiceItemDao.RemoveInvoiceItem(invoiceItemId);
        }

        public bool UpdateInvoiceItem(InvoiceItem invoiceItem)
        {
            return _invoiceItemDao.UpdateInvoiceItem(invoiceItem);
        }
    }
}
