public class Video
{
    private string _title;
    private string _author;
    private string _description;
    private string _comment;

    public Video(string title, string author, string description, string comment)
    {
        _title = title;
        _author = author;
        _description = description;
        _comment = comment;
    }

    public string GetTitle() { return _title; }
    public string GetAuthor() { return _author; }
    public string GetDescription() { return _description; }
    public string GetComment() { return _comment; }

    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Description: {_description}");
        Console.WriteLine($"Comment(s): {_comment}");
        Console.WriteLine();
    }
}
