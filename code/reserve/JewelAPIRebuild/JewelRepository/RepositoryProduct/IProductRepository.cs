

using JewelBO;

namespace JewelRepository.RepositoryProduct
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        Product GetProduct(string productId);
        bool AddProduct(Product product);
        bool RemoveProduct(string productId);
        bool UpdateProduct(Product product);
    }
}
