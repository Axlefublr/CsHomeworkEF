namespace EFConsole.Repositories;

public class UserRepository
{

    private AppContext db;

    public UserRepository(AppContext db)
    {
        this.db = db;
    }

    public List<User> GetUserById(int id)
    {
        return db.Users.Where(user => user.Id == id).Select(user => user).ToList();
    }
}