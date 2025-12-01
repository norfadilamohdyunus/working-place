using Microsoft.EntityFrameworkCore;

namespace My1stProject
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=myconsoleapp.db");
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}