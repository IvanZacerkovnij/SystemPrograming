namespace Homework5.Models;

public class Post
{
    public int UserId { get; set; }
    public int Id { get; set; }
    public string Title { get; set; } =  string.Empty;
    public string Body { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"{Id} - {Title} - {Body}";
    }
}