namespace EFConsole.Repositories;

public class BookRepository
{

    private readonly AppContext db;

    public BookRepository(AppContext db)
    {
        this.db = db;
    }

    public Book GetBookById(int id) => db.Books.FirstOrDefault(book => book.Id == id);

    public List<Book> GetAllBooks() => db.Books
        .Select(book => book)
        .ToList();

    public void Add(Book book) => db.Books.Add(book);

    public void Remove(Book book) => db.Books.Remove(book);

    public void UpdateReleaseYear(int id, int releaseYear)
    {
        Book book = (Book)db.Books
            .Where(book => book.Id == id)
            .Select(book => book);
        book.ReleaseYear = releaseYear;
    }

    public List<Book> GetBooksByGenreAndYears(string genre, int startYear, int endYear)
    {
        return db.Books
            .Where(book =>
                book.Genre == genre
                && book.ReleaseYear >= startYear
                && book.ReleaseYear <= endYear
            ).Select(book => book)
            .ToList();
    }

    public int GetBookCountByAuthorName(string authorName)
    {
        return db.Books
            .Where(book => book.AuthorName == authorName)
            .Count();
    }

}