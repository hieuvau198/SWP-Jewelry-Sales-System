using JewelBO;
using JewelRepository.RepositoryInvoiceItem;

namespace JewelService.ServiceInvoiceItem
{
    public class InvoiceItemService : IInvoiceItemService
    {
        private readonly IInvoiceItemRepository _invoiceItemRepository;

        public InvoiceItemService(IInvoiceItemRepository invoiceItemRepository)
        {
            this._invoiceItemRepository = invoiceItemRepository;
        }

        public InvoiceItem AddInvoiceItem(InvoiceItem invoiceItem)
        {
            return _invoiceItemRepository.AddInvoiceItem(invoiceItem);
        }

        public List<InvoiceItem> GetInvoiceItems()
        {
            return _invoiceItemRepository.GetInvoiceItems();
        }

        public InvoiceItem GetInvoiceItem(string invoiceItemId)
        {
            return _invoiceItemRepository.GetInvoiceItem(invoiceItemId);
        }

        public bool RemoveInvoiceItem(string invoiceItemId)
        {
            return _invoiceItemRepository.RemoveInvoiceItem(invoiceItemId);
        }

        public bool UpdateInvoiceItem(InvoiceItem invoiceItem)
        {
            return _invoiceItemRepository.UpdateInvoiceItem(invoiceItem);
        }
    }
}
