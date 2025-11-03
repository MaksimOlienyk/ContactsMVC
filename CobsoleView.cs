using System;
using System.Collections.Generic;

public class ConsoleView
{
    public void ShowMenu()
    {
        Console.WriteLine();
        Console.WriteLine("=== CONTACTS MVC ===");
        Console.WriteLine("1. Показати всi контакти");
        Console.WriteLine("2. Додати контакт");
        Console.WriteLine("3. Видалити контакт");
        Console.WriteLine("0. Вихiд");
        Console.Write("Вибiр: ");
    }

    public void ShowContacts(IEnumerable<Contact> contacts)
    {
        Console.WriteLine();
        Console.WriteLine("Список контактів:");
        foreach (var c in contacts)
            Console.WriteLine(c.ToString());
    }

    public (string name, string phone) GetContactDetails()
    {
        Console.Write("Iм'я: ");
        var name = Console.ReadLine() ?? "";
        Console.Write("Телефон: ");
        var phone = Console.ReadLine() ?? "";
        return (name, phone);
    }

    public int GetContactId()
    {
        Console.Write("Введiть Id контакту: ");
        var s = Console.ReadLine();
        return int.TryParse(s, out var id) ? id : -1;
    }

    public void ShowMessage(string msg)
    {
        Console.WriteLine(msg);
    }
}
