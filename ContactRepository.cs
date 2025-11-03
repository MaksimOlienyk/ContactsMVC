using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

// Проста in-memory "база"
public class ContactRepository
{
    private readonly List<Contact> _contacts = new();
    private int _nextId = 1;

    public IEnumerable<Contact> GetAll() => _contacts.ToList();

    public Contact? GetById(int id) => _contacts.FirstOrDefault(c => c.Id == id);

    public Contact Add(string name, string phone)
    {
        var c = new Contact { Id = _nextId++, Name = name, Phone = phone };
        _contacts.Add(c);
        return c;
    }

    public bool Remove(int id)
    {
        var c = GetById(id);
        if (c == null) return false;
        _contacts.Remove(c);
        return true;
    }
}
