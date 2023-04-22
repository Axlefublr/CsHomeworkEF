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
        optionsBuilder.UseSqlServer("Data Source=LAPTOP-FSDVNK6M;Database=EF;Trusted_Connection=True;");
    }
}