using System;
using System.Collections.Generic;
using System.Text;

namespace CManager.Presentation.ConsoleApp;

internal class Controller (Service service)
{
    public void ShowMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Customer Manager");
            Console.WriteLine("1. Create Customer");
            Console.WriteLine("2. View All Customers");
            Console.WriteLine("3. Delete Customer");
            Console.WriteLine("4. View Specific Customer");
            Console.WriteLine("0. Exit");
            Console.Write("Choose option: ");


            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CreateCustomer();
                    break;

                case "2":
                    ViewAllCustomers();
                    break;

                case "3":
                    DeleteCustomer();
                    break;

                case "4":
                    ViewCustomer();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Invalid option! Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
            Console.ReadKey();
        }
    }

    public void CreateCustomer ()
    {
        Console.Clear();
        Console.WriteLine("Create Customer");

        var firstName = Input("First name");
        var lastName = Input("Last name");
        var email = Input("Email");
        var phoneNumber = Input("Phone number");
        var streetAddress = Input("Street address");
        var postalCode = Input("Postalcode");
        var city = Input("City");

        var customer = service.CreateCustomer(firstName, lastName, email, phoneNumber, streetAddress, postalCode, city);

        Console.WriteLine($"Customer: {firstName} {lastName} has been saved. Id = {customer.Id}");

    }

    public string Input(string field)
    {
        Console.Write($"{field}: ");
        return Console.ReadLine();
    }

    public void ViewAllCustomers()
    {
        Console.Clear();
        var customers = service.GetCustomers();
        foreach (var customer in customers)
        {
            Console.WriteLine($"{customer.FirstName} {customer.LastName}, {customer.Email}");
        }
    }

    public void DeleteCustomer()
    {
        var email = Input("Email");
        var deleted = service.RemoveCustomer(email);

        if (deleted)
        {
            Console.WriteLine("Customer has been removed.");
        }
        else{
            Console.WriteLine("Customer was not found.");
        }
    }

    public void ViewCustomer()
    {
        var email = Input("Email");
        var customer = service.GetCustomer(email);

        if (customer == null)
        {
            Console.WriteLine("Customer was not found.");
        }
        else
        {
            Console.WriteLine($"{customer.FirstName} {customer.LastName}, {customer.Email} {customer.PhoneNumber} {customer.Address}");
        }
    }
}
