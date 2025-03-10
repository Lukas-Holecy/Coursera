namespace Holecy.Coursera.Microsoft.LibraryManagement;

using System.ComponentModel;
using System.Reflection.Metadata;

public class Menu(Library library)
{
    private bool running = false;
    private Reader currentReader;
    private Library library = library;

    public void Run()
    {
        running = true;
        ShowHint();
        this.Process();
    }


    public static void ShowHint()
    {
        Console.WriteLine("Choose a command using a number:");
        Console.WriteLine("1 - Add a book");
        Console.WriteLine("2 - Remove a book");
        Console.WriteLine("3 - List all books");
        Console.WriteLine("4 - Set current reader");
        Console.WriteLine("5 - Borrow a book");
        Console.WriteLine("6 - Return a book");
        Console.WriteLine("7 - List borrowed books");
        Console.WriteLine("8 - Show menu again");
        Console.WriteLine("0 - Exit");
    }

    public void Process()
    {
        while (running)
        {
            Console.WriteLine("Enter the number of the command:");
            string input = Console.ReadLine() ?? string.Empty;
            switch (input.ToUpper())
            {
                case "0":
                case "EXIT":
                    running = false;
                    break;
                case "1":
                case "ADD":
                    this.AddBook();
                    break;
                case "2":
                case "REMOVE":
                    this.RemoveBook();
                    break;
                case "3":
                case "LIST":
                    this.ListAllBooks();
                    break;
                case "4":
                case "LOGIN":
                    SetCurrentReader();
                    break;
                case "5":
                case "BORROW":
                    this.BorrowBook();
                    break;
                case "6":
                case "RETURN":
                    this.ReturnBook();
                    break;
                case "7":
                case "LIST BORROWED":
                    this.ListBorrowedBooks();
                    break;
                case "8":
                case "HELP":
                case "HINT":
                    ShowHint();
                    break;
                default:
                    Console.WriteLine("Unknown command");
                    this.
                    break;
            }
        }
    }

    private void AddBook()
    {
        Console.WriteLine("Enter the name of the book to add:");
        var bookName = Console.ReadLine();
        if (string.IsNullOrEmpty(bookName))
        {
            Console.WriteLine("The book name must be specified.");
            return;
        }

        library.AddBook(bookName);
    }

    private void RemoveBook()
    {
        Console.WriteLine("Enter the name of the book to remove:");
        var bookName = Console.ReadLine();
        if (string.IsNullOrEmpty(bookName))
        {
            Console.WriteLine("The book name must be specified.");
            return;
        }

        library.RemoveBook(bookName);
    }

    private void ListAllBooks()
    {
        Console.WriteLine("Available books:");
        var i = 1;
        foreach (var book in library.Books)
        {
            Console.WriteLine($"{i}\t-\t{book});
            i++;
        }
    }

    private void SetCurrentReader()
    {
        Console.WriteLine("Enter the name of the reader:");
        var readerName = Console.ReadLine();
        if (string.IsNullOrEmpty(readerName))
        {
            Console.WriteLine("The reader name must be specified.");
            return;
        }

        currentReader = library.GetReader(readerName);
        if (currentReader is null)
        {
            currentReader = library.AddReader(readerName);
            Console.WriteLine($"The reader {readerName} has been added.");

            return;
        }

        Console.WriteLine($"The reader {readerName} has been set as the current reader.");
    }

    private void ListBorrowedBooks()
    {
        if (currentReader is null)
        {
            Console.WriteLine("The current reader is not set.");
            return;
        }
        Console.WriteLine($"The reader {currentReade} has borrowed books:");
        for (int i = 0; i < currentReader.Books.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {currentReader.Books[i] ?? string.Empty}");
        }
    }

    private void ReturnBook()
    {
        if (currentReader is null)
        {
            Console.WriteLine("The current reader is not set.");
            return;
        }

        Console.WriteLine("Enter the name of the book to return:");
        var bookName = Console.ReadLine();
        if (string.IsNullOrEmpty(bookName))
        {
            Console.WriteLine("The book name must be specified.");
            return;
        }

        library.ReturnBook(bookName, currentReader);
    }

    private void BorrowBook()
    {
        var emptyIndex = Array.IndexOf(reader.Books, string.Empty);
        if (emptyIndex == -1)
        {
            Console.WriteLine($"The reader {currentReader.Name} have borrowed the maximum number of books.");
            return;
        }

        Console.WriteLine("Enter the name of the book to borrow:");
        var bookName = Console.ReadLine();

        if (string.IsNullOrEmpty(bookName))
        {
            Console.WriteLine("The book name must be specified.");
            return;
        }

        library.BorrowBook(bookName, currentReader);
    }
}