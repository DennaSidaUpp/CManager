using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CManager.Presentation.ConsoleApp;

public class Repositry
{
    private const string Filename = "Data.json";

    public void Save(List<Customer> customers)
    {
        //if (!File.Exists(Filename))
        //{
        //    File.Create(Filename).Close();
        //}

        //var content = File.ReadAllText(Filename, Encoding.UTF8);                // Öppna or läs innehåll i filen some text
        //var dataList = string.IsNullOrEmpty(content)                    // Är innehållet i filen tom?
        //    ? new List<Customer>()                                      // Ja. Skapa en ny tom list
        //    : JsonSerializer.Deserialize<List<Customer>>(content);      // Nej, Gör om texten till en lista av kunder

        //dataList.Add(customer);                                                 // Lägg till den nya kunden


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
