using ConsoleMvcApp.Models;

namespace ConsoleMvcApp.Views;

public class UserView
{
    public void ShowUsers(List<User> users)
    {
        Console.WriteLine("\n===== User List =====");
        foreach (var user in users)
        {
            Console.WriteLine($"Id: {user.Id}, Name: {user.Name}");
        }
        Console.WriteLine("=====================\n");
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}