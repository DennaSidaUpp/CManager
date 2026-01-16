using System;
using System.Collections.Generic;
using System.Text;

namespace CManager.Presentation.ConsoleApp;

internal interface IService
{
    Customer CreateCustomer(string firstName, string lastName, string email, string phoneNumber, string streetAddress, string postalCode, string city);
    Customer? GetCustomer(string email);
    List<Customer> GetCustomers();
    bool RemoveCustomer(string email);
}

internal class Service(IRepositry repositry) : IService
{
    public Customer CreateCustomer(string firstName, string lastName, string email, string phoneNumber, string streetAddress, string postalCode, string city)
    {
        var list = repositry.GetCustomers();
        var customer = new Customer(Guid.NewGuid(), firstName, lastName, email, phoneNumber, new Address(streetAddress, postalCode, city));
        list.Add(customer);
        repositry.Save(list);
        return customer;
    }

    public List<Customer> GetCustomers() => repositry.GetCustomers();

    public Customer? GetCustomer(string email)
    {
        var list = repositry.GetCustomers();
        var foundCustomer = list.FirstOrDefault(c => c.Email == email);
        return foundCustomer;
    }

    public bool RemoveCustomer(string email)
    {
        var list = repositry.GetCustomers();
        var customer = list.FirstOrDefault(c => c.Email == email);
        if (customer != null)
        {
            list.Remove(customer);
            repositry.Save(list);
            return true;
        }

        return false;
    }
}
