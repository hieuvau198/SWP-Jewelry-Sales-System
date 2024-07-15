﻿
using JewelBO;
using JewelDAO.DAOInvoiceItem;
using JewelDAO.DAOProduct;
using JewelDAO.DAOWarranty;
using Microsoft.IdentityModel.Tokens;

namespace JewelDAO.DAOInvoice
{
    public class InvoiceDao : IInvoiceDao
    {
        private readonly JewelDbContext _jewelDbContext;
        private readonly IInvoiceItemDao _invoiceItemService;
        private readonly IProductDao _productService;
        private readonly IWarrantyDao _warrantyService;

        public InvoiceDao(JewelDbContext jewelDbContext, IWarrantyDao warrantyDao, IProductDao productDao, IInvoiceItemDao invoiceItemDao)
        {
            this._jewelDbContext = jewelDbContext;
            _invoiceItemService = invoiceItemDao;
            _productService = productDao;
            _warrantyService = warrantyDao;
        }

        public Invoice AddInvoice(Invoice invoice)
        {
            if (invoice == null)
            {
                return null;
            }
            var existingInvoice = _jewelDbContext.Invoices.Find(invoice.InvoiceId);
            if (existingInvoice != null)
            {
                return null;
            }
            try
            {
                _jewelDbContext.Invoices.Add(invoice);
                _jewelDbContext.SaveChanges();
                return invoice;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                Console.WriteLine($"Error adding invoice: {ex.Message}");
                return null;
            }
        }

        public List<Invoice> GetInvoices()
        {
            return _jewelDbContext.Invoices.OrderByDescending(x => x.InvoiceId).ToList();
        }

        public Invoice GetInvoice(string invoiceId)
        {
            return _jewelDbContext.Invoices.Find(invoiceId);
        }

        public bool RemoveInvoice(string invoiceId)
        {
            if (invoiceId == null)
            {
                return false;
            }
            Invoice invoice = _jewelDbContext.Invoices.Find(invoiceId);
            if (invoice != null)
            {
                _jewelDbContext.Invoices.Remove(invoice);
                _jewelDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateInvoice(Invoice invoice)
        {
            if (invoice == null)
            {
                return false;
            }
            Invoice updatedInvoice = _jewelDbContext.Invoices.Find(invoice.InvoiceId);
            if (updatedInvoice != null)
            {
                if (invoice.InvoiceType != null)
                {
                    updatedInvoice.InvoiceType = invoice.InvoiceType;
                }

                if (invoice.CustomerId != null)
                {
                    updatedInvoice.CustomerId = invoice.CustomerId;
                }

                if (invoice.CustomerName != null)
                {
                    updatedInvoice.CustomerName = invoice.CustomerName;
                }

                if (invoice.UserId != null)
                {
                    updatedInvoice.UserId = invoice.UserId;
                }

                if (invoice.UserFullname != null)
                {
                    updatedInvoice.UserFullname = invoice.UserFullname;
                }

                if (invoice.ManagerId != null)
                {
                    updatedInvoice.ManagerId = invoice.ManagerId;
                }

                if (invoice.ManagerFullname != null)
                {
                    updatedInvoice.ManagerFullname = invoice.ManagerFullname;
                }

                if (invoice.CashierId != null)
                {
                    updatedInvoice.CashierId = invoice.CashierId;
                }

                if (invoice.CashierFullname != null)
                {
                    updatedInvoice.CashierFullname = invoice.CashierFullname;
                }

                if (invoice.StallId != null)
                {
                    updatedInvoice.StallId = invoice.StallId;
                }

                if (invoice.StallName != null)
                {
                    updatedInvoice.StallName = invoice.StallName;
                }

                if (invoice.InvoiceDate != null)
                {
                    updatedInvoice.InvoiceDate = invoice.InvoiceDate;
                }
                if (invoice.CustomerVoucher != null)
                {
                    updatedInvoice.CustomerVoucher = invoice.CustomerVoucher;
                }

                if (invoice.InvoiceStatus != null)
                {
                    updatedInvoice.InvoiceStatus = invoice.InvoiceStatus;
                    if (updatedInvoice.InvoiceStatus.Equals("Complete"))
                    {
                        UpdateProductQuantity(updatedInvoice.InvoiceId, updatedInvoice.InvoiceType);
                        if (updatedInvoice.InvoiceType.Equals("Sale"))
                        {
                            CreateWarranties(invoice.InvoiceId);
                        }
                    }
                }

                if (invoice.TotalPrice != null)
                {
                    updatedInvoice.TotalPrice = invoice.TotalPrice;
                }

                if (invoice.EndTotalPrice != null)
                {
                    updatedInvoice.EndTotalPrice = invoice.EndTotalPrice;
                }



                _jewelDbContext.Invoices.Update(updatedInvoice);
                _jewelDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public void UpdateProductQuantity(string invoiceId, string invoiceType)
        {
            if (invoiceType == null || invoiceId == null) return;

            //call data
            List<Product> products = _jewelDbContext.Products.ToList();
            List<InvoiceItem> invoiceItems = _jewelDbContext.InvoiceItems.ToList();
            List<InvoiceItem> foundItems = new List<InvoiceItem>();
            foreach (InvoiceItem item in invoiceItems)
            {
                if (item.InvoiceId.Equals(invoiceId))
                {
                    foundItems.Add(item);
                }
            }
            if (invoiceType.Equals("Sale"))
            {
                foreach (InvoiceItem item in foundItems)
                {
                    Product product = products.Find(x => x.ProductId == item.ProductId);
                    if (product != null)
                    {
                        product.ProductQuantity = product.ProductQuantity - item.Quantity;
                        _jewelDbContext.Products.Update(product);
                        _jewelDbContext.SaveChanges();
                    }
                }
            }
            else if (invoiceType.Equals("Buy"))
            {
                foreach (InvoiceItem item in foundItems)
                {
                    Product product = products.Find(x => x.ProductId == item.ProductId);
                    if (product != null)
                    {
                        product.ProductQuantity = product.ProductQuantity + item.Quantity;
                        _jewelDbContext.Products.Update(product);
                        _jewelDbContext.SaveChanges();
                    }
                }
            }
        }

        private void CreateWarranties(string invoiceId)
        {
            List<InvoiceItem> invoiceItems = _jewelDbContext.InvoiceItems.Where(x => (x.InvoiceId == invoiceId)).ToList();
            if (!invoiceItems.IsNullOrEmpty())
            {
                List<Product> products = _jewelDbContext.Products.ToList();
                foreach (InvoiceItem item in invoiceItems)
                {
                    Product product = products.Find(x => x.ProductId == item.ProductId);
                    if (product != null)
                    {
                        Warranty warranty = new Warranty
                        {
                            WarrantyId = "Temp",
                            ProductId = product.ProductId,
                            ProductName = product.ProductName,
                            StartDate = DateTime.Now,
                            ExpireDate = DateTime.Now.AddMonths(product.ProductWarranty)
                        };
                        _warrantyService.AddWarranty(warranty);
                    }
                }
            }
        }
    }
}
