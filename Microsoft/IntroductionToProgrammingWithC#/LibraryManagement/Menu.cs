namespace Holecy.Coursera.Microsoft.LibraryManagement;

using System.ComponentModel;
using System.Reflection.Metadata;

/// <summary>
/// Provides a command-line interface for interacting with the library system.
/// </summary>
/// <param name="library">The library instance to work with</param>
public class Menu(Library library)
{
    /// <summary>
    /// Flag indicating if the menu is currently running.
    /// </summary>
    private bool running = false;
    
    /// <summary>
    /// The currently selected reader for operations.
    /// </summary>
    private IReader? currentReader;
    
    /// <summary>
    /// Reference to the library system.
    /// </summary>
    private Library library = library;
    
    /// <summary>
    /// Starts the menu system and begins processing commands.
    /// </summary>
    public void Run()
    {
        running = true;
        ShowHint();
        this.Process();
    }

    /// <summary>
    /// Displays the available commands to the user.
    /// </summary>
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

    /// <summary>
    /// Processes user input and executes appropriate commands.
    /// </summary>
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
                    ShowHint();
                    break;
            }
        }
    }

    /// <summary>
    /// Handles adding a new book to the library.
    /// </summary>
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

    /// <summary>
    /// Handles removing a book from the library.
    /// </summary>
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

    /// <summary>
    /// Displays all books in the library.
    /// </summary>
    private void ListAllBooks()
    {
        Console.WriteLine("Available books:");
        var i = 1;
        foreach (var book in library.AvailableBooks)
        {
            Console.WriteLine($"{i}\t-\t{book}");
            i++;
        }
    }

    /// <summary>
    /// Sets or creates the current reader for operations.
    /// </summary>
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

    /// <summary>
    /// Displays books borrowed by the current reader.
    /// </summary>
    private void ListBorrowedBooks()
    {
        if (currentReader is null)
        {
            Console.WriteLine("The current reader is not set.");
            return;
        }
        Console.WriteLine($"The reader {currentReader.Name} has borrowed books:");
        for (int i = 0; i < currentReader.Books.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {currentReader.Books[i] ?? string.Empty}");
        }
    }

    /// <summary>
    /// Handles returning a book to the library.
    /// </summary>
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

    /// <summary>
    /// Handles borrowing a book from the library.
    /// </summary>
    private void BorrowBook()
    {
        if (currentReader is null)
        {
            Console.WriteLine("The current reader is not set.");
            return;
        }

        var emptyIndex = Array.IndexOf(currentReader.Books, string.Empty);
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