using Microsoft.EntityFrameworkCore;

namespace EFConsole;

public class AppContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public AppContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Ваша строка подключения к БД");
    }
}