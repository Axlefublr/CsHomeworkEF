namespace EFConsole.Repositories;

public class BookRepository
{

    private AppContext db;

    public BookRepository(AppContext db)
    {
        this.db = db;
    }
}