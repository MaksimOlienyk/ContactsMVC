using System;

public class ContactsController
{
    private readonly ContactRepository _repo;
    private readonly ConsoleView _view;

    public ContactsController(ContactRepository repo, ConsoleView view)
    {
        _repo = repo;
        _view = view;
    }

    public void Run()
    {
        while (true)
        {
            _view.ShowMenu();
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    var all = _repo.GetAll();
                    _view.ShowContacts(all);
                    break;
                case "2":
                    var (name, phone) = _view.GetContactDetails();
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        _view.ShowMessage("Iм'я не може бути порожнiм.");
                        break;
                    }
                    var added = _repo.Add(name, phone);
                    _view.ShowMessage($"Додано: {added}");
                    break;
                case "3":
                    var id = _view.GetContactId();
                    if (id <= 0) { _view.ShowMessage("Невiрний Id."); break; }
                    var ok = _repo.Remove(id);
                    _view.ShowMessage(ok ? "Видалено." : "Контакт не знайдено.");
                    break;
                case "0":
                    _view.ShowMessage("До побачення!");
                    return;
                default:
                    _view.ShowMessage("Невiрний вибiр.");
                    break;
            }
        }
    }
}
