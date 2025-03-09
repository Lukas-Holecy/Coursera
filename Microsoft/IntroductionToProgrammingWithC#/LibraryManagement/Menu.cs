namespace Holecy.Coursera.Microsoft.LibraryManagement;

using System.ComponentModel;
using System.Reflection.Metadata;

public class Menu(IReader reader)
{
    private bool running = false;

    private IReader reader = reader;

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
            switch (input)
            {
                case "0":
                    running = false;
                    break;
                case "1":
                    this.BorrowBook();
                    break;
                case "2":
                    this.ReturnBook();
                    break;
                case "3":
                    this.ListBorrowedBooks();
                    break;
                case "4":
                    ShowHint();
                    break;
                default:
                    Console.WriteLine("Unknown command");
                    this.
                    break;
            }
        }
    }

    private void ListBorrowedBooks()
    {
        Console.WriteLine("Borrowed books:");
        for (int i = 0; i < reader.Books.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {reader.Books[i] ?? string.Empty}");
        }
    }

    private void ReturnBook()
    {
        Console.WriteLine("Enter the name of the book to return:");
        var bookName = Console.ReadLine();
        if (string.IsNullOrEmpty(bookName))
        {
            Console.WriteLine("The book name must be specified.");
            return;
        }

        var index = Array.IndexOf(reader.Books, bookName);
        if (index != -1)
        {
            reader.Books[index] = string.Empty;            
            Console.WriteLine($"The book {bookName} has been returned.");
            return;
        }
        else
        {
            Console.WriteLine($"The book {bookName} is not borrowed.");
        }
    }

    private void BorrowBook()
    {
        var emptyIndex = Array.IndexOf(reader.Books, string.Empty);
        if (emptyIndex == -1)
        {
            Console.WriteLine("You have borrowed the maximum number of books.");
            return;
        }

        Console.WriteLine("Enter the name of the book to borrow:");
        var bookName = Console.ReadLine();

        if (string.IsNullOrEmpty(bookName))
        {
            Console.WriteLine("The book name must be specified.");
            return;
        }

        reader.Books[emptyIndex] = bookName;
        Console.WriteLine($"The book {bookName} has been borrowed.");
    }
}