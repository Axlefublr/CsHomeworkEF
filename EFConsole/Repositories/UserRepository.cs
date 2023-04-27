namespace EFConsole.Repositories;

public class UserRepository
{

    private AppContext db;

    public UserRepository(AppContext db)
    {
        this.db = db;
    }

    public User GetUserById(int id) => (User)db.Users
        .Where(user => user.Id == id)
        .Select(user => user);

    public List<User> GetAllUsers() => db.Users
        .Select(user => user)
        .ToList();

    public void Add(User user)
    {
        db.Users.Add(user);
    }

    public void Remove(User user)
    {
        db.Users.Remove(user);
    }

}