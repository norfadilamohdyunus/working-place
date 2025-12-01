using ConsoleMvcApp.Data;
using ConsoleMvcApp.Models;

namespace ConsoleMvcApp.Controllers;

public class UserController
{
    private readonly AppDbContext _db;

    public UserController(AppDbContext db)
    {
        _db = db;
    }

    public List<User> GetUsers()
    {
        return _db.Users.ToList();
    }

    public void AddUser(string name)
    {
        var user = new User { Name = name };
        _db.Users.Add(user);
        _db.SaveChanges();
    }

    public bool UpdateUser(int id, string newName)
    {
        var user = _db.Users.FirstOrDefault(x => x.Id == id);
        if (user == null) return false;

        user.Name = newName;
        _db.SaveChanges();
        return true;
    }

    public bool DeleteUser(int id)
    {
        var user = _db.Users.FirstOrDefault(x => x.Id == id);
        if (user == null) return false;

        _db.Users.Remove(user);
        _db.SaveChanges();
        return true;
    }
}