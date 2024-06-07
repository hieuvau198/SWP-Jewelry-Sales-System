using JewelBO;

namespace JewelDAO.DAOProduct
{
    public interface IProductDao
    {
        List<Product> GetProducts();
        Product GetProduct(string productId);
        bool AddProduct(Product product);
        bool RemoveProduct(string productId);
        bool UpdateProduct(Product product);
    }
}
