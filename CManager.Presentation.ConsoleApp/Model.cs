using System;
using System.Collections.Generic;
using System.Text;

namespace CManager.Presentation.ConsoleApp;

public record Customer(
    Guid Id, 
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    Address Address);

public record Address( 
    string StreetAddress,
    string PostalCode,
    string City);

