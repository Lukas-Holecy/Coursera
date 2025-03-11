namespace Holecy.Coursera.Microsoft.Library;

/// <summary>
/// Represents a book in the library system.
/// </summary>
/// <param name="title">The title of the book</param>
public class Book(string title)
{
    /// <summary>
    /// Gets the title of the book.
    /// </summary>
    public string Title { get; init; } = title;

    /// <summary>
    /// Gets or sets whether the book is currently borrowed.
    /// </summary>
    public bool IsBorrowed { get; set; } = false;

    /// <summary>
    /// Gets or sets the name of the reader who borrowed the book.
    /// Empty if the book is not borrowed.
    /// </summary>
    public string BorrowedBy { get; set; } = string.Empty;

    /// <summary>
    /// Returns a string representation of the book including its title and availability status.
    /// </summary>
    /// <returns>String with book title and availability information</returns>
    public override string ToString()
    {
        if (IsBorrowed)
        {
            return $"{Title} - Borrowed by {BorrowedBy}";
        }

        return $"{Title} - Available";
    }
}