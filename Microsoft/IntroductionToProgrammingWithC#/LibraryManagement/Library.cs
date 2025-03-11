using Holecy.Coursera.Microsoft.Library;

namespace Holecy.Coursera.Microsoft.LibraryManagement;

/// <summary>
/// Represents a library with collections of books and readers.
/// Provides functionality for book and reader management.
/// </summary>
public class Library
{
    /// <summary>
    /// Collection of all books in the library.
    /// </summary>
    private List<Book> Books = [];
    
    /// <summary>
    /// Collection of all registered readers.
    /// </summary>
    private List<IReader> Readers = [];

    /// <summary>
    /// Provides read-only access to the books collection.
    /// </summary>
    public IReadOnlyCollection<Book> AvailableBooks => Books.AsReadOnly();
    
    /// <summary>
    /// Provides read-only access to the readers collection.
    /// </summary>
    public IReadOnlyCollection<IReader> RegisteredReaders => Readers.AsReadOnly();
    
    /// <summary>
    /// Adds a new book to the library.
    /// </summary>
    /// <param name="title">The title of the book to add</param>
    public void AddBook(string title)
    {        
        Books.Add(new Book(title));
        Console.WriteLine($"Book {title} added");
    }

    /// <summary>
    /// Removes a book from the library if it's not borrowed.
    /// </summary>
    /// <param name="title">The title of the book to remove</param>
    public void RemoveBook(string title)
    {
        var booksMatchingTitle = SearchBooksByName(title);
        if (booksMatchingTitle.Count() == 0)
        {
            Console.WriteLine($"No book with title {title} found");
            return;
        }

        var bookToRemove = booksMatchingTitle.FirstOrDefault(b => !b.IsBorrowed);
        if (bookToRemove is null)
        {
            Console.WriteLine($"All books with title {title} are currently borrowed");
            return;
        }

        Books.Remove(bookToRemove);
        Console.WriteLine($"Book {title} removed");
    }

    /// <summary>
    /// Adds a new reader to the library.
    /// </summary>
    /// <param name="readerName">The name of the reader to add</param>
    /// <returns>The newly created reader, or null if a reader with the same name already exists</returns>
    public IReader? AddReader(string readerName)
    {
        if (Readers.Any(r => r.Name.Equals(readerName, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine($"Reader {readerName} already exists");
            return null;
        }

        var reader = new Reader(readerName);
        Readers.Add(reader);
        return reader;
    }

    /// <summary>
    /// Removes a reader from the library system.
    /// </summary>
    /// <param name="readerName">The name of the reader to remove</param>
    public void RemoveReader(string readerName)
    {
        var reader = Readers.FirstOrDefault(r => r.Name.Equals(readerName, StringComparison.OrdinalIgnoreCase));
        if (reader is null)
        {
            Console.WriteLine($"Reader {readerName} not found");
            return;
        }

        Readers.Remove(reader);
        Console.WriteLine($"Reader {readerName} removed");
    }

    /// <summary>
    /// Gets a reader by name.
    /// </summary>
    /// <param name="readerName">The name of the reader to find</param>
    /// <returns>The reader if found, otherwise null</returns>
    public IReader? GetReader(string readerName)
    {
        return Readers.FirstOrDefault(r => r.Name.Equals(readerName, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Searches for books by title.
    /// </summary>
    /// <param name="title">The title to search for</param>
    /// <returns>Collection of books matching the title</returns>
    public IEnumerable<Book> SearchBooksByName(string title)
    {
        return Books.Where(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Allows a reader to borrow a book.
    /// </summary>
    /// <param name="title">The title of the book to borrow</param>
    /// <param name="reader">The reader who wants to borrow the book</param>
    public void BorrowBook(string title, IReader reader)
    {
        var books = SearchBooksByName(title);
        if (!books.Any())
        {
            Console.WriteLine($"No book with title {title} found");
            return;
        }

        var availableBook = books.FirstOrDefault(x => !x.IsBorrowed);
        if (availableBook is null)
        {
            Console.WriteLine($"Book {title} is already borrowed");
            return;
        }

        var borrowSlot = Array.IndexOf(reader.Books, string.Empty);
        if (borrowSlot == -1)
        {
            Console.WriteLine($"Reader {reader.Name} has borrowed the maximum number of books");
            return;
        }

        reader.Books[borrowSlot] = title;
        availableBook.IsBorrowed = true;
        availableBook.BorrowedBy = reader.Name;

        Console.WriteLine($"Book {title} borrowed by {reader.Name}");
    }

    /// <summary>
    /// Allows a reader to return a borrowed book.
    /// </summary>
    /// <param name="title">The title of the book to return</param>
    /// <param name="reader">The reader returning the book</param>
    public void ReturnBook(string title, IReader reader)
    {
        var books = SearchBooksByName(title);
        if (!books.Any())
        {
            Console.WriteLine($"No book with title {title} found");
            return;
        }

        var borrowedBookRecord = books.FirstOrDefault(x => x.IsBorrowed);
        if (borrowedBookRecord is null)
        {
            Console.WriteLine($"Book {title} is not borrowed.");
            return;
        }

        var borrowSlot = Array.IndexOf(reader.Books, title);
        if (borrowSlot == -1)
        {
            Console.WriteLine($"Reader {reader.Name} does not have book {title}");
            return;
        }

        reader.Books[borrowSlot] = string.Empty;
        borrowedBookRecord.IsBorrowed = false;
        borrowedBookRecord.BorrowedBy = string.Empty;

        Console.WriteLine($"Book {title} returned by {reader.Name}");
    }
}