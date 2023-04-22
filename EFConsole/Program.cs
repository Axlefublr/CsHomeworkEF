namespace EFConsole;

internal class Program
{
    private static void Main(string[] args)
    {
        using AppContext db = new();
        User user1 = new() { Name = "Arthur", Role = "Admin" };
        User user2 = new() { Name = "Klim",   Role = "User" };
        db.Users.Add(user1);
        db.Users.Add(user2);
        db.SaveChanges();
    }
}