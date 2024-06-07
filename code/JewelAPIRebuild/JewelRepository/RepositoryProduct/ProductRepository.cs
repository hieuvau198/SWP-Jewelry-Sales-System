

using JewelBO;
using JewelDAO.DAOProduct;

namespace JewelRepository.RepositoryProduct
{
    public class ProductRepository : IProductRepository
    {
        private IProductDao _productDao;
        public ProductRepository(IProductDao productDao)
        {
            _productDao = productDao;
        }
        
        public bool AddProduct(Product product)
        {
            return _productDao.AddProduct(product);
        }

        public Product GetProduct(string productId)
        {
            return _productDao.GetProduct(productId);
        }

        public List<Product> GetProducts()
        {
            return _productDao.GetProducts();
        }

        public bool RemoveProduct(string productId)
        {
            return (_productDao.RemoveProduct(productId));
        }

        public bool UpdateProduct(Product product)
        {
            return _productDao.UpdateProduct(product);
        }
    }
}
