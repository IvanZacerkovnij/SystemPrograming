namespace Homework7.Models;

public class Client
{
    public string Name { get; set; } 
    public string Purpose { get; set; }

    public Client(string name, string purpose)
    {
        Name = name;
        Purpose = purpose;
    }
    
    public override string ToString() => $"{Name}, {Purpose}";
}