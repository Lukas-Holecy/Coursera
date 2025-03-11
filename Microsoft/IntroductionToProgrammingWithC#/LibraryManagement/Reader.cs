namespace Holecy.Coursera.Microsoft.LibraryManagement;

/// <summary>
/// Represents a library reader who can borrow books.
/// </summary>
/// <param name="name">The name of the reader</param>
public class Reader(string name) : IReader
{
    /// <summary>
    /// Maximum number of books a reader can borrow at once.
    /// </summary>
    public const int MaxBooks = 3;

    /// <summary>
    /// Gets the name of the reader.
    /// </summary>
    public string Name { get; init; } = name;

    /// <summary>
    /// Gets the array of book titles currently borrowed by the reader.
    /// Empty strings represent available borrowing slots.
    /// </summary>
    public string[] Books { get; init; } = [.. Enumerable.Repeat("", MaxBooks)];
}