using JewelBO;
using JewelRepository.RepositoryProduct;

namespace JewelService.ServiceProduct
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public Product AddProduct(Product product)
        {
            return _productRepository.AddProduct(product);
        }

        public List<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public Product GetProduct(string productId)
        {
            return _productRepository.GetProduct(productId);
        }

        public bool RemoveProduct(string productId)
        {
            return (_productRepository.RemoveProduct(productId));
        }

        public bool UpdateProduct(Product product)
        {
            return _productRepository.UpdateProduct(product);
        }
    }
}
