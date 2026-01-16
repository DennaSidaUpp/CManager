
namespace CManager.Presentation.ConsoleApp.Test;

public class ServiceTest
{
    [Fact]
    public void GetCustomersTest()
    {
        // Arrange
        var service = new Service(new MockRepository());

        // Act
        var customers = service.GetCustomers();

        // Assert
        Assert.NotNull(customers);
        Assert.Equal(2, customers.Count);
    }

    [Theory]
    [InlineData("mimmi@some.com", true)]
    [InlineData("blaha@some.com", false)]
    [InlineData("", false)]
    public void GetCustomerTest(string email, bool expected)
    {
        // Arrange
        var service = new Service(new MockRepository());

        // Act
        var customer = service.GetCustomer(email);

        // Assert
        if (expected)
        {
            Assert.NotNull(customer);
        }
        else
        {
            Assert.Null(customer);
        }
    }
}

public class MockRepository : IRepositry
{
    public List<Customer> GetCustomers()
    {
        return new List<Customer>() 
        {
           new(Guid.NewGuid(), "Musse", "Pigg", "musse@some.com", "123456", new("Gatan 1", "123", "Ankeborg")),
           new(Guid.NewGuid(), "Mimmi", "Pigg", "mimmi@some.com", "123456", new("Gatan 1", "123", "Ankeborg")),
        };
    }

    public void Save(List<Customer> customers)
    {
        // Do nothing
    }
}
