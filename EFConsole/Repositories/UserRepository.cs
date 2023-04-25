namespace EFConsole.Repositories;

public class UserRepository
{

    private AppContext db;

    public UserRepository(AppContext db)
    {
        this.db = db;
    }
}