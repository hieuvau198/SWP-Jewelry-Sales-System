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
                product = UpdatePrice(product);
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
            List<Product> products = _jewelDbContext.Products.OrderByDescending(x => x.ProductId).ToList();
            products = UpdatePrices(products);
            return products;
        }

        public Product GetProduct(string productId)
        {
            Product product = _jewelDbContext.Products.Find(productId);
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
                updatedProduct.UnitPrice = product.UnitPrice;
                updatedProduct.TotalPrice = product.TotalPrice;

                updatedProduct = UpdatePrice(updatedProduct);

                _jewelDbContext.Products.Update(updatedProduct);
                _jewelDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Product> UpdatePrices(List<Product> products)
        {
            if (products == null)
            {
                return null;
            }
            if(products.Count == 0)
            {
                return products;
            }
            List<Product> results = products;
            List<Gem> gems = _jewelDbContext.Gems.ToList();
            List<Gold> golds = _jewelDbContext.Golds.ToList();

            foreach(Product product in results)
            {
                double unitPrice = 0;
                double totalPrice = 0;

                string gemName = "Not Found Gem Name";
                string goldName = "Not Found Gold Name";

                Gem gem = gems.Find(x => x.GemId == product.GemId);
                Gold gold = golds.Find(x => x.GoldId == product.GoldId);

                if(gem != null)
                { 
                    unitPrice += (gem.GemPrice * product.GemWeight); 
                    gemName = gem.GemName;
                }
                if(gold != null)
                {
                    unitPrice += (gold.SellPrice * product.GoldWeight);
                    goldName = gold.GoldName;
                }
                unitPrice += product.LaborCost;
                unitPrice = unitPrice * product.MarkupRate;
                totalPrice = unitPrice * product.ProductQuantity;
                product.UnitPrice = unitPrice;
                product.TotalPrice = totalPrice;
                product.GemName = gemName;
                product.GoldName = goldName;
            }
            return results;
        }
        public Product UpdatePrice(Product product)
        {
            if(product == null)
            { return null; }
            List<Gem> gems = _jewelDbContext.Gems.ToList();
            List<Gold> golds = _jewelDbContext.Golds.ToList();
            Product result = product;

            double unitPrice = 0;
            double totalPrice = 0;
            string gemName = "Some Gem Name";
            string goldName = "Some Gold Name";

            Gem gem = gems.Find(x => x.GemId == result.GemId);
            Gold gold = golds.Find(x => x.GoldId == result.GoldId);

            if (gem != null)
            {
                unitPrice += gem.GemPrice * result.GemWeight;
                gemName = gem.GemName;
            }
            if (gold != null)
            {
                unitPrice += gold.SellPrice * result.GoldWeight;
                goldName = gold.GoldName;
            }
            unitPrice += result.LaborCost;
            unitPrice = unitPrice * result.MarkupRate;
            totalPrice = unitPrice * result.ProductQuantity;
            result.UnitPrice = unitPrice;
            result.TotalPrice = totalPrice;
            result.GemName = gemName;
            result.GoldName = goldName;

            return result;
        }
        
    }
}
