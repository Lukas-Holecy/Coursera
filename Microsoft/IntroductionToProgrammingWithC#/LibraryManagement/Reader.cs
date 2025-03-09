namespace Holecy.Coursera.Microsoft.LibraryManagement;

public class Reader(string name) : IReader
{
    public const int MaxBooks = 5;

    public string Name { get; init; } = name;

    public string[] Books { get; init; } = ["", "", "", "", ""];
}