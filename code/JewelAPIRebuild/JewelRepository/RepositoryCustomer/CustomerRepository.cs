using JewelBO;
using JewelDAO.DAOCustomer;

namespace JewelRepository.RepositoryCustomer
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ICustomerDao _customerDao;

        public CustomerRepository(ICustomerDao customerDao)
        {
            _customerDao = customerDao;
        }

        public Customer AddCustomer(Customer customer)
        {
            return _customerDao.AddCustomer(customer);
        }

        public bool RemoveCustomer(string customerId)
        {
            return _customerDao.RemoveCustomer(customerId);
        }

        public bool UpdateCustomer(Customer customer)
        {
            return _customerDao.UpdateCustomer(customer);
        }

        public Customer GetCustomer(string customerId)
        {
            return _customerDao.GetCustomer(customerId);
        }

        public List<Customer> GetCustomers()
        {
            return _customerDao.GetCustomers();
        }
    }
}
