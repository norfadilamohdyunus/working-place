using Microsoft.EntityFrameworkCore;
using ConsoleMvcApp.Data;
using ConsoleMvcApp.Controllers;
using ConsoleMvcApp.Views;

var options = new DbContextOptionsBuilder<AppDbContext>()
    .UseSqlite("Data Source=app.db")
    .Options;

using var db = new AppDbContext(options);
db.Database.EnsureCreated();

var controller = new UserController(db);
var view = new UserView();

while (true)
{
    Console.WriteLine("===== USER MANAGEMENT =====");
    Console.WriteLine("1) Add User");
    Console.WriteLine("2) List Users");
    Console.WriteLine("3) Update User");
    Console.WriteLine("4) Delete User");
    Console.WriteLine("0) Exit");
    Console.Write("Choose option: ");

    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Write("Enter name: ");
            var name = Console.ReadLine()!;
            controller.AddUser(name);
            view.ShowMessage("User added.\n");
            break;

        case "2":
            var users = controller.GetUsers();
            view.ShowUsers(users);
            break;

        case "3":
            Console.Write("Enter user ID to update: ");
            int idU = int.Parse(Console.ReadLine()!);

            Console.Write("Enter new name: ");
            string newName = Console.ReadLine()!;

            if (controller.UpdateUser(idU, newName))
                view.ShowMessage("User updated.\n");
            else
                view.ShowMessage("User not found.\n");

            break;

        case "4":
            Console.Write("Enter user ID to delete: ");
            int idD = int.Parse(Console.ReadLine()!);

            if (controller.DeleteUser(idD))
                view.ShowMessage("User deleted.\n");
            else
                view.ShowMessage("User not found.\n");

            break;

        case "0":
            return;

        default:
            Console.WriteLine("Invalid choice.\n");
            break;
    }
}