using System.Runtime.InteropServices.Marshalling;
using Holecy.Coursera.Microsoft.Library;

namespace Holecy.Coursera.Microsoft.LibraryManagement;

public class Library()
{
    private List<Book> Books = [];

    public void AddBook(string title)
    {        
        Books.Add(new Book(title));
        Console.WriteLine($"Book {title} added");
    }

    public void Remove(string title)
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

    public List<Book> SearchBookByName(string title)
    {
        return Books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase);
    }
}
