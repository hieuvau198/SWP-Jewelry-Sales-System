using JewelSystemBE.Model;

namespace JewelSystemBE.Service.ServiceProduct
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product GetProduct(string productId);
        bool AddProduct(Product product);
        bool RemoveProduct(string productId);
        bool UpdateProduct(Product product);
    }
}
