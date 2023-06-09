namespace EFConsole.Repositories;

public class UserRepository
{

    private readonly AppContext db;

    public UserRepository(AppContext db)
    {
        this.db = db;
    }

    public User GetUserById(int id) => db.Users.FirstOrDefault(user => user.Id == id);

    public List<User> GetAllUsers() => db.Users
        .Select(user => user)
        .ToList();

    public void Add(User user) => db.Users.Add(user);

    public void Remove(User user) => db.Users.Remove(user);

    public void UpdateName(int id, string name)
    {
        User user = (User)db.Users
            .Where(user => user.Id == id)
            .Select(user => user);
        user.Name = name;
    }

    public static int GetBookCount(User user) => user.Books.Count;

}