namespace Holecy.Coursera.Microsoft.LibraryManagement;

public interface IReader
{
    string Name { get; init; }
    string[] Books { get; init; }
}