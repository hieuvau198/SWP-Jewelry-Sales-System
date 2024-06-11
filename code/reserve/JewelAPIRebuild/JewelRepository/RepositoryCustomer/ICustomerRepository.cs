using JewelBO;

namespace JewelRepository.RepositoryCustomer
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomers();
        Customer GetCustomer(string customerId);
        bool AddCustomer(Customer customer);
        bool RemoveCustomer(string customerId);
        bool UpdateCustomer(Customer customer);
    }
}
