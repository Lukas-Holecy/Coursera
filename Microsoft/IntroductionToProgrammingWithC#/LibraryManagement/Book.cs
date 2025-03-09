namespace Holecy.Coursera.Microsoft.Library;

public class Book (string title)
{
    public string Title { get; init; } = title;

    public bool IsBorrowed { get; set; } = false;

    public string BorrowedBy { get; set; } = string.Empty;

    public override string ToString()
    {
        if (Borrowed)
        {
            return $"{Title} - Borrowed by {BorrowedBy}";
        }

        return $"{Title} - Available";
    }
}