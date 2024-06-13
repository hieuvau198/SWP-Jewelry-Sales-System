using JewelSystemBE.Data;
using JewelSystemBE.Model;

namespace JewelSystemBE.Service.ServiceCustomer
{
    public class CustomerService : ICustomerService
    {
        private readonly JewelDbContext _jewelDbContext;

        public CustomerService(JewelDbContext jewelDbContext)
        {
            this._jewelDbContext = jewelDbContext;
        }

        public Customer AddCustomer(Customer customer)
        {
            if (customer == null)
            {
                return null;
            }
            var existingCustomer = _jewelDbContext.Customers.Find(customer.CustomerId);
            if (existingCustomer != null)
            {
                return null;
            }
            try
            {
                _jewelDbContext.Customers.Add(customer);
                _jewelDbContext.SaveChanges();
                return customer;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                Console.WriteLine($"Error adding customer: {ex.Message}");
                return null;
            }
        }

        public List<Customer> GetCustomers()
        {
            return _jewelDbContext.Customers.OrderByDescending(x => x.CustomerId).ToList();
        }

        public Customer GetCustomer(string customerId)
        {
            return _jewelDbContext.Customers.Find(customerId);
        }

        public bool RemoveCustomer(string customerId)
        {
            if (customerId == null)
            {
                return false;
            }
            Customer customer = _jewelDbContext.Customers.Find(customerId);
            if (customer != null)
            {
                _jewelDbContext.Customers.Remove(customer);
                _jewelDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateCustomer(Customer customer)
        {
            if (customer == null)
            {
                return false;
            }
            Customer updatedCustomer = _jewelDbContext.Customers.Find(customer.CustomerId);
            if (updatedCustomer != null)
            {
                updatedCustomer.CustomerName = customer.CustomerName;
                updatedCustomer.CustomerRank = customer.CustomerRank;
                updatedCustomer.CustomerPoint = customer.CustomerPoint;
                updatedCustomer.AttendDate = customer.AttendDate;
                _jewelDbContext.Customers.Update(updatedCustomer);
                _jewelDbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
