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

    public void Add(Book book) => db.Books.Add(book);

    public void Remove(Book book) => db.Books.Remove(book);

    public void UpdateReleaseYear(int id, int releaseYear)
    {
        Book book = (Book)db.Books
            .Where(book => book.Id == id)
            .Select(book => book);
        book.ReleaseYear = releaseYear;
    }

}