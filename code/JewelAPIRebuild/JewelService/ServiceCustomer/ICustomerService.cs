﻿using JewelBO;

namespace JewelService.ServiceCustomer
{
    public interface ICustomerService
    {
        List<Customer> GetCustomers();
        Customer GetCustomer(string customerId);
        Customer AddCustomer(Customer customer);
        bool RemoveCustomer(string customerId);
        bool UpdateCustomer(Customer customer);
    }
}
