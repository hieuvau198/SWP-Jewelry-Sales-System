using JewelSystemBE.Data;
using JewelSystemBE.Model;

namespace JewelSystemBE.Service.ServiceProduct
{
    public class ProductService : IProductService
    {
        private readonly JewelDbContext _jewelDbContext;

        public ProductService(JewelDbContext jewelDbContext)
        {
            this._jewelDbContext = jewelDbContext;
        }

        public Product AddProduct(Product product)
        {
            if (product == null)
            {
                return null;
            }
            var existingProduct = _jewelDbContext.Products.Find(product.ProductId);
            if (existingProduct != null)
            {
                return null;
            }
            try
            {
                _jewelDbContext.Products.Add(product);
                _jewelDbContext.SaveChanges();
                return product;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                Console.WriteLine($"Error adding product: {ex.Message}");
                return null;
            }
        }

        public List<Product> GetProducts()
        {
            return _jewelDbContext.Products.OrderByDescending(x => x.ProductId).ToList();
        }

        public Product GetProduct(string productId)
        {
            return _jewelDbContext.Products.Find(productId);
        }

        public bool RemoveProduct(string productId)
        {
            if (productId == null)
            {
                return false;
            }
            Product product = _jewelDbContext.Products.Find(productId);
            if (product != null)
            {
                _jewelDbContext.Products.Remove(product);
                _jewelDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateProduct(Product product)
        {
            if (product == null)
            {
                return false;
            }
            Product updatedProduct = _jewelDbContext.Products.Find(product.ProductId);
            if (updatedProduct != null)
            {
                updatedProduct.ProductName = product.ProductName;
                updatedProduct.ProductCode = product.ProductCode;
                updatedProduct.ProductImages = product.ProductImages;
                updatedProduct.ProductQuantity = product.ProductQuantity;
                updatedProduct.ProductType = product.ProductType;
                updatedProduct.ProductWeight = product.ProductWeight;
                updatedProduct.ProductWarranty = product.ProductWarranty;
                updatedProduct.MarkupRate = product.MarkupRate;
                updatedProduct.GemId = product.GemId;
                updatedProduct.GemWeight = product.GemWeight;
                updatedProduct.GoldId = product.GoldId;
                updatedProduct.GoldWeight = product.GoldWeight;
                updatedProduct.LaborCost = product.LaborCost;
                updatedProduct.CreatedAt = product.CreatedAt;

                _jewelDbContext.Products.Update(updatedProduct);
                _jewelDbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
