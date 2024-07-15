using JewelBO;

namespace JewelService.ServiceProduct
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product GetProduct(string productId);
        Product AddProduct(Product product);
        bool RemoveProduct(string productId);
        bool UpdateProduct(Product product);
        
    }
}
