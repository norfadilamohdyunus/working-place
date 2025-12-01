using Microsoft.EntityFrameworkCore;
using ConsoleMvcApp.Models;

namespace ConsoleMvcApp.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}