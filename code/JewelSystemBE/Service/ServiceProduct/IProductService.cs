using JewelSystemBE.Model;

namespace JewelSystemBE.Service.ServiceProduct
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product GetProduct(string productId);
        Product AddProduct(Product product);
        bool RemoveProduct(string productId);
        bool UpdateProduct(Product product);
        List<Product> UpdatePrices(List<Product> products);
        Product UpdatePrice(Product product);

    }
}
