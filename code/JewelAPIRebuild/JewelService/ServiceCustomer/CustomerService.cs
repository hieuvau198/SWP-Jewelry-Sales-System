using JewelBO;
using JewelRepository.RepositoryCustomer;

namespace JewelService.ServiceCustomer
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        public bool AddCustomer(Customer customer)
        {
            return _customerRepository.AddCustomer(customer);
        }

        public List<Customer> GetCustomers()
        {
            return _customerRepository.GetCustomers();
        }

        public Customer GetCustomer(string customerId)
        {
            return _customerRepository.GetCustomer(customerId);
        }

        public bool RemoveCustomer(string customerId)
        {
            return (_customerRepository.RemoveCustomer(customerId));
        }

        public bool UpdateCustomer(Customer customer)
        {
            return _customerRepository.UpdateCustomer(customer);
        }
    }
}
