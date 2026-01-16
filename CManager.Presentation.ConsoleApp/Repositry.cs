using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CManager.Presentation.ConsoleApp;

public interface IRepositry
{
    List<Customer> GetCustomers();
    void Save(List<Customer> customers);
}

public class Repositry : IRepositry
{
    private const string Filename = "Data.json";

    public void Save(List<Customer> customers)
    {
        var json = JsonSerializer.Serialize<List<Customer>>(customers);           // Gör om listan till json text
        File.WriteAllText(Filename, json);                                   // Skriv texten till filen
    }

    public List<Customer> GetCustomers()
    {
        if (!File.Exists(Filename))
        {
            return new List<Customer>();
        }

        var content = File.ReadAllText(Filename, Encoding.UTF8);                            // Öppna och läs innehåll i filen some text
        var customers = string.IsNullOrEmpty(content)                                       // Är innehållet i filen tom?
            ? new List<Customer>()                                                          // Ja. Skapa en ny tom list
            : JsonSerializer.Deserialize<List<Customer>>(content) ?? new List<Customer>();  // Nej, Gör om texten till en lista av kunder. Skapa ny tom list om det inte gick att läsa json
        return customers;
    }
}
