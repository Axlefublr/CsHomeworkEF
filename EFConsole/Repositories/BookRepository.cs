namespace EFConsole.Repositories;

public class BookRepository
{

    private AppContext db;

    public BookRepository(AppContext db)
    {
        this.db = db;
    }

    public Book GetBookById(int id) => (Book)db.Books
        .Where(book => book.Id = id)
        .Select(book => book);

    public List<Book> GetAllBooks() => db.Books.Select(book => book);

}