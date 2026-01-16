//string name = "";
//string email = "";

//do
//{
//    Console.Clear();
//    Console.Write("Enter your name: ");
//    name = Console.ReadLine()!;

//    if (string.IsNullOrEmpty(name))
//    {
//        Console.WriteLine("You must enter a name");
//        Console.ReadKey();
//        Console.Clear();
//    }
//}
//while (string.IsNullOrEmpty(name));

//do
//{
//    Console.Clear();
//    Console.Write("Enter your email: ");
//    email = Console.ReadLine()!;

//    if (string.IsNullOrEmpty(email))
//    {
//        Console.WriteLine("You must enter a email");
//        Console.ReadKey();
//        Console.Clear();
//    }
//}
//while (string.IsNullOrEmpty(email));

//Console.Clear();
//Console.WriteLine($"Your name is {name} and your email is {email}");
//Console.ReadKey();

using CManager.Presentation.ConsoleApp;

var service = new Service(new Repositry());
var controller = new Controller(service);
controller.ShowMenu();

//var kalle = service.CreateCustomer(
//    "Kalle",
//    "Anka",
//    "kalle@some.com",
//    "123456",
//    "Platfotsgatan 111",
//    "12345",
//    "Ankeborg");

//var customers = service.GetCustomers();
//Console.WriteLine($"Antal Customers {customers.Count}");
//foreach (Customer customer in customers)
//{
//    Console.WriteLine($"{customer.Id}");
//    Console.WriteLine($"{customer.FirstName} {customer.LastName}, {customer.Email}");
//    Console.WriteLine();
//}


//var foundCustomer = service.GetCustomer(Guid.Parse("5cb67ea1-1767-4210-adf9-994dbc29bba3"));
//if (foundCustomer == null)
//{
//    Console.WriteLine("Customer not found");
//}
//else
//{
//    Console.WriteLine($"{foundCustomer.Id}");
//    Console.WriteLine($"{foundCustomer.FirstName} {foundCustomer.LastName}, {foundCustomer.Email}");
//    Console.WriteLine();
//}

//var removed = service.RemoveCustomer(Guid.Parse("5cb67ea1-1767-4210-adf9-994dbc29bba3"));
//Console.WriteLine($"Customer was removed {removed}");
