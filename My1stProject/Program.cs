using System;
using System.Linq;

namespace My1stProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppDbContext())
            {
                db.Database.EnsureCreated(); // Create db if not exist

                // Add user
                db.Users.Add(new User { Name = "Fadila" });
                db.SaveChanges();

                // Read users
                var users = db.Users.ToList();
                foreach (var user in users)
                {
                    Console.WriteLine($"Id: {user.Id}, Name: {user.Name}");
                }
            }
        }
    }
}