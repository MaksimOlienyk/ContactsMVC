using System;

class Program
{
    static void Main()
    {
        var repository = new ContactRepository();
        var view = new ConsoleView();
        var controller = new ContactsController(repository, view);

        controller.Run(); // запускаємо головний цикл
    }
}