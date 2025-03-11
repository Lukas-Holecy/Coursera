namespace Holecy.Coursera.Microsoft.LibraryManagement;

/// <summary>
/// Interface representing a library reader with ability to borrow books.
/// </summary>
public interface IReader
{
    /// <summary>
    /// Gets the name of the reader.
    /// </summary>
    string Name { get; init; }
    
    /// <summary>
    /// Gets the array of book titles currently borrowed by the reader.
    /// </summary>
    string[] Books { get; init; }
}