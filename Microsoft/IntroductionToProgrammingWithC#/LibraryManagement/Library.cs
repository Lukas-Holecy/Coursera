using System.Runtime.InteropServices.Marshalling;
using Holecy.Coursera.Microsoft.Library;

namespace Holecy.Coursera.Microsoft.LibraryManagement;

public class Library()
{
    private List<Book> Books = [];

    private List<IReader> Readers = [];

    public void AddBook(string title)
    {        
        Books.Add(new Book(title));
        Console.WriteLine($"Book {title} added");
    }

    public void RemoveBook(string title)
    {
        var booksMatchingTitle = SearchBookByName(title);
        if (booksMatchingTitle.Count == 0)
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

    public IReader AddReader(string readerName)
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

    public List<Book> SearchBooksByName(string title)
    {
        return Books.Where(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase);
    }

    public void BorrowBook(string title, IReader reader)
    {
        var book = SearchBooksByName(title);
        if (book)
        {
            Console.WriteLine($"No book with title {title} found");
            return;
        }

        if (book.IsBorrowed)
        {
            Console.WriteLine($"Book {title} is already borrowed");
            return;
        }

        book.Borrow(reader);
        Console.WriteLine($"Book {title} borrowed by {reader.Name}");
    }

    public void ReturnBook(string title, IReader reader)
    {
        var book = SearchBooksByName(title);
        if (book is null)
        {
            Console.WriteLine($"No book with title {title} found");
            return;
        }

        if (!book.IsBorrowed)
        {
            Console.WriteLine($"Book {title} is not borrowed");
            return;
        }

        book.Return(reader);
        Console.WriteLine($"Book {title} returned by {reader.Name}");
    }
}
