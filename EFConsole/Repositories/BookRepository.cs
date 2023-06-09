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

    public int GetBookCountByGenre(string genre)
    {
        return db.Books
            .Where(book => book.Genre == genre)
            .Count();
    }

    public bool DoesBookExistByAuthorNameAndTitle(string authorName, string title) // ah yes, java naming
    {
        return db.Books.Any(book =>
            book.AuthorName == authorName
            && book.Title == title
        );
    }

    public Book GetMostRecentBook()
    {
        return (Book)db.Books
            .Select(book => book)
            .OrderByDescending(book => book.ReleaseYear)
            .Take(1);
    }

    public List<Book> GetBooksSortedByTitle()
    {
        return db.Books
            .Select(book => book)
            .OrderBy(book => book.Title)
            .ToList();
    }

    public List<Book> GetBooksSortedByReleaseYearDescending() // the only reason this method's name is so long is because it's so damn specific lol
    {
        return db.Books
            .Select(book => book)
            .OrderByDescending(book => book.ReleaseYear)
            .ToList();
    }

}