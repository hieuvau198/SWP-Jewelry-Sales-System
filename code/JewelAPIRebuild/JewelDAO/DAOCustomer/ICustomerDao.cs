using JewelBO;

namespace JewelDAO.DAOCustomer
{
    public interface ICustomerDao
    {
        List<Customer> GetCustomers();
        Customer GetCustomer(string customerId);
        Customer AddCustomer(Customer customer);
        bool RemoveCustomer(string customerId);
        bool UpdateCustomer(Customer customer);
    }
}
